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
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace 在线工具箱
{
    public partial class Form5 : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "GetForegroundWindow", CharSet = System.Runtime.InteropServices.CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetF(); 
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetF(IntPtr hWnd); 
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public static void diaoyong(string x, string y)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = x;
            proc.StartInfo.Arguments = y;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Start();
            proc.Close();
        }
        public Form5(string toolname,string downloadlink)
        {
            InitializeComponent();
            Thread download = new Thread(()=>downloadFromFastgit(toolname,downloadlink));
            download.Start();
            try
            {
                FileStream fs = new FileStream($"{Path.GetTempPath()}zxgjxnamesave", FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fs);
                streamWriter.Write($"{toolname}");
                streamWriter.Flush();
                streamWriter.Close();
            }
            catch(Exception) { }
        }
        void downloadFromFastgit(string ToolName,string DownlaodLink)
        {
            try
            {
                label1.Text = $"正在下载{ToolName}，请稍后。。。";
                StreamReader sr = new StreamReader($"{Path.GetTempPath()}zxgjxnodeselection");
                string node = sr.ReadToEnd();
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                webClient.DownloadFileAsync(new Uri($"{node}{DownlaodLink}"), $"{Path.GetTempPath()}\\{ToolName}.exe");
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WebClient_DownloadProgressChanged);
                
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
        }
        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                progressBar1.Value = (int)e.ProgressPercentage;
                label2.Text = $"进度：{e.ProgressPercentage}%\n已下载：{e.BytesReceived / 1024}KB   总大小：{e.TotalBytesToReceive / 1024}KB";
            }
            catch (Exception) { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (progressBar1.Value == 100)
                {
                    StreamReader sr = new StreamReader($"{Path.GetTempPath()}zxgjxnamesave");
                    string name = sr.ReadToEnd();
                    label1.Text = $"{name}下载完成！等待工具启动。。。";
                    timer1.Enabled = false;

                    Process.Start($"{Path.GetTempPath()}{name}.exe");


                    this.Close();
                }
            }
            catch (Exception) {}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader($"{Path.GetTempPath()}zxgjxnamesave");
                string name = sr.ReadToEnd();
                FileInfo file = new FileInfo($"{Path.GetTempPath()}{name}");
                file.Delete();
                diaoyong("cmd.exe", $"/c timeout /t 1 /nobreak & del %temp%\\{name}.exe");
                this.Close();
            }catch (Exception) { }
        }

        private void Form5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists($"{Path.GetTempPath()}zxgjxnodeselection"))
                {
                    StreamReader wn = new StreamReader($"{Path.GetTempPath()}zxgjxnodeselection");
                    string whichnode = wn.ReadToEnd();
                    if (whichnode.Contains("raw.fastgit.org"))
                        label3.Text = "节点：日本东京";
                    else if (whichnode.Contains("pd.zwc365.com"))
                        label3.Text = "节点：中国香港";
                    else if (whichnode.Contains("gh.xiu2.xyz"))
                        label3.Text = "节点：美国洛杉矶";
                }
            }
            catch (Exception) { }
        }
    }
}
