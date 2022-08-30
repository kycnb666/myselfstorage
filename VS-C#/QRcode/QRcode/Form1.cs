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

namespace QRcode
{
    public partial class Form1 : Form
    {
        static void Generate1(string text)
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
                options.Width = 500;
                options.Height = 500;
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
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    Generate1(textBox1.Text);

                    FileStream fileStream = new FileStream($"{Path.GetTempPath()}qrcode.png", FileMode.Open, FileAccess.Read);

                    pictureBox1.Image = Image.FromStream(fileStream);

                    fileStream.Close();

                    fileStream.Dispose();

                    label2.Text = Read1($"{Path.GetTempPath()}qrcode.png");
                }
            }catch (Exception) { }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            textBox2.Visible = false;
            linkLabel1.Visible = false;
            new Form2().Show();
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
                        linkLabel1.Visible= true;
                        linkLabel1.Text=result.ToString();
                    }
                    else
                    {
                        textBox2.Visible= true;
                        textBox2.Text=result.ToString();
                    }
                }
                else if(result == null)
                {
                    textBox2.Visible= true;
                    textBox2.Text = "没有识别到二维码\r\n\r\n可能原因：\r\n1.二维码太模糊\r\n2.有异物遮挡了二维码的一部分\r\n3.二维码不完整\r\n4.暂不支持扫描新型二维码\r\n5.图片不包含二维码";
                }
                File.Delete($"{Path.GetTempPath()}jietu.png");
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start($"{linkLabel1.Text}");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Visible = false;
            linkLabel1.Visible = false;
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
                pictureBox2.Image= jietujieguo;
                BarcodeReader reader = new BarcodeReader();
                reader.Options.CharacterSet = "UTF-8";
                Bitmap map = new Bitmap(jietujieguo);
                Result result = reader.Decode(map);
                map.Dispose();
                if (result != null)
                {
                    if (result.ToString().Contains("http"))
                    {
                        linkLabel1.Visible = true;
                        linkLabel1.Text = result.ToString();
                    }
                    else
                    {
                        textBox2.Visible = true;
                        textBox2.Text = result.ToString();
                    }
                }
                else if (result == null)
                {
                    textBox2.Visible = true;
                    textBox2.Text = "没有识别到二维码\r\n\r\n可能原因：\r\n1.二维码太模糊\r\n2.有异物遮挡了二维码的一部分\r\n3.二维码不完整\r\n4.暂不支持扫描新型二维码\r\n5.图片不包含二维码";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (File.Exists($"{Path.GetTempPath()}qrcode.png"))
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    File.Copy($"{Path.GetTempPath()}qrcode.png",$"{saveFileDialog1.FileName}");
                }
            }
        }
    }
}
