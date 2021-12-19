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

namespace 联网更新文件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                


                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                Application.DoEvents();
                webClient.DownloadFile("https://raw.githubusercontent.com/kycnb666/softwarerelease/main/software%20release/%E6%96%87%E6%9C%AC%E5%8A%A0%E5%AF%86%E8%A7%A3%E5%AF%86.exe", $"{AppDomain.CurrentDomain.BaseDirectory}\\linshi.exe");
                
                System.Diagnostics.FileVersionInfo newversion = System.Diagnostics.FileVersionInfo.GetVersionInfo($"{AppDomain.CurrentDomain.BaseDirectory}\\linshi.exe");

                string thisversion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

                if (newversion.FileVersion != thisversion)
                {
                    DialogResult msg= MessageBox.Show("检测到程序有新版本！\n是否更新？","有新版本啦！",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                    if(msg == DialogResult.Yes)
                    {
                        MessageBox.Show("更新完成，请重启本程序以完成更新");
                    }
                    else
                    {
                        FileInfo f=new FileInfo($"{AppDomain.CurrentDomain.BaseDirectory}\\linshi.exe");
                        f.Delete();
                    }
                }
                else if(newversion.FileVersion == thisversion)
                {
                    FileInfo f = new FileInfo($"{AppDomain.CurrentDomain.BaseDirectory}\\linshi.exe");
                    f.Delete();
                    MessageBox.Show("当前已是最新版本！");
                }


            }
            catch (Exception ex) { MessageBox.Show("检查失败！可能原因：\n1.电脑无网络连接\n2.服务器更新节点无响应\n3.详细错误信息如下：\n\n\n"+ex.ToString()); }
        }

        private void button2_Click(object sender, EventArgs e)
        { }

        private void Form1_Load(object sender, EventArgs e)
        { }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}\\linshi.exe"))
            Process.Start("cmd.exe", $"/k rename \"{AppDomain.CurrentDomain.BaseDirectory}\\linshi.exe\" \"{Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\"");
        }
    }
}
