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
using System.Net.NetworkInformation;
using System.Threading;
using System.Diagnostics;

namespace 在线工具箱
{
    public partial class Form7 : Form
    {
        private delegate void FlushClient();//代理
        public Form7()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int connectionDescription, int reservedValue);
        private bool IsConnected()
        {
            int I = 0;
            bool state = InternetGetConnectedState(out I, 0);
            return state;
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
        public int isdone=0;
        public int step1done=0;
        public int step2done = 0;
        public int step3done = 0;
        public int node1testdone=0;
        public int node2testdone=0;
        public int node3testdone=0;
        void step1()
        {
            if (IsConnected() == true)
            {
                label4.Text = "连接正常";
                label1.ForeColor = Color.FromArgb(0,192,0);
                label1.Text = "√";
                step1done++;
            }
            else
            {
                label4.Text = "连接异常";
                label1.Text = "×";
                label1.ForeColor = Color.Red;
            }
            isdone++;
            
        }
        void step2()
        {
            try
            {
                label5.Text = "检查中";
                Thread.Sleep(500);
                string ip = "www.baidu.com";
                Ping ping = new Ping();
                string data = "data";
                byte[] buf = Encoding.ASCII.GetBytes(data);
                int timeout = 1200;
                PingReply reply = ping.Send(ip, timeout, buf);
                if (reply.Status == IPStatus.Success)
                {
                    label5.Text = "可正常访问";
                    label2.ForeColor = Color.FromArgb(0, 192, 0);
                    label2.Text = "√";
                    step2done++;
                }
                else
                {
                    label5.Text = "访问异常";
                    label2.Text = "×";
                    label2.ForeColor = Color.Red;
                }
            }
            catch (Exception)
            {
                label5.Text = "访问异常";
                label2.Text = "×";
                label2.ForeColor = Color.Red;
            }
            isdone++;
            
        }
        void step3()
        {
            Thread.Sleep(500);
            FlushClient fc = new FlushClient(node1test);

            fc.BeginInvoke(null, null);

            Thread.Sleep(500);

            FlushClient fc2 = new FlushClient(node2test);

            fc2.BeginInvoke(null, null);

            Thread.Sleep(500);

            FlushClient fc3 = new FlushClient(node3test);

            fc3.BeginInvoke(null, null);

            Thread.Sleep(500);

            isdone++;
            step3done++;
        }
        void node1test()
        {
            try
            {
                label6.Text = "正在检查各个节点状态（节点一：日本东京）";
                string ip = "raw.fastgit.org";
                Ping ping = new Ping();
                string data = "data";
                byte[] buf = Encoding.ASCII.GetBytes(data);
                int timeout = 1200;
                PingReply reply = ping.Send(ip, timeout, buf);
                if (reply.Status == IPStatus.Success)
                {
                    label13.Text = "√";
                    label13.ForeColor = Color.FromArgb(0,192,0);
                    node1testdone++;
                }
                else
                {
                    label13.Text = "×";
                    label13.ForeColor = Color.Red;
                }
            }
            catch (Exception)
            {
                label13.Text = "×";
                label13.ForeColor = Color.Red;
            }
            isdone++;
            
        }
        void node2test()
        {
            try
            {
                label6.Text = "正在检查各个节点状态（节点四：国内1）";
                string ip2 = "ghproxy.com";
                string data2 = "data";
                Ping ping2 = new Ping();
                byte[] buf2 = Encoding.ASCII.GetBytes(data2);
                int timeout2 = 1200;
                PingReply reply2 = ping2.Send(ip2, timeout2, buf2);
                if (reply2.Status == IPStatus.Success)
                {
                    label14.Text = "√";
                    label14.ForeColor = Color.FromArgb(0,192,0);
                    node2testdone++;
                }
                else
                {
                    label14.Text = "×";
                    label14.ForeColor = Color.Red;
                }
            }
            catch (Exception)
            {
                label14.Text = "×";
                label14.ForeColor = Color.Red;
            }
            isdone++;
            
        }
        void node3test()
        {
            try
            {
                label6.Text = "正在检查各个节点状态（节点五：国内2）";
                string ip3 = "gh.api.99988866.xyz";
                string data3 = "data";
                Ping ping3 = new Ping();
                byte[] buf3 = Encoding.ASCII.GetBytes(data3);
                int timeout3 = 1200;
                PingReply reply3 = ping3.Send(ip3, timeout3, buf3);
                if (reply3.Status == IPStatus.Success)
                {
                    label15.Text = "√";
                    label15.ForeColor = Color.FromArgb(0,192,0);
                    node3testdone++;
                }
                else
                {
                    label15.Text = "×";
                    label15.ForeColor = Color.Red;
                }
            }
            catch (Exception)
            {
                label15.Text = "×";
                label15.ForeColor = Color.Red;
            }
            isdone++;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            timer1.Enabled = true;

            Thread thread=new Thread(step1);
            thread.Start();
            Thread thread2 = new Thread(step2);
            thread2.Start();
            Thread thread3 = new Thread(step3);
            thread3.Start();

            



        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if(isdone == 6)
            {
                button1.Enabled=true;
                isdone=0;
                label6.Text = "检查完毕（节点2,3需挂VPN才能使用，不作检查）";

                if (step1done==1|| step2done==1)
                {

                }

                if(label13.Text ==""||label14.Text == "" || label15.Text == "")
                {
                    label13.Text = "√";
                    label14.Text = "√";
                    label15.Text = "√";
                }

                if(label1.Text == "√" && label2.Text == "√" && label13.Text == "√" && label14.Text == "√" && label15.Text == "√")
                {
                    label16.Text = "\n本轮测试未发现问题\n\n\n若还是无法下载，请切换节点";

                }
                else if(label1.Text == "×" && label2.Text == "×" && label13.Text == "×" && label14.Text == "×" && label15.Text == "×")
                {
                    label16.Text = "\n计算机未联网，请尝试点击启动系统网络诊断";
                }
                if((label1.Text == "√" && label2.Text == "√")&&( label13.Text == "×" || label14.Text == "×" || label15.Text == "×"))
                {
                    label16.Text = "\n计算机已联网，但是部分节点在本次测试中无法访问，并不影响使用，请前往“更新选项-网络节点选择”更换节点即可";
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("msdt.exe ","-id NetworkDiagnosticsNetworkAdapter");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("msdt.exe ", "-id NetworkDiagnosticsWeb");
        }
    }
}
