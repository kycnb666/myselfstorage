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
using System.Drawing.Drawing2D;
using System.Threading;
using System.Runtime.InteropServices;

namespace 在线工具箱
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "GetForegroundWindow", CharSet = System.Runtime.InteropServices.CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetF(); //获得本在线工具箱的句柄
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetF(IntPtr hWnd); //设置此在线工具箱为活动在线工具箱
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        /// <summary>
        /// 设置在线工具箱的Region
        /// </summary>
        public void SetWindowRegion()
        {
            GraphicsPath FormPath;
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            FormPath = GetRoundedRectPath(rect, 200);
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

        void checkversion()
        {

            try
            {
                StreamReader getnode = new StreamReader($"{Path.GetTempPath()}zxgjxnodeselection");
                string node = getnode.ReadToEnd();

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
                    timer1.Enabled = false;
                }
                else { timer2.Enabled = false; }
            }
            catch (Exception) {  }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void Form3_Resize(object sender, EventArgs e)
        {
            SetWindowRegion();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                timer3.Enabled = false;
                DialogResult msg = MessageBox.Show("检测到新版本，是否立即更新？", "发现新版本啦", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (msg == DialogResult.Yes)
                {
                    timer1.Enabled = true;
                    timer3.Enabled = true;
                    new Form2().Show();
                }else if(msg == DialogResult.No)
                {
                    timer1.Enabled=true;
                    timer3.Enabled=true;
                }
            }
            else if(timer2.Enabled == false)
            {
                timer3.Enabled = false;
                MessageBox.Show("当前已经是最新版本了", "当前版本是最新的", MessageBoxButtons.OK, MessageBoxIcon.Information);
                timer2.Enabled = true;
                timer3.Enabled = true;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.ForeColor = Color.Black;
            label1.BackColor = Color.White;
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            label1.ForeColor= Color.White;
            label1.BackColor= Color.Black;
        }

        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            label2.BackColor = Color.Transparent;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Thread download = new Thread(new ThreadStart(checkversion));
            download.Start();
        }
    }
}
