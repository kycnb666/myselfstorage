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
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace 在线工具箱
{
    public partial class Form5 : Form
    {
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
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "GetForegroundWindow", CharSet = System.Runtime.InteropServices.CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetF(); 
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetF(IntPtr hWnd); 
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public static void diaoyong(string x, string y)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = x;
            proc.StartInfo.Arguments = y;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Start();
            proc.Close();
        }
        public Form5(string toolname,string downloadlink)
        {
            InitializeComponent();
            Thread download = new Thread(()=>downloadFromFastgit(toolname,downloadlink));
            download.Start();
            try
            {
                FileStream fs = new FileStream($"{Path.GetTempPath()}zxgjxnamesave", FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fs);
                streamWriter.Write($"{toolname}");
                streamWriter.Flush();
                streamWriter.Close();
            }
            catch(Exception) { }
        }
        void downloadFromFastgit(string ToolName,string DownlaodLink)
        {
            try
            {
                label1.Text = $"正在下载{ToolName}，请稍后。。。";
                StreamReader sr = new StreamReader($"{Path.GetTempPath()}zxgjxnodeselection");
                string node = sr.ReadToEnd();
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                webClient.DownloadFileAsync(new Uri($"{node}{DownlaodLink}"), $"{Path.GetTempPath()}\\{ToolName}.exe");
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WebClient_DownloadProgressChanged);
                
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
        }
        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                progressBar1.Value = (int)e.ProgressPercentage;
                label2.Text = $"进度：{e.ProgressPercentage}%\n已下载：{e.BytesReceived / 1024}KB   总大小：{e.TotalBytesToReceive / 1024}KB";
            }
            catch (Exception) { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (progressBar1.Value == 100)
                {
                    StreamReader sr = new StreamReader($"{Path.GetTempPath()}zxgjxnamesave");
                    string name = sr.ReadToEnd();
                    label1.Text = $"{name}下载完成！等待工具启动。。。";
                    timer1.Enabled = false;

                    Process.Start($"{Path.GetTempPath()}{name}.exe");


                    this.Close();
                }
            }
            catch (Exception) {}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader($"{Path.GetTempPath()}zxgjxnamesave");
                string name = sr.ReadToEnd();
                FileInfo file = new FileInfo($"{Path.GetTempPath()}{name}");
                file.Delete();
                diaoyong("cmd.exe", $"/c timeout /t 1 /nobreak & del %temp%\\{name}.exe");
                this.Close();
            }catch (Exception) { }
        }

        private void Form5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AW_CENTER);
            try
            {
                if (File.Exists($"{Path.GetTempPath()}zxgjxnodeselection"))
                {
                    StreamReader wn = new StreamReader($"{Path.GetTempPath()}zxgjxnodeselection");
                    string whichnode = wn.ReadToEnd();
                    if (whichnode.Contains("raw.fastgit.org"))
                        label3.Text = "节点：日本东京";
                    else if (whichnode.Contains("pd.zwc365.com"))
                        label3.Text = "节点：中国香港";
                    else if (whichnode.Contains("gh.xiu2.xyz"))
                        label3.Text = "节点：美国洛杉矶";
                }
            }
            catch (Exception) { }
        }

        private void Form5_Resize(object sender, EventArgs e)
        {
            SetWindowRegion();
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }

        private void progressBar1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AW_HIDE | AW_CENTER);
        }
    }
}
