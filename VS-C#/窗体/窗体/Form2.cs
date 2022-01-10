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
using System.Threading;
using System.Media;

namespace 窗体
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        void downloadFromGitee()
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;


                webClient.DownloadFileAsync(new Uri("https://gitee.com/kycnb666/softwarerelease/raw/master/software%20release/%E7%AA%97%E4%BD%93/%E7%AA%97%E4%BD%93.exe"), $"{AppDomain.CurrentDomain.BaseDirectory}\\linshigxdwj.exe");
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WebClient_DownloadProgressChanged);
            }catch (Exception) { }
            
        }
       

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            
            progressBar1.Value = (int)e.ProgressPercentage;
            label1.Text = $"下载更新中，请稍后。。。    进度：{e.ProgressPercentage}\n已下载：{e.BytesReceived/1024}KB   总大小：{e.TotalBytesToReceive/1024}KB";
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox2.Parent = this.pictureBox1;
            label1.Parent = this.pictureBox3;
            progressBar1.Parent = this.pictureBox3;
            pictureBox4.Parent = this.pictureBox3;
            pictureBox5.Parent = this.pictureBox4;
            label2.Parent = this.pictureBox5;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            label1.Visible = true;
            progressBar1.Visible = true;
            Thread download = new Thread(new ThreadStart(downloadFromGitee));
            download.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(progressBar1.Value == 100)
            {
                
                pictureBox4.Visible=true;
                label1.Visible=false;
                progressBar1.Visible=false;
                timer2.Enabled = true;
                timer1.Enabled = false;
            }
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            pictureBox5.Visible=true;
            timer3.Enabled=true;
            SoundPlayer sp=new SoundPlayer(窗体.Properties.Resources.completedbgm);
            sp.Play();
            timer2.Enabled=false;
        }
        public int w = 291;
        private void timer3_Tick(object sender, EventArgs e)
        {

            if (w == -label2.Width)
                w = 291;
            else if (w == 0)
                w -= 1;
            else if (w != 0)
                w -= 1;
            label2.Location = new Point(w, 162);
        }
    }
}
