using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;


namespace 窗体
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        public static class ClearMemoryInfo
        {
            [DllImport("kernel32.dll")]
            private static extern bool SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);


            /// <summary>
            /// 强制清理内存
            /// </summary>
            public static void FlushMemory()
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
                //System.Diagnostics.Process.GetCurrentProcess().MinWorkingSet = new System.IntPtr(5);
            }
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
        public static void diaoyong(string x, string y)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = x;
            proc.StartInfo.Arguments = y;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Start();
            proc.Close();
        }
        void checkversion()
        {

            try
            {
                
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                webClient.DownloadFile("https://raw.fastgit.org/kycnb666/softwarerelease/main/software%20release/%E7%AA%97%E4%BD%93/version.v", $"{Path.GetTempPath()}version.v");

                StreamReader streamReader = new StreamReader($"{Path.GetTempPath()}version.v");
                string latestversion = streamReader.ReadToEnd();
                streamReader.Close();


                FileInfo f = new FileInfo($"{Path.GetTempPath()}version.v");
                f.Delete();
                string thisversion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

                if (thisversion != latestversion)
                {
                    timer3.Enabled = false;
                }
            }
            catch (Exception) { }


        }

        public int hh = 0;
        public int ww = 0;
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            if (File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}linshigxdwj.exe"))
            {
                FileInfo linshi = new FileInfo($"{AppDomain.CurrentDomain.BaseDirectory}linshigxdwj.exe");
                if(linshi.Length/1024 < 678) { diaoyong("cmd.exe", $"/c del \"{AppDomain.CurrentDomain.BaseDirectory}linshigxdwj.exe\""); }
                else
                {
                    diaoyong("cmd.exe", $"/c ren \"{AppDomain.CurrentDomain.BaseDirectory}{Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\" \"旧版文件请手动删除.exe\"");
                    diaoyong("cmd.exe", $"/c timeout /t 1 /nobreak & ren \"{AppDomain.CurrentDomain.BaseDirectory}linshigxdwj.exe\" \"{Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\"");
                    diaoyong("cmd.exe", $"/c timeout /t 2 /nobreak & del \"{AppDomain.CurrentDomain.BaseDirectory}旧版文件请手动删除.exe\"");
                }
            }
            Environment.Exit(0);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {}

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.BorderStyle= BorderStyle.Fixed3D;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.None;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (ww != panel1.Width)
                ww += 1;
            else
                ww = -label1.Width;
            label1.Location = new Point(ww, 36);
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            label2.BorderStyle= BorderStyle.Fixed3D;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.BorderStyle = BorderStyle.None;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 50, AW_VER_POSITIVE);
            Thread download = new Thread(new ThreadStart(checkversion));
            download.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
           
            if (File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}version.v"))
            {
                try
                {

                    StreamReader streamReader = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}version.v");
                    string latestversion = streamReader.ReadToEnd();
                    streamReader.Close();


                    FileInfo f = new FileInfo($"{AppDomain.CurrentDomain.BaseDirectory}version.v");
                    f.Delete();
                    string thisversion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

                    if (thisversion != latestversion)
                    {
                        pictureBox2.Visible = true;
                        label1.Visible = true;
                    }
                    timer2.Enabled = false;
                }
                catch (Exception) { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        { }
        
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (timer3.Enabled == false)
            {
                pictureBox2.Visible = true;
                label1.Visible = true;
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            ClearMemoryInfo.FlushMemory();
        }

        private void checkversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }

        private void seeupdatetimeandnoticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form4().Show();
        }
    }
}
