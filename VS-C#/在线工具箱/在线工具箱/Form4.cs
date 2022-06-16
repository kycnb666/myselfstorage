using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace 在线工具箱
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        /// <summary>
        /// 设置在线工具箱的Region
        /// </summary>
        public void SetWindowRegion()
        {
            GraphicsPath FormPath;
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            FormPath = GetRoundedRectPath(rect, 20);
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
                string node = sr.ReadToEnd();

                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                webClient.DownloadFile($"{node}onlinetoolboxnotice", $"{Path.GetTempPath()}onlinetoolboxnotice");

                StreamReader streamReader = new StreamReader($"{Path.GetTempPath()}onlinetoolboxnotice");
                textBox1.Text  = streamReader.ReadToEnd();
                
                streamReader.Close();
            }
            catch (Exception) { }

        }
        private void Form4_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 100, AW_VER_POSITIVE);
            label4.Parent = pictureBox1;
            pictureBox5.Parent = pictureBox1;
            try
            {
                if (File.Exists($"{Path.GetTempPath()}zxgjxnodeselection"))
                {
                    StreamReader wn = new StreamReader($"{Path.GetTempPath()}zxgjxnodeselection");
                    string whichnode = wn.ReadToEnd();
                    if (whichnode.Contains("raw.fastgit.org"))
                        label5.Text = "Node:Tokyo";
                    else if (whichnode.Contains("pd.zwc365.com"))
                        label5.Text = "Node:HongKong";
                    else if (whichnode.Contains("gh.xiu2.xyz"))
                        label5.Text = "Node:Los Angeles";
                    else if (whichnode.Contains("ghproxy.com"))
                        label5.Text = "Node:Domestic1";
                    else if (whichnode.Contains("gh.api.99988866.xyz"))
                        label5.Text = "Node:Domestic2";
                }
            }
            catch (Exception) { }
            FileInfo t = new FileInfo($"{AppDomain.CurrentDomain.BaseDirectory}{Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location)}");
            string title = t.CreationTime.ToString("F");
            string title2=t.LastAccessTime.ToString("F");
            label1.Text = $"上次更新的时间：{title}";
            label2.Text = $"          打开时间：{title2}";
            label6.Text = "当前版本："+ System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            try
            {
                StreamReader streamReader = new StreamReader($"{Path.GetTempPath()}onlinetoolboxversion.v");
                string latestversion = streamReader.ReadToEnd();
                streamReader.Close();
                label7.Text = $"最新版本：{latestversion}";
                if (System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() == latestversion)
                    label8.Text = "建议：无需更新";
                else if (System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() != latestversion)
                    label8.Text = "建议：需要更新";
            }catch (Exception) { }
            Thread download = new Thread(new ThreadStart(downloadFromFastgit));
            download.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Text = "正在获取中。。。";
            else
            { }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }

        private void Form4_Resize(object sender, EventArgs e)
        {
            SetWindowRegion();
        }
    }
}
