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

namespace 窗体
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        void downloadFromFastgit()
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;


                webClient.DownloadFileAsync(new Uri("https://raw.fastgit.org/kycnb666/softwarerelease/main/software%20release/%E7%AA%97%E4%BD%93/notice"), $"{AppDomain.CurrentDomain.BaseDirectory}\\linshigxdwj.exe");
                
            }
            catch (Exception) { }

        }
        private void Form4_Load(object sender, EventArgs e)
        {
            FileInfo t = new FileInfo($"{AppDomain.CurrentDomain.BaseDirectory}{Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location)}");
            string title = t.CreationTime.ToString("F");
            string title2=t.LastWriteTime.ToString("F");
            label1.Text = $"云端上次更新的时间：{title}";
            label2.Text = $"上次本地更新时间：{title2}";
        }
    }
}
