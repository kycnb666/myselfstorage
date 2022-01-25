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

namespace 窗体
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
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
        public static extern IntPtr GetF(); //获得本窗体的句柄
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetF(IntPtr hWnd); //设置此窗体为活动窗体
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        void downloadFromFastgit()
        {
            try
            {
                StreamReader sr = new StreamReader($"{Path.GetTempPath()}nodeselection");
                string node = sr.ReadToEnd();

                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                webClient.DownloadFile($"{node}notice", $"{Path.GetTempPath()}notice");

                StreamReader streamReader = new StreamReader($"{Path.GetTempPath()}notice");
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
                if (File.Exists($"{Path.GetTempPath()}nodeselection"))
                {
                    StreamReader wn = new StreamReader($"{Path.GetTempPath()}nodeselection");
                    string whichnode = wn.ReadToEnd();
                    if (whichnode.Contains("raw.fastgit.org"))
                        label5.Text = "Node:Tokyo";
                    else if (whichnode.Contains("pd.zwc365.com"))
                        label5.Text = "Node:HongKong";
                    else if (whichnode.Contains("gh.xiu2.xyz"))
                        label5.Text = "Node:Los Angeles";
                }
            }
            catch (Exception) { }
            FileInfo t = new FileInfo($"{AppDomain.CurrentDomain.BaseDirectory}{Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location)}");
            string title = t.CreationTime.ToString("F");
            string title2=t.LastAccessTime.ToString("F");
            label1.Text = $"上次更新的时间：{title}";
            label2.Text = $"          打开时间：{title2}";
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
    }
}
