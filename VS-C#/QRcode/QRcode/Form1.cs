using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Drawing.Drawing2D;
using ZXing.Common;
using ZXing.QrCode.Internal;

namespace QRcode
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
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

        public void SetWindowRegion()
        {
            GraphicsPath FormPath;
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            FormPath = GetRoundedRectPath(rect, 25);
            this.Region = new Region(FormPath);

        }

        static void Generate1(string text,int width,int height)
        {
            try
            {
                BarcodeWriter writer = new BarcodeWriter();
                writer.Format = BarcodeFormat.QR_CODE;
                QrCodeEncodingOptions options = new QrCodeEncodingOptions();
                options.DisableECI = true;
                //设置内容编码
                options.CharacterSet = "UTF-8";
                //设置二维码的宽度和高度
                options.Width = width;
                options.Height = height;
                //设置二维码的边距,单位不是固定像素
                options.Margin = 1;
                writer.Options = options;


                Bitmap map = writer.Write(text);

                string filename = $"{Path.GetTempPath()}qrcode.png";




                try
                {
                    map.Save(filename, ImageFormat.Png);
                }
                catch (Exception)
                {
                    var code = Marshal.GetLastWin32Error();
                    MessageBox.Show(code.ToString());
                }
                map.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        static void Generate3(string text,string logofile,int width,int height)
        {
            
            //Logo 图片
            Bitmap logo = new Bitmap(logofile);
            //构造二维码写码器
            MultiFormatWriter writer = new MultiFormatWriter();
            Dictionary<EncodeHintType, object> hint = new Dictionary<EncodeHintType, object>();
            hint.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
            hint.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);

            //生成二维码 
            BitMatrix bm = writer.encode(text, BarcodeFormat.QR_CODE, width, height, hint);
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            Bitmap map = barcodeWriter.Write(bm);


            //获取二维码实际尺寸（去掉二维码两边空白后的实际尺寸）
            int[] rectangle = bm.getEnclosingRectangle();

            //计算插入图片的大小和位置
            int middleW = Math.Min((int)(rectangle[2] / 3.5), logo.Width);
            int middleH = Math.Min((int)(rectangle[3] / 3.5), logo.Height);
            int middleL = (map.Width - middleW) / 2;
            int middleT = (map.Height - middleH) / 2;

            //将img转换成bmp格式，否则后面无法创建Graphics对象
            Bitmap bmpimg = new Bitmap(map.Width, map.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bmpimg))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(map, 0, 0);
            }
            //将二维码插入图片
            Graphics myGraphic = Graphics.FromImage(bmpimg);
            //白底
            myGraphic.FillRectangle(Brushes.White, middleL, middleT, middleW, middleH);
            myGraphic.DrawImage(logo, middleL, middleT, middleW, middleH);

            //保存成图片
            bmpimg.Save($"{Path.GetTempPath()}qrcode.png", ImageFormat.Png);
        }
        static string Read1(string filename)
        {
            BarcodeReader reader = new BarcodeReader();
            reader.Options.CharacterSet = "UTF-8";
            Bitmap map = new Bitmap(filename);
            Result result = reader.Decode(map);
            map.Dispose();
            return result == null ? "" : result.Text;
            
            
        }
        public Form1()
        {
            InitializeComponent();
            this.NativeTabControl1 = new NativeTabControl();
            this.NativeTabControl2 = new NativeTabControl();
            this.NativeTabControl1.AssignHandle(this.tabControl1.Handle);
            this.NativeTabControl2.AssignHandle(this.tabControl1.Handle);

        }
        private NativeTabControl NativeTabControl1;
        private NativeTabControl NativeTabControl2;
        private class NativeTabControl : NativeWindow
        {

            protected override void WndProc(ref Message m)
            {
                if ((m.Msg == TCM_ADJUSTRECT))
                {
                    RECT rc = (RECT)m.GetLParam(typeof(RECT));
                    //Adjust these values to suit, dependant upon Appearance
                    rc.Left -= 3;
                    rc.Right += 3;
                    rc.Top -= 3;
                    rc.Bottom += 3;
                    Marshal.StructureToPtr(rc, m.LParam, true);
                }
                base.WndProc(ref m);
            }
            private const Int32 TCM_FIRST = 0x1300;
            private const Int32 TCM_ADJUSTRECT = (TCM_FIRST + 40);
            private struct RECT
            {
                public Int32 Left;
                public Int32 Top;
                public Int32 Right;
                public Int32 Bottom;
            }
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            

            

            if (File.Exists($"{Path.GetTempPath()}jietu.png"))
            {
                FileStream fileStream = File.OpenRead($"{Path.GetTempPath()}jietu.png");
                Int32 jietulength = 0;
                jietulength = (int)fileStream.Length;
                Byte[] jietu = new Byte[jietulength];
                fileStream.Read(jietu, 0, jietulength);
                Image readjietu = Image.FromStream(fileStream);
                fileStream.Close();
                Bitmap jietujieguo = new Bitmap(readjietu);

                pictureBox2.Image = jietujieguo;

                BarcodeReader reader = new BarcodeReader();
                reader.Options.CharacterSet = "UTF-8";
                Bitmap map = new Bitmap(jietujieguo);
                Result result = reader.Decode(map);
                map.Dispose();

                if (result != null)
                {
                    if (result.ToString().Contains("http"))
                    {
                        panel1.Visible= true;
                        linkLabel1.Text=result.ToString();
                    }
                    else
                    {
                        panel2.Visible= true;
                        textBox2.Text=result.ToString();
                    }
                }
                else if(result == null)
                {
                    panel2.Visible= true;
                    textBox2.Text = "没有识别到二维码\r\n\r\n可能原因：\r\n1.二维码太模糊\r\n2.有异物遮挡了二维码的一部分\r\n3.二维码不完整\r\n4.暂不支持扫描新型二维码\r\n5.图片不包含二维码";
                }
                File.Delete($"{Path.GetTempPath()}jietu.png");
                this.WindowState = FormWindowState.Normal;
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start($"{linkLabel1.Text}");
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex=0;
            tabControl1.SelectedIndex=0;
            pictureBox6.Image = QRcode.Properties.Resources.scanbtnselected;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            SetWindowRegion();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(linkLabel1.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Minimized;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }

        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }

        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            pictureBox6.Image = QRcode.Properties.Resources.scanbtnselected;
            pictureBox7.Image =QRcode.Properties.Resources.createbtn;
            pictureBox8.Image=QRcode.Properties.Resources.aboutbtn;

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            pictureBox7.Image = QRcode.Properties.Resources.createbtnselected;
            pictureBox6.Image = QRcode.Properties.Resources.scanbtn;
            pictureBox8.Image = QRcode.Properties.Resources.aboutbtn;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            pictureBox8.Image = QRcode.Properties.Resources.aboutbtnselected;
            pictureBox6.Image = QRcode.Properties.Resources.scanbtn;
            pictureBox7.Image = QRcode.Properties.Resources.createbtn;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            Thread.Sleep(100);

            timer1.Enabled = true;
            panel2.Visible = false;
            panel1.Visible = false;

            new Form2().Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fileStream = File.OpenRead($"{openFileDialog1.FileName}");
                Int32 jietulength = 0;
                jietulength = (int)fileStream.Length;
                Byte[] jietu = new Byte[jietulength];
                fileStream.Read(jietu, 0, jietulength);
                Image readjietu = Image.FromStream(fileStream);
                fileStream.Close();
                Bitmap jietujieguo = new Bitmap(readjietu);
                pictureBox2.Image = jietujieguo;
                BarcodeReader reader = new BarcodeReader();
                reader.Options.CharacterSet = "UTF-8";
                Bitmap map = new Bitmap(jietujieguo);
                Result result = reader.Decode(map);
                map.Dispose();
                if (result != null)
                {
                    if (result.ToString().Contains("http"))
                    {
                        panel1.Visible = true;
                        linkLabel1.Text = result.ToString();
                    }
                    else
                    {
                        panel2.Visible = true;
                        textBox2.Text = result.ToString();
                    }
                }
                else if (result == null)
                {
                    panel2.Visible = true;
                    textBox2.Text = "没有识别到二维码\r\n\r\n可能原因：\r\n1.二维码太模糊\r\n2.有异物遮挡了二维码的一部分\r\n3.二维码不完整\r\n4.暂不支持扫描新型二维码\r\n5.图片不包含二维码";
                }
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    if (comboBox1.SelectedItem.ToString().Equals("普通"))
                    {
                        Generate1(textBox1.Text, int.Parse(textBox3.Text), int.Parse(textBox4.Text));

                        FileStream fileStream = new FileStream($"{Path.GetTempPath()}qrcode.png", FileMode.Open, FileAccess.Read);

                        pictureBox1.Image = Image.FromStream(fileStream);

                        fileStream.Close();

                        fileStream.Dispose();

                        //textBox3.Text = Read1($"{Path.GetTempPath()}qrcode.png");
                    }
                    else if (comboBox1.SelectedItem.ToString().Equals("带logo"))
                    {
                        if (openFileDialog2.ShowDialog() == DialogResult.OK)
                        {
                            Generate3(textBox1.Text, openFileDialog2.FileName, int.Parse(textBox3.Text), int.Parse(textBox4.Text));

                            FileStream fileStream = new FileStream($"{Path.GetTempPath()}qrcode.png", FileMode.Open, FileAccess.Read);

                            pictureBox1.Image = Image.FromStream(fileStream);

                            fileStream.Close();

                            fileStream.Dispose();
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists($"{Path.GetTempPath()}qrcode.png"))
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists($"{saveFileDialog1.FileName}"))
                        {
                            File.Delete(saveFileDialog1.FileName);
                            File.Copy($"{Path.GetTempPath()}qrcode.png", $"{saveFileDialog1.FileName}");
                        }
                        else
                        {
                            File.Copy($"{Path.GetTempPath()}qrcode.png", $"{saveFileDialog1.FileName}");
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void tabPage1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }

        private void tabPage2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }

        private void tabPage3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://kycnb666.github.io/ewmgj.html");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://kycnb666.github.io/");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/kycnb666/");
        }
    }
}
