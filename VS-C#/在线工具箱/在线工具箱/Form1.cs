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


                FileInfo f = new FileInfo($"{Path.GetTempPath()}onlinetoolboxversion.v");
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
                if(linshi.Length/1024 < 1519) { diaoyong("cmd.exe", $"/c del \"{AppDomain.CurrentDomain.BaseDirectory}linshigxdwj.exe\""); }
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
            }catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            MessageBox.Show("获取数据的网络节点已成功替换为：\n\n\n日本东京","替换成功，程序将使用此节点",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            MessageBox.Show("获取数据的网络节点已成功替换为：\n\n\n中国香港", "替换成功，程序将使用此节点", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            MessageBox.Show("获取数据的网络节点已成功替换为：\n\n\n美国洛杉矶", "替换成功，程序将使用此节点", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            catch (Exception) { }
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
        }

        private void label5_Click(object sender, EventArgs e)
        {
            panel5.Focus();
            label5.BackColor = Color.FromArgb(192,192,255);
            label6.BackColor = Color.White;
            label4.BackColor = Color.White;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            panel6.Focus();
            label6.BackColor = Color.FromArgb(255,192,255);
            label4.BackColor = Color.White;
            label5.BackColor = Color.White;
        }

        private void pictureBox9_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox9.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox9_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox9.BorderStyle = BorderStyle.None;
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}AIDA64.exe"))
                {
                    Form5 f = new Form5("AIDA64", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/AIDA64.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}AIDA64.exe"); }
            }catch (Exception) { }
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
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}cpuz_x64.exe"))
                {
                    Form5 f = new Form5("cpuz_x64", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/cpuz_x64.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}cpuz_x64.exe"); }
            }
            catch (Exception) { }
        }

        private void pictureBox11_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox11.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox11_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox11.BorderStyle= BorderStyle.None;
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}cpuz_x32.exe"))
                {
                    Form5 f = new Form5("cpuz_x32", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/cpuz_x32.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}cpuz_x32.exe"); }
            }
            catch (Exception) { }
        }

        private void pictureBox12_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox12.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox12_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox12.BorderStyle= BorderStyle.None;
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}GPU-Z.2.44.0.exe"))
                {
                    Form5 f = new Form5("GPU-Z.2.44.0", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/GPU-Z.2.44.0.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}GPU-Z.2.44.0.exe"); }
            }
            catch (Exception) { }
        }

        private void pictureBox13_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox13.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox13_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox13.BorderStyle= BorderStyle.None;
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}SSD-Z.exe"))
                {
                    Form5 f = new Form5("SSD-Z", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/SSD-Z.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}SSD-Z.exe"); }
            }
            catch (Exception) { }
        }

        private void pictureBox14_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox14.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox14_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox14.BorderStyle= BorderStyle.None;
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}FurMark.exe"))
                {
                    Form5 f = new Form5("FurMark", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/FurMark.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}FurMark.exe"); }
            }
            catch (Exception) { }
        }

        private void pictureBox15_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox15.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox15_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox15.BorderStyle = BorderStyle.None;
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}ASSSDBenchmark.exe"))
                {
                    Form5 f = new Form5("ASSSDBenchmark", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/ASSSDBenchmark.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}ASSSDBenchmark.exe"); }
            }
            catch (Exception) { }
        }

        private void pictureBox16_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox16.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox16_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox16.BorderStyle = BorderStyle.None;
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}Sunlight内存整理.exe"))
                {
                    Form5 f = new Form5("Sunlight内存整理", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/Sunlight%E5%86%85%E5%AD%98%E6%95%B4%E7%90%86.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}Sunlight内存整理.exe"); }
            }
            catch (Exception) { }
        }

        private void pictureBox17_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox17.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox17_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox17.BorderStyle= BorderStyle.None;
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}xiangqi.exe"))
                {
                    Form5 f = new Form5("xiangqi", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/xiangqi.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}xiangqi.exe"); }
            }
            catch (Exception) { }
        }

        private void pictureBox18_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox18.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox18_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox18.BorderStyle= BorderStyle.None;
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}Defraggler.exe"))
                {
                    Form5 f = new Form5("Defraggler", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/Defraggler.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}Defraggler.exe"); }
            }
            catch (Exception) { }
        }

        private void pictureBox19_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox19.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox19_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox19.BorderStyle= BorderStyle.None;
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}DisplayX.exe"))
                {
                    Form5 f = new Form5("DisplayX", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/DisplayX.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}DisplayX.exe"); }
            }
            catch (Exception) { }
        }

        private void pictureBox20_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox20.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox20_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox20.BorderStyle= BorderStyle.None;
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}KeyboardTestUtility.exe"))
                {
                    Form5 f = new Form5("KeyboardTestUtility", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/KeyboardTestUtility.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}KeyboardTestUtility.exe"); }
            }
            catch (Exception) { }
        }

        private void pictureBox21_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox21.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox21_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox21.BorderStyle= BorderStyle.None;
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}BatteryInfoView.exe"))
                {
                    Form5 f = new Form5("BatteryInfoView", "%E7%A1%AC%E4%BB%B6%E5%B7%A5%E5%85%B7/BatteryInfoView.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}BatteryInfoView.exe"); }
            }
            catch (Exception) { }
        }

        private void pictureBox22_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox22.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox22_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox22.BorderStyle = BorderStyle.None;
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}bandicam.exe"))
                {
                    Form5 f = new Form5("bandicam", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/bandicam.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}bandicam.exe"); }
            }
            catch (Exception) { }
        }

        private void pictureBox23_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox23.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox23_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox23.BorderStyle = BorderStyle.None;
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}ScreenToGif.exe"))
                {
                    Form5 f = new Form5("ScreenToGif", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/ScreenToGif.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}ScreenToGif.exe"); }
            }
            catch (Exception) { }
        }

        private void pictureBox24_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox24.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox24_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox24.BorderStyle= BorderStyle.None;
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}geek.exe"))
                {
                    Form5 f = new Form5("geek", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/geek.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}geek.exe"); }
            }
            catch (Exception) { }
        }

        private void pictureBox25_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox25.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox25_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox25.BorderStyle= BorderStyle.None;
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}DiskGenius.exe"))
                {
                    Form5 f = new Form5("DiskGenius", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/DiskGenius.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}DiskGenius.exe"); }
            }
            catch (Exception) { }
        }

        private void pictureBox26_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox26.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox26_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox26.BorderStyle= BorderStyle.None;
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}Everything.exe"))
                {
                    Form5 f = new Form5("Everything", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/Everything.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}Everything.exe"); }
            }
            catch (Exception) { }
        }

        private void pictureBox27_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox27.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox27_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox27.BorderStyle= BorderStyle.None;
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}procexp.exe"))
                {
                    Form5 f = new Form5("procexp", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/procexp.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}procexp.exe"); }
            }
            catch (Exception) { }
        }

        private void pictureBox28_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox28.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox28_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox28.BorderStyle= BorderStyle.None;
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}SpaceSniffer.exe"))
                {
                    Form5 f = new Form5("SpaceSniffer", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/SpaceSniffer.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}SpaceSniffer.exe"); }
            }
            catch (Exception) { }
        }

        private void pictureBox29_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox29.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox29_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox29.BorderStyle= BorderStyle.None;
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}dxrepair.exe"))
                {
                    Form5 f = new Form5("dxrepair", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/dxrepair.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}dxrepair.exe"); }
            }
            catch (Exception) { }
        }

        private void pictureBox30_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox30.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox30_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox30.BorderStyle= BorderStyle.None;
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}win10activator.exe"))
                {
                    Form5 f = new Form5("win10activator", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/win10activator.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}win10activator.exe"); }
            }
            catch (Exception) { }
        }

        private void pictureBox31_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox31.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox31_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox31.BorderStyle= BorderStyle.None;
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}wub.exe"))
                {
                    Form5 f = new Form5("wub", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/wub.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}wub.exe"); }
            }
            catch (Exception) { }
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
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}Dism++x64.exe"))
                {
                    Form5 f = new Form5("Dism++x64", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/Dism++x64.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}Dism++x64.exe"); }
            }
            catch (Exception) { }
        }

        private void pictureBox34_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox34.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox34_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox34.BorderStyle= BorderStyle.None;
            try
            {
                if (!File.Exists($"{Path.GetTempPath()}Dism++x86.exe"))
                {
                    Form5 f = new Form5("Dism++x86", "%E7%B3%BB%E7%BB%9F%E4%B8%8E%E5%AE%9E%E7%94%A8%E5%B7%A5%E5%85%B7/Dism++x86.exe");
                    f.ShowDialog(this);
                }
                else { Process.Start($"{Path.GetTempPath()}Dism++x86.exe"); }
            }
            catch (Exception) { }
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            new Form6().Show(this);
        }
    }
}
