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
using System.IO;
using System.Diagnostics;
using System.Web;
using System.Threading;


namespace 联网更新文件
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

        void DownloadFileFromGitHub()
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                webClient.DownloadFile("https://github.com/kycnb666/softwarerelease/raw/main/software%20release/%E8%81%94%E7%BD%91%E6%9B%B4%E6%96%B0%E6%96%87%E4%BB%B6.exe", $"{AppDomain.CurrentDomain.BaseDirectory}\\linshi.exe");
                button5.Enabled = true;
                button5.Text = "检查更新";
                System.Diagnostics.FileVersionInfo newversion = System.Diagnostics.FileVersionInfo.GetVersionInfo($"{AppDomain.CurrentDomain.BaseDirectory}\\linshi.exe");

                string thisversion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

                if (newversion.FileVersion != thisversion)
                {
                    DialogResult msg = MessageBox.Show("检测到程序有新版本！\n是否更新？", "有新版本啦！", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (msg == DialogResult.Yes)
                    {
                        MessageBox.Show("更新完成，请重启本程序以完成更新");
                    }
                    else
                    {
                        FileInfo f = new FileInfo($"{AppDomain.CurrentDomain.BaseDirectory}\\linshi.exe");
                        f.Delete();
                    }
                }
                else if (newversion.FileVersion == thisversion)
                {
                    FileInfo f = new FileInfo($"{AppDomain.CurrentDomain.BaseDirectory}\\linshi.exe");
                    f.Delete();
                    MessageBox.Show("当前已是最新版本！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (Exception)
            {
                button5.Text = "检查更新";
                button5.Enabled = true;
                MessageBox.Show("检查失败！\n无法与服务器建立连接！\n解决办法：\n重试几次或者稍后再试！", "检查失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void DownloadFileFromGitee()
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                webClient.DownloadFile("https://gitee.com/kycnb666/softwarerelease/raw/master/software%20release/%E8%81%94%E7%BD%91%E6%9B%B4%E6%96%B0%E6%96%87%E4%BB%B6.exe", $"{AppDomain.CurrentDomain.BaseDirectory}\\linshi.exe");
                button5.Enabled = true;
                button5.Text = "检查更新";
                System.Diagnostics.FileVersionInfo newversion = System.Diagnostics.FileVersionInfo.GetVersionInfo($"{AppDomain.CurrentDomain.BaseDirectory}\\linshi.exe");

                string thisversion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

                if (newversion.FileVersion != thisversion)
                {
                    DialogResult msg = MessageBox.Show("检测到程序有新版本！\n是否更新？", "有新版本啦！", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (msg == DialogResult.Yes)
                    {
                        MessageBox.Show("更新完成，请重启本程序以完成更新");
                    }
                    else
                    {
                        FileInfo f = new FileInfo($"{AppDomain.CurrentDomain.BaseDirectory}\\linshi.exe");
                        f.Delete();
                    }
                }
                else if (newversion.FileVersion == thisversion)
                {
                    FileInfo f = new FileInfo($"{AppDomain.CurrentDomain.BaseDirectory}\\linshi.exe");
                    f.Delete();
                    MessageBox.Show("当前已是最新版本！","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }


            }
            catch (Exception)
            {
                button5.Text = "检查更新";
                button5.Enabled = true;
                MessageBox.Show("检查失败！\n无法与服务器建立连接！\n解决办法：\n重试几次或者稍后再试！", "检查失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread download=new Thread(new ThreadStart(DownloadFileFromGitHub));
            download.Start();
            button1.Enabled = false;
            button1.Text = "正在检查，请稍后...";
        } 
             

        

        private void Form1_Load(object sender, EventArgs e)
        {}

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}\\linshi.exe"))
            {
                diaoyong("cmd.exe", $"/k timeout /t 1 & ren \"{AppDomain.CurrentDomain.BaseDirectory}{Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\" \"旧版文件请手动删除.exe\"");
                diaoyong("cmd.exe", $"/k timeout /t 1 & ren \"{AppDomain.CurrentDomain.BaseDirectory}linshi.exe\" \"{Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\"");
                diaoyong("cmd.exe",$"/k timeout /t 1 & del \"{AppDomain.CurrentDomain.BaseDirectory}旧版文件请手动删除.exe\"");
            }
            Environment.Exit(0);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Thread download = new Thread(new ThreadStart(DownloadFileFromGitee));
            download.Start();
            button5.Enabled = false;
            button5.Text = "正在检查，请稍后...";
        }

        private void button3_Click(object sender, EventArgs e)
        { }
        
        

        private void button4_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            Application.DoEvents();
            webClient.DownloadFile("https://github.com/kycnb666/softwarerelease/blob/main/software%20release/%E6%96%87%E6%9C%AC%E5%8A%A0%E5%AF%86%E8%A7%A3%E5%AF%86.exe", $"{AppDomain.CurrentDomain.BaseDirectory}\\linshi.html");

            StreamReader streamReader = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}\\linshi.html");
            string a = streamReader.ReadToEnd();
           
            streamReader.Close();
            string b = "文本加密解密.exe";
            
            bool isContains = a.ToLower().Contains(b.ToLower());//true
            MessageBox.Show(isContains.ToString());

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        { }

        private void button5_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true || checkBox2.Checked == true)
            {
                if (checkBox1.Checked)
                {
                    Thread download = new Thread(new ThreadStart(DownloadFileFromGitHub));
                    download.Start();
                    button5.Enabled = false;
                    button5.Text = "正在检查，请稍后...";
                }
                else if (checkBox2.Checked)
                {
                    Thread download = new Thread(new ThreadStart(DownloadFileFromGitee));
                    download.Start();
                    button5.Enabled = false;
                    button5.Text = "正在检查，请稍后...";
                }
            }
            else
            {
                MessageBox.Show("请选择下载节点！", "未选择下载节点", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
                checkBox1.Checked = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
                checkBox2.Checked = false; 
        }
    }
}
