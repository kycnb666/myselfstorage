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
                webClient.DownloadFile("https://gitee.com/kycnb666/softwarerelease/raw/master/software%20release/%E6%B5%8B%E8%AF%95/version.v", $"{AppDomain.CurrentDomain.BaseDirectory}\\version.v");
                
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


            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            
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
                diaoyong("cmd.exe", $"/c ren \"{AppDomain.CurrentDomain.BaseDirectory}{Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\" \"旧版文件请手动删除.exe\"");
                diaoyong("cmd.exe", $"/c timeout /t 1 /nobreak & ren \"{AppDomain.CurrentDomain.BaseDirectory}linshigxdwj.exe\" \"{Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\"");
                diaoyong("cmd.exe", $"/c timeout /t 2 /nobreak & del \"{AppDomain.CurrentDomain.BaseDirectory}旧版文件请手动删除.exe\"");
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
            new Form2().ShowDialog(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                webClient.DownloadFile("https://gitee.com/kycnb666/softwarerelease/raw/master/software%20release/%E7%AA%97%E4%BD%93/version.v", $"{AppDomain.CurrentDomain.BaseDirectory}\\version.v");

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
            }catch (Exception) { }
            
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
        {
            new Form3().ShowDialog(this);
        }
    }
}
