using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Media;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Drawing2D;

namespace 在线工具箱
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 设置在线工具箱的Region
        /// </summary>
        public void SetWindowRegion()
        {
            GraphicsPath FormPath;
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            FormPath = GetRoundedRectPath(rect, 10);
            this.Region = new Region(FormPath);

        }
        /// <summary>
        /// 绘制圆角路径
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            // 左上角
            path.AddArc(arcRect, 180, 90);

            // 右上角
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            // 右下角
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            // 左下角
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();//闭合曲线
            return path;
        }

        /// <summary>
        /// 在线工具箱size发生改变时重新设置Region属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        //标志描述：
        const int AW_SLIDE = 0x40000;//使用滑动类型。缺省则为滚动动画类型。当使用AW_CENTER标志时，这个标志就被忽略。
        const int AW_ACTIVATE = 0x20000;//激活窗口。在使用了AW_HIDE标志后不要使用这个标志。
        const int AW_BLEND = 0x80000;//使用淡出效果。只有当hWnd为顶层窗口的时候才可以使用此标志。
        const int AW_HIDE = 0x10000;//隐藏窗口，缺省则显示窗口。(关闭窗口用)
        const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；若未使用AW_HIDE标志，则使窗口向外扩展。
        const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。
        const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。
        const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。
        const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "GetForegroundWindow", CharSet = System.Runtime.InteropServices.CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetF(); //获得本在线工具箱的句柄
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetF(IntPtr hWnd); //设置此在线工具箱为活动在线工具箱
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        void downloadFromFastgit()
        {
            try
            {
                StreamReader sr = new StreamReader($"{Path.GetTempPath()}zxgjxnodeselection");
                string node=sr.ReadToEnd();

                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                webClient.DownloadFileAsync(new Uri($"{node}%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1.exe"), $"{AppDomain.CurrentDomain.BaseDirectory}\\linshigxdwj.exe");
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WebClient_DownloadProgressChanged);
            }catch (Exception) { }
        }

        public long old;
        public long latest;
        public long speed = 0;
        public int ck = 0;
        public int twotimes = 0;
        public long received;
        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            received = e.BytesReceived;
            progressBar1.Value = (int)e.ProgressPercentage;
            label1.Text = $"下载更新中，请稍后。。。    进度：{e.ProgressPercentage}%\n已下载：{e.BytesReceived/1024}KB 总大小：{e.TotalBytesToReceive/1024}KB 速度：{speed}KB/S";
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 100, AW_VER_POSITIVE);
            try
            {
                if (File.Exists($"{Path.GetTempPath()}zxgjxnodeselection"))
                {
                    StreamReader wn = new StreamReader($"{Path.GetTempPath()}zxgjxnodeselection");
                    string whichnode = wn.ReadToEnd();
                    if (whichnode.Contains("raw.fastgit.org"))
                        label3.Text = "更新窗口（节点：日本东京）";
                    else if (whichnode.Contains("pd.zwc365.com")) 
                        label3.Text = "更新窗口（节点：中国香港）";
                    else if (whichnode.Contains("gh.xiu2.xyz"))
                        label3.Text = "更新窗口（节点：美国洛杉矶）";
                    else if (whichnode.Contains("ghproxy.com"))
                        label3.Text = "更新窗口（节点：国内1）";
                    else if (whichnode.Contains("gh.api.99988866.xyz"))
                        label3.Text = "更新窗口（节点：国内2）";
                }
            }catch(Exception) { }
            pictureBox2.Parent = this.pictureBox1;
            label1.Parent = this.pictureBox3;
            progressBar1.Parent = this.pictureBox3;
            pictureBox4.Parent = this.pictureBox3;
            pictureBox5.Parent = this.pictureBox4;
            label2.Parent = this.pictureBox5;
            label3.Parent = this.pictureBox6;
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            label1.Visible = true;
            progressBar1.Visible = true;
            Thread download = new Thread(new ThreadStart(downloadFromFastgit));
            download.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(progressBar1.Value == 100)
            {
                
                pictureBox4.Visible=true;
                label1.Visible=false;
                progressBar1.Visible=false;
                timer2.Enabled = true;
                timer1.Enabled = false;
            }
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            pictureBox5.Visible=true;
            timer3.Enabled=true;
            SoundPlayer sp=new SoundPlayer(在线工具箱.Properties.Resources.completedbgm);
            sp.Play();
            timer2.Enabled=false;
        }
        public int w = 291;
        private void timer3_Tick(object sender, EventArgs e)
        {

            if (w == -label2.Width)
                w = 291;
            else if (w == 0)
                w -= 1;
            else if (w != 0)
                w -= 1;
            label2.Location = new Point(w, 162);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            SetWindowRegion();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (ck == 0)
            {
                ck = 1;
                old = received;
            }
            else if (ck == 1)
            {
                ck = 0;
                latest = received;
            }
            twotimes++;
            if (twotimes == 2)
            {
                twotimes = 0;
                speed = ((latest - old) / 1204) * 2;
            }
        }
    }
}
