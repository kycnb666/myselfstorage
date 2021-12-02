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

namespace 文件读写
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string jiami(string jiamipw)
        {
            string base64;
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jiamipw);
            base64 = System.Convert.ToBase64String(bytes);
            return base64;
        }
        public string jiemi(string jiemipw)
        {
            string jiemibase64;
            byte[] bytes = System.Convert.FromBase64String(jiemipw);
            jiemibase64 = System.Text.Encoding.UTF8.GetString(bytes);
            return jiemibase64;
        }
        public static string bianma(string s)
        {
            byte[] data = Encoding.Unicode.GetBytes(s);
            StringBuilder result = new StringBuilder(data.Length * 8);

            foreach (byte b in data)
            {
                result.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }
            return result.ToString();
        }
        public static string jiema(string s)
        {
            System.Text.RegularExpressions.CaptureCollection cs =
                System.Text.RegularExpressions.Regex.Match(s, @"([01]{8})+").Groups[1].Captures;
            byte[] data = new byte[cs.Count];
            for (int i = 0; i < cs.Count; i++)
            {
                data[i] = Convert.ToByte(cs[i].Value, 2);
            }
            return Encoding.Unicode.GetString(data, 0, data.Length);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm"))
                {
                    FileStream fs = new FileStream($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm", FileMode.Create);
                    File.SetAttributes($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm", FileAttributes.Hidden);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.Write(jiami(textBox1.Text));
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                else
                {
                    File.SetAttributes($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm", FileAttributes.Normal);
                    FileStream fs = new FileStream($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm", FileMode.Create);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.Write(jiami(textBox1.Text));
                    streamWriter.Flush();
                    streamWriter.Close();
                    File.SetAttributes($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm", FileAttributes.Hidden);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm"))
                {
                    MessageBox.Show("文件不存在！！！");
                }
                else
                {
                    StreamReader streamReader = new StreamReader($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm");
                    string a = streamReader.ReadToEnd();
                    MessageBox.Show(jiemi(a));
                    streamReader.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\dlmm"))
                {
                    FileStream fs = new FileStream($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\dlmm", FileMode.Create);
                    File.SetAttributes($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop )}\\dlmm", FileAttributes.Hidden);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.Write(bianma(textBox1.Text));
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                else
                {
                    File.SetAttributes($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop )}\\dlmm", FileAttributes.Normal);
                    FileStream fs = new FileStream($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop )}\\dlmm", FileMode.Create);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.Write(bianma(textBox1.Text));
                    streamWriter.Flush();
                    streamWriter.Close();
                    File.SetAttributes($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop )}\\dlmm", FileAttributes.Hidden);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\dlmm"))
                {
                    MessageBox.Show("文件不存在！！！");
                }
                else
                {
                    StreamReader streamReader = new StreamReader($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\dlmm");
                    string a = streamReader.ReadToEnd();
                    MessageBox.Show(jiema(a));
                    streamReader.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\dlmm"))
                {
                    FileStream fs = new FileStream($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\dlmm", FileMode.Create);
                    File.SetAttributes($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\dlmm", FileAttributes.Hidden);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.Write(jiami(bianma(textBox1.Text)));
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                else
                {
                    File.SetAttributes($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\dlmm", FileAttributes.Normal);
                    FileStream fs = new FileStream($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\dlmm", FileMode.Create);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.Write(jiami(bianma(textBox1.Text)));
                    streamWriter.Flush();
                    streamWriter.Close();
                    File.SetAttributes($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\dlmm", FileAttributes.Hidden);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\dlmm"))
                {
                    MessageBox.Show("文件不存在！！！");
                }
                else
                {
                    StreamReader streamReader = new StreamReader($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\dlmm");
                    string a = streamReader.ReadToEnd();
                    MessageBox.Show(jiema(jiemi(a)));
                    streamReader.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            openFileDialog.Filter = "文本文件|*.txt";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog.FileName;
                textBox1.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox4.Text =jiami(textBox1.Text);
            textBox5.Text =bianma(textBox1.Text);
            textBox6.Text =jiami(bianma(textBox1.Text));
        }
    }
}
