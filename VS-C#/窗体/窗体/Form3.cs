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
using System.Threading;

namespace 窗体
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        void checkversion()
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
                    DialogResult msg=MessageBox.Show("检测到新版本，是否立即更新？","发现新版本啦",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if(msg == DialogResult.Yes)
                        new Form2().Show();
                    
                }
            }catch (Exception) { }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread download = new Thread(new ThreadStart(checkversion));
            download.Start();
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
                    DialogResult msg = MessageBox.Show("检测到新版本，是否立即更新？", "发现新版本啦", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msg == DialogResult.Yes)
                        new Form2().Show();

                }
                else
                {
                    MessageBox.Show("当前已经是最新版本了","当前版本是最新的",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception) { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }
    }
}
