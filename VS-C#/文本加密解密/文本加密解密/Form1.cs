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

namespace 文本加密解密
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox2.Text = jiami(textBox1.Text);
            textBox3.Text = bianma(textBox1.Text);
            textBox4.Text = jiami(bianma(textBox1.Text));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "解密模式")
                groupBox2.Visible = true;
            else if (comboBox1.Text == "加密模式")
                groupBox2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            openFileDialog1.InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            openFileDialog1.Filter = "文本文件|*.txt|所有类型文件|*.*";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            saveFileDialog1.Filter = "文本文件|*.txt|所有类型文件|*.*";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FilterIndex = 1;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fs);
                streamWriter.Write(textBox2.Text);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog2.InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            saveFileDialog2.Filter = "文本文件|*.txt|所有类型文件|*.*";
            saveFileDialog2.RestoreDirectory = true;
            saveFileDialog2.FilterIndex = 1;
            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFileDialog2.FileName, FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fs);
                streamWriter.Write(textBox3.Text);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveFileDialog3.InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            saveFileDialog3.Filter = "文本文件|*.txt|所有类型文件|*.*";
            saveFileDialog3.RestoreDirectory = true;
            saveFileDialog3.FilterIndex = 1;
            if (saveFileDialog3.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFileDialog3.FileName, FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fs);
                streamWriter.Write(textBox4.Text);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                textBox8.Text = jiemi(textBox5.Text);
            }
            catch (Exception) { textBox8.Text = "不是有效的可解码文本"; }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                textBox9.Text = jiema(textBox6.Text);
            }
            catch (Exception) { textBox9.Text = "不是有效的可解码文本"; }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            try
            {
                textBox10.Text = jiema(jiemi(textBox7.Text));
            }
            catch (Exception) { textBox10.Text = "不是有效的可解码文本"; }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            openFileDialog1.Filter = "文本文件|*.txt|所有类型文件|*.*";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            openFileDialog1.Filter = "文本文件|*.txt|所有类型文件|*.*";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox6.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            openFileDialog1.Filter = "文本文件|*.txt|所有类型文件|*.*";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox7.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            saveFileDialog4.InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            saveFileDialog4.Filter = "文本文件|*.txt|所有类型文件|*.*";
            saveFileDialog4.RestoreDirectory = true;
            saveFileDialog4.FilterIndex = 1;
            if (saveFileDialog4.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFileDialog4.FileName, FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fs);
                streamWriter.Write(textBox8.Text);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            saveFileDialog4.InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            saveFileDialog4.Filter = "文本文件|*.txt|所有类型文件|*.*";
            saveFileDialog4.RestoreDirectory = true;
            saveFileDialog4.FilterIndex = 1;
            if (saveFileDialog4.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFileDialog4.FileName, FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fs);
                streamWriter.Write(textBox9.Text);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            saveFileDialog4.InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            saveFileDialog4.Filter = "文本文件|*.txt|所有类型文件|*.*";
            saveFileDialog4.RestoreDirectory = true;
            saveFileDialog4.FilterIndex = 1;
            if (saveFileDialog4.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFileDialog4.FileName, FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fs);
                streamWriter.Write(textBox10.Text);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }
    }
}
