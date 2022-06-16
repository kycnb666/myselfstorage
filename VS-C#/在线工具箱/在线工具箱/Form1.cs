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
using System.Drawing.Drawing2D;
using System.Net.NetworkInformation;

namespace 在线工具箱
{
    public partial class Form1 : Form
    {
        public Form1()
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
            FormPath = GetRoundedRectPath(rect, 25);
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
        public static extern IntPtr GetF(); //获得本在线工具箱的句柄
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetF(IntPtr hWnd); //设置此在线工具箱为活动在线工具箱

        public static void diaoyong(string x, string y)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = x;
            proc.StartInfo.Arguments = y;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Start();
            proc.Close();
        }
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int connectionDescription, int reservedValue);
        private bool IsConnected()
        {
            int I = 0;
            bool state = InternetGetConnectedState(out I, 0);
            return state;
        }
        void checkversion()
        {

            try
            {
                StreamReader getnode = new StreamReader($"{Path.GetTempPath()}zxgjxnodeselection");
                string node=getnode.ReadToEnd();

                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                webClient.DownloadFile($"{node}onlinetoolboxversion.v", $"{Path.GetTempPath()}onlinetoolboxversion.v");

                StreamReader streamReader = new StreamReader($"{Path.GetTempPath()}onlinetoolboxversion.v");
                string latestversion = streamReader.ReadToEnd();
                streamReader.Close();


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
                if(linshi.Length/1024 < 1740) { diaoyong("cmd.exe", $"/c del \"{AppDomain.CurrentDomain.BaseDirectory}linshigxdwj.exe\""); }
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
            new Form2().Show(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 50, AW_VER_POSITIVE);
            label36.Text = "在线工具箱  版本V" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            if (IsConnected() == true)
            {
                Thread checkinternet=new Thread(new ThreadStart(accessinternet));
                checkinternet.Start();
                try
                {
                    if (!File.Exists($"{Path.GetTempPath()}zxgjxnodeselection"))
                    {
                        FileStream fs = new FileStream($"{Path.GetTempPath()}zxgjxnodeselection", FileMode.Create);
                        StreamWriter streamWriter = new StreamWriter(fs);
                        streamWriter.Write("https://raw.fastgit.org/kycnb666/onlinetoolbox/main/%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1/");
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }
                catch (Exception) { }
                Thread download = new Thread(new ThreadStart(checkversion));
                download.Start();
            }
            else if(IsConnected() == false)
            {
                MessageBox.Show("此计算机没有联网，请检查你的网线或Wifi是否连接好\n\n无网络将无法使用此软件","当前设备未连接到任何网络",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
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
            new Form3().Show(this);
        }


        private void topwindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (topwindowToolStripMenuItem.Text != "取消顶置")
            {
                topwindowToolStripMenuItem.Text = "取消顶置";
                this.TopMost = true;
            }
            else
            {
                topwindowToolStripMenuItem.Text = "窗口顶置";
                this.TopMost= false;
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            new Form4().Show(this);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Form2().Show(this);
        }

        private void 网址1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://pd.zwc365.com/seturl/https://github.com/kycnb666/onlinetoolbox/blob/main/%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1/%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1.exe");
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Process.Start("https://raw.githubusercontents.com/kycnb666/onlinetoolbox/main/%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1/%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1.exe");
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Process.Start("https://raw.fastgit.org/kycnb666/onlinetoolbox/main/%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1/%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1.exe");
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Process.Start("https://gh.xiu2.xyz/https://github.com/kycnb666/onlinetoolbox/blob/main/%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1/%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1.exe");
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.rc1844.workers.dev/kycnb666/onlinetoolbox/raw/main/%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1/%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1.exe");
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Process.Start("https://raw.githubusercontent.com/kycnb666/onlinetoolbox/main/%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1/%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1.exe");
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream($"{Path.GetTempPath()}zxgjxnodeselection", FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fs);
                streamWriter.Write("https://raw.fastgit.org/kycnb666/onlinetoolbox/main/%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1/");
                streamWriter.Flush();
                streamWriter.Close();
                MessageBox.Show("获取数据的网络节点已成功替换为：\n\n\n日本东京", "替换成功，程序将使用此节点", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception) { MessageBox.Show("我刚刚走神了，请您再试一次吧\n\n（后台存在下载线程，请稍后再切换）", "哎呀，出了点小问题"); }
            
        }

        private void HongKongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream($"{Path.GetTempPath()}zxgjxnodeselection", FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fs);
                streamWriter.Write("https://pd.zwc365.com/seturl/https://github.com/kycnb666/onlinetoolbox/blob/main/%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1/");
                streamWriter.Flush();
                streamWriter.Close();
                MessageBox.Show("获取数据的网络节点已成功替换为：\n\n\n中国香港", "替换成功，程序将使用此节点", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception) { MessageBox.Show("我刚刚走神了，请您再试一次吧\n\n（后台存在下载线程，请稍后再切换）", "哎呀，出了点小问题"); }
            
        }

        private void LSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream($"{Path.GetTempPath()}zxgjxnodeselection", FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fs);
                streamWriter.Write("https://gh.xiu2.xyz/https://github.com/kycnb666/onlinetoolbox/blob/main/%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1/");
                streamWriter.Flush();
                streamWriter.Close();
                MessageBox.Show("获取数据的网络节点已成功替换为：\n\n\n美国洛杉矶", "替换成功，程序将使用此节点", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception) { MessageBox.Show("我刚刚走神了，请您再试一次吧\n\n（后台存在下载线程，请稍后再切换）", "哎呀，出了点小问题"); }
            
        }

        private void resumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists($"{Path.GetTempPath()}zxgjxnodeselection"))
                {
                    FileStream fs = new FileStream($"{Path.GetTempPath()}zxgjxnodeselection", FileMode.Create);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.Write("https://raw.fastgit.org/kycnb666/onlinetoolbox/main/%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1/");
                    streamWriter.Flush();
                    streamWriter.Close();
                    MessageBox.Show("已恢复默认配置", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else { }
            }
            catch (Exception) { MessageBox.Show("我刚刚走神了，请您再试一次吧\n\n（后台存在下载线程，请稍后再切换）", "哎呀，出了点小问题"); }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            SetWindowRegion();
        }

        private void label3_Click(object sender, EventArgs e)
        { }

        private void label4_Click(object sender, EventArgs e)
        {
            panel4.Focus();
            label4.BackColor = Color.FromArgb(192,255,255);
            label6.BackColor = Color.White;
            label5.BackColor = Color.White;
            label45.BackColor = Color.White;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            panel5.Focus();
            label5.BackColor = Color.FromArgb(192,192,255);
            label6.BackColor = Color.White;
            label4.BackColor = Color.White;
            label45.BackColor = Color.White;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            panel6.Focus();
            label6.BackColor = Color.FromArgb(255,192,255);
            label4.BackColor = Color.White;
            label5.BackColor = Color.White;
            label45.BackColor = Color.White;
        }
        void startdownload(string softname,string downloadlink,string shortname)
        {
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}{softname}"))
                {
                    Form5 f = new Form5($"{shortname}", $"{downloadlink}");
                    f.Show(this);
                }
                else { Process.Start($"{Path.GetTempPath()}{softname}"); }
            }
            catch (Exception) { }
        }
        private void pictureBox9_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox9.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox9_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox9.BorderStyle = BorderStyle.None;
            startdownload("AIDA64.exe", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/AIDA64.exe", "AIDA64");
        }

        private void pictureBox9_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            diaoyong("cmd.exe", "/c del %temp%\\*.exe /q");
            MessageBox.Show("清除成功");
        }

        private void pictureBox10_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox10.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox10_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox10.BorderStyle= BorderStyle.None;
            startdownload("cpuz_x64.exe", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/cpuz_x64.exe", "cpuz_x64");
        }

        private void pictureBox11_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox11.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox11_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox11.BorderStyle= BorderStyle.None;
            startdownload("cpuz_x32.exe", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/cpuz_x32.exe", "cpuz_x32");
        }

        private void pictureBox12_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox12.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox12_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox12.BorderStyle= BorderStyle.None;
            startdownload("GPU-Z.2.44.0.exe", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/GPU-Z.2.44.0.exe", "GPU-Z.2.44.0");
        }

        private void pictureBox13_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox13.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox13_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox13.BorderStyle= BorderStyle.None;
            startdownload("SSD-Z.exe", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/SSD-Z.exe", "SSD-Z");
        }

        private void pictureBox14_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox14.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox14_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox14.BorderStyle= BorderStyle.None;
            startdownload("FurMark.exe", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/FurMark.exe", "FurMark");
        }

        private void pictureBox15_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox15.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox15_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox15.BorderStyle = BorderStyle.None;
            startdownload("ASSSDBenchmark.exe", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/ASSSDBenchmark.exe", "ASSSDBenchmark");
        }

        private void pictureBox16_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox16.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox16_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox16.BorderStyle = BorderStyle.None;
            startdownload("Sunlight内存整理.exe", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/Sunlight%E5%86%85%E5%AD%98%E6%95%B4%E7%90%86.exe", "Sunlight内存整理");
        }

        private void pictureBox17_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox17.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox17_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox17.BorderStyle= BorderStyle.None;
            startdownload("xiangqi.exe", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/xiangqi.exe", "xiangqi");
        }

        private void pictureBox18_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox18.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox18_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox18.BorderStyle= BorderStyle.None;
            startdownload("Defraggler.exe", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/Defraggler.exe", "Defraggler");
        }

        private void pictureBox19_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox19.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox19_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox19.BorderStyle= BorderStyle.None;
            startdownload("DisplayX.exe", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/DisplayX.exe", "DisplayX");
        }

        private void pictureBox20_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox20.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox20_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox20.BorderStyle= BorderStyle.None;
            startdownload("KeyboardTestUtility.exe", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/KeyboardTestUtility.exe", "KeyboardTestUtility");
        }

        private void pictureBox21_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox21.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox21_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox21.BorderStyle= BorderStyle.None;
            startdownload("BatteryInfoView.exe", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/BatteryInfoView.exe", "BatteryInfoView");
        }

        private void pictureBox22_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox22.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox22_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox22.BorderStyle = BorderStyle.None;
            startdownload("bandicam.exe", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/bandicam.exe", "bandicam");
        }

        private void pictureBox23_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox23.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox23_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox23.BorderStyle = BorderStyle.None;
            startdownload("ScreenToGif.exe", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/ScreenToGif.exe", "ScreenToGif");
        }

        private void pictureBox24_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox24.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox24_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox24.BorderStyle= BorderStyle.None;
            startdownload("geek.exe", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/geek.exe", "geek");
        }

        private void pictureBox25_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox25.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox25_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox25.BorderStyle= BorderStyle.None;
            startdownload("DiskGenius.exe", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/DiskGenius.exe", "DiskGenius");
        }

        private void pictureBox26_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox26.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox26_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox26.BorderStyle= BorderStyle.None;
            startdownload("Everything.exe", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/Everything.exe", "Everything");
        }

        private void pictureBox27_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox27.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox27_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox27.BorderStyle= BorderStyle.None;
            startdownload("procexp.exe", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/procexp.exe", "procexp");
        }

        private void pictureBox28_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox28.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox28_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox28.BorderStyle= BorderStyle.None;
            startdownload("SpaceSniffer.exe", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/SpaceSniffer.exe", "SpaceSniffer");
        }

        private void pictureBox29_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox29.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox29_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox29.BorderStyle= BorderStyle.None;
            startdownload("dxrepair.exe", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/dxrepair.exe", "dxrepair");
        }

        private void pictureBox30_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox30.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox30_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox30.BorderStyle= BorderStyle.None;
            startdownload("win10activator.exe", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/win10activator.exe", "win10activator");
        }

        private void pictureBox31_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox31.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox31_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox31.BorderStyle= BorderStyle.None;
            startdownload("wub.exe", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/wub.exe", "wub");
        }

        private void pictureBox32_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox32.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pictureBox32_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox32.BorderStyle= BorderStyle.None;
            Process.Start("cmd.exe", "/k color 70 & mode con:cols=30 lines=5 & title=查询结果 & @echo off & cls & curl -L ip.tool.lu");
        }

        private void pictureBox33_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox33.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox33_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox33.BorderStyle= BorderStyle.None;
            startdownload("Dism++x64.exe", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/Dism++x64.exe", "Dism++x64");
        }

        private void pictureBox34_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox34.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox34_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox34.BorderStyle= BorderStyle.None;
            startdownload("Dism++x86.exe", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/Dism++x86.exe", "Dism++x86");
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            new Form6().Show(this);
        }

        private void pictureBox35_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox35.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox35_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox35.BorderStyle= BorderStyle.None;
            startdownload("DiskInfo.exe", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/DiskInfo.exe", "DiskInfo");
        }

        private void pictureBox36_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox36.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox36_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox36.BorderStyle= BorderStyle.None;
            startdownload("HWiNFO64.exe", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/HWiNFO64.exe", "HWiNFO64");
        }

        private void pictureBox37_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox37.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox37_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox37.BorderStyle= BorderStyle.None;
            startdownload("HWiNFO32.exe", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/HWiNFO32.exe", "HWiNFO32");
        }

        private void pictureBox38_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox38.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox38_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox38.BorderStyle= BorderStyle.None;
            startdownload("HWMonitor_x64.exe", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/HWMonitor_x64.exe", "HWMonitor_x64");
        }

        private void pictureBox39_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox39.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox39_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox39.BorderStyle= BorderStyle.None;
            startdownload("HWMonitor_x32.exe", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/HWMonitor_x32.exe", "HWMonitor_x32");
        }

        private void pictureBox40_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox40.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox40_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox40.BorderStyle= BorderStyle.None;
            startdownload("FINALDATA.exe", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/FINALDATA.exe", "FINALDATA");
        }

        private void label45_Click(object sender, EventArgs e)
        {
            panel7.Focus();
            label45.BackColor = Color.FromArgb(255, 192, 192);
            label4.BackColor = Color.White;
            label5.BackColor = Color.White;
            label6.BackColor = Color.White;
        }

        private void pictureBox41_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox41.BorderStyle = BorderStyle.Fixed3D; 
        }

        private void pictureBox41_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox41.BorderStyle= BorderStyle.None;
            startdownload("RAMMap.exe", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/RAMMap.exe", "RAMMap");
        }

        private void pictureBox43_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox43.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox43_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox43.BorderStyle = BorderStyle.None;
            startdownload("recuva.exe", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/recuva.exe", "recuva");
        }

        private void pictureBox44_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox44.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox44_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox44.BorderStyle = BorderStyle.None;
            Process.Start("https://tool.lu/");
        }

        private void pictureBox45_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox45.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox45_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox45.BorderStyle = BorderStyle.None;
            Process.Start("https://tools.miku.ac/");
        }

        private void pictureBox46_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox46.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox46_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox46.BorderStyle= BorderStyle.None;
            Process.Start("http://tool.ci/");
        }

        private void pictureBox47_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox47.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox47_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox47.BorderStyle= BorderStyle.None;
            Process.Start("https://www.toolfk.com/");
        }

        private void pictureBox48_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox48.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox48_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox48.BorderStyle= BorderStyle.None;
            Process.Start("http://tool.mkblog.cn/");
        }

        private void pictureBox49_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox49.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox49_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox49.BorderStyle= BorderStyle.None;
            Process.Start("https://shadiao.app/#");
        }

        private void pictureBox50_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox50.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox50_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox50.BorderStyle= BorderStyle.None;
            startdownload("memtest.exe", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/memtest.exe", "memtest");
        }

        private void pictureBox51_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox51.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox51_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox51.BorderStyle= BorderStyle.None;
            startdownload("ChipGenius.exe", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/ChipGenius.exe", "ChipGenius");
        }

        private void pictureBox52_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox52.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox52_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox52.BorderStyle= BorderStyle.None;
            startdownload("WindowsISODownloader.exe", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/WindowsISODownloader.exe", "WindowsISODownloader");
        }

        private void pictureBox54_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox54.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox54_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox54.BorderStyle = BorderStyle.None;
            startdownload("Pointofix.exe", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/Pointofix.exe", "Pointofix");
        }

        private void pictureBox53_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox53.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox53_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox53.BorderStyle= BorderStyle.None;
            Process.Start("https://msdn.itellyou.cn/");
        }

        private void pictureBox55_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox55.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox55_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox55.BorderStyle= BorderStyle.None;
            Process.Start("https://www.upe.net/");
        }

        private void pictureBox56_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox56.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox56_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox56.BorderStyle= BorderStyle.None;
            Process.Start("https://www.wepe.com.cn/");
        }

        private void pictureBox57_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox57.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox57_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox57.BorderStyle= BorderStyle.None;
            Process.Start("https://www.ventoy.net/cn/index.html");
        }

        private void pictureBox58_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox58.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox58_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox58.BorderStyle= BorderStyle.None;
            Process.Start("https://rufus.ie/zh/");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.huorong.cn/person5.html");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://potplayer.tv/?lang=zh_CN");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://search.ahnu.cf/intl/zh-CN/chrome/");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.microsoftedgeinsider.com/zh-cn/");
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://pan.baidu.com/s/10-nweuFfkGZGA4ahbrQzsA");
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://wwi.lanzouo.com/ib9Xuxbmbli");
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://sparanoid.com/lab/7z/ ");
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.advancedsystemcare.cn/");
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://pan.baidu.com/s/13tW9aJAWhw83x2wB3jYk8g");
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://pan.baidu.com/s/1DHy8KREPP7aagdv99Iw9Gg#list/path=%2F");
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://free.lanzoux.com/b0cpu1guf");
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.xinshuru.com/index.html?p=win");
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.pcfreetime.com/formatfactory/CN/index.html");
        }

        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://wwi.lanzoui.com/i6twcv9puje");
        }

        private void linkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/lyswhut/lx-music-desktop/releases");
        }

        private void linkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://wwe.lanzoup.com/isWetzja2bc");
        }

        private void linkLabel17_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://wwe.lanzoup.com/imfxRz4unxa");
        }

        private void label36_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }

        private void 运行检查工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form7().Show(this);
        }

        private void pictureBox59_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox59.BorderStyle=BorderStyle.Fixed3D;
        }

        private void pictureBox59_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox59.BorderStyle = BorderStyle.None;
            startdownload("chj.exe", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/chj.exe", "chj");
        }

        private void pictureBox60_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox60.BorderStyle=BorderStyle.Fixed3D;
        }

        private void pictureBox60_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox60.BorderStyle = BorderStyle.None;
            startdownload("hfdjjc.exe", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/hfdjjc.exe", "hfdjjc");
        }

        private void pictureBox61_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox61.BorderStyle=BorderStyle.Fixed3D;
        }

        private void pictureBox61_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox61.BorderStyle = BorderStyle.None;
            startdownload("wbjmjm.exe", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/wbjmjm.exe", "wbjmjm");
        }

        private void pictureBox62_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox62.BorderStyle=BorderStyle.Fixed3D;
        }

        private void pictureBox62_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox62.BorderStyle = BorderStyle.None;
            startdownload("Victoriahhb.exe", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/Victoriahhb.exe", "Victoriahhb");
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            Process.Start("https://kycnb666.github.io/zxgjx.html");
        }

        private void pictureBox63_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox63.BorderStyle=BorderStyle.Fixed3D;
        }

        private void pictureBox63_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox63.BorderStyle = BorderStyle.None;
            startdownload("禁用指定程序.exe", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/%E7%A6%81%E7%94%A8%E6%8C%87%E5%AE%9A%E7%A8%8B%E5%BA%8F.exe", "禁用指定程序");
        }

        private void linkLabel18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://wwt.lanzouy.com/irpcr05d3iqb");
        }

        private void 网址7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://ghproxy.com/https://raw.githubusercontent.com/kycnb666/onlinetoolbox/main/%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1/%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1.exe");
        }

        private void 网址8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://gh.api.99988866.xyz/https://raw.githubusercontent.com/kycnb666/onlinetoolbox/main/%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1/%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1.exe");
        }

        private void 节点四国内1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream($"{Path.GetTempPath()}zxgjxnodeselection", FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fs);
                streamWriter.Write("https://ghproxy.com/https://github.com/kycnb666/onlinetoolbox/blob/main/%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1/");
                streamWriter.Flush();
                streamWriter.Close();
                MessageBox.Show("获取数据的网络节点已成功替换为：\n\n\n国内1", "替换成功，程序将使用此节点", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception) { MessageBox.Show("我刚刚走神了，请您再试一次吧\n\n（后台存在下载线程，请稍后再切换）", "哎呀，出了点小问题"); }
            
        }

        private void 节点五国内2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream($"{Path.GetTempPath()}zxgjxnodeselection", FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fs);
                streamWriter.Write("https://gh.api.99988866.xyz/https://raw.githubusercontent.com/kycnb666/onlinetoolbox/main/%E5%9C%A8%E7%BA%BF%E5%B7%A5%E5%85%B7%E7%AE%B1/");
                streamWriter.Flush();
                streamWriter.Close();
                MessageBox.Show("获取数据的网络节点已成功替换为：\n\n\n国内2", "替换成功，程序将使用此节点", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception) { MessageBox.Show("我刚刚走神了，请您再试一次吧\n\n（后台存在下载线程，请稍后再切换）", "哎呀，出了点小问题"); }
            
        }

        private void linkLabel19_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://wwc.lanzouf.com/iNC8V05hgpnc");
        }

        private void pictureBox64_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox64.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox64_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox64.BorderStyle = BorderStyle.None;
            startdownload("微软语音合成.exe", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/%E5%BE%AE%E8%BD%AF%E8%AF%AD%E9%9F%B3%E5%90%88%E6%88%90%E5%8A%A9%E6%89%8B.exe","微软语音合成");
        }

        private void pictureBox65_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox65.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox65_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox65.BorderStyle= BorderStyle.None;
            startdownload("驱动精灵_单文件版.exe", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/%E9%A9%B1%E5%8A%A8%E7%B2%BE%E7%81%B5_%E5%8D%95%E6%96%87%E4%BB%B6%E7%89%88.exe", "驱动精灵");
        }

        private void linkLabel20_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://wwe.lanzouf.com/ifEYP01f2szc");
        }

        private void linkLabel21_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://wwc.lanzouf.com/iVWI4052jg6j");
        }

        private void linkLabel22_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.magiceraser.io/");
        }

        private void pictureBox66_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox66.BorderStyle= BorderStyle.Fixed3D;
        }

        private void pictureBox66_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox66.BorderStyle = BorderStyle.None;
            startdownload("一键开启关闭WindowsDefender.exe", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/%E4%B8%80%E9%94%AE%E5%BC%80%E5%90%AF%E5%85%B3%E9%97%ADWindowsDefender.exe", "一键开启关闭WindowsDefender");
        }

        private void timer6_Tick(object sender, EventArgs e)
        {


            if (PingIpOrDomainName("www.baidu.com") == false)
                MessageBox.Show("检测到无法访问互联网，请检查你的网络设置", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("");
            
            timer6.Enabled = false;
        }
        void accessinternet()
        {
            if (PingIpOrDomainName("www.baidu.com") == false)
                MessageBox.Show("检测到无法访问互联网，请检查你的网络设置", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static bool PingIpOrDomainName(string strIpOrDName)
        {
            try
            {
                Ping objPingSender = new Ping();
                PingOptions objPinOptions = new PingOptions();
                objPinOptions.DontFragment = true;
                string data = "";
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int intTimeout = 120;
                PingReply objPinReply = objPingSender.Send(strIpOrDName, intTimeout, buffer, objPinOptions);
                string strInfo = objPinReply.Status.ToString();
                if (strInfo == "Success")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void linkLabel23_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://wwc.lanzouf.com/iJhd00604lfc");
        }
    }
}
