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

namespace 登录密码
{
    public partial class Form6 : Form
    {
        public string jiemi(string jiemipw)
        {
            string jiemibase64;
            byte[] bytes = System.Convert.FromBase64String(jiemipw);
            jiemibase64 = System.Text.Encoding.UTF8.GetString(bytes);
            return jiemibase64;
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
        public string jiami(string jiamipw)
        {
            string base64;
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jiamipw);
            base64 = System.Convert.ToBase64String(bytes);
            return base64;
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
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="") 
            {
               if (!File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm"))
                  {
                        MessageBox.Show("没有检测到密码，请先设置密码，请查看指引","请看指引",MessageBoxButtons.OK,MessageBoxIcon.Information);
                  }
               else
                  {
                    StreamReader streamReader = new StreamReader($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm");
                    string a = streamReader.ReadToEnd();
                    string pwd = jiema(jiemi(a));
                    streamReader.Close();
                    if (textBox1.Text != pwd)
                      {
                        MessageBox.Show("原密码不正确！","原密码错误",MessageBoxButtons.OK,MessageBoxIcon.Information);
                      }
                    else if(textBox1.Text == pwd)
                    {
                        if (textBox2.Text != textBox3.Text || textBox3.Text != textBox2.Text)
                        {
                            MessageBox.Show("两次输入的新密码必须一样！", "新密码与再次确认的值不相等", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if (textBox2.Text == "" || textBox3.Text == "")
                        {
                            MessageBox.Show("请输入完整！", "数据不完整", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            File.SetAttributes($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm", FileAttributes.Normal);
                            FileStream fs = new FileStream($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm", FileMode.Create);
                            StreamWriter streamWriter = new StreamWriter(fs);
                            streamWriter.Write(jiami(bianma(textBox2.Text)));
                            streamWriter.Flush();
                            streamWriter.Close();
                            File.SetAttributes($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm", FileAttributes.Hidden);
                            MessageBox.Show("密码已成功更改，请牢记！","密码已成功更改",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                  }


            }
            else if(textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("请输入完整！", "数据不完整", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (textBox2.Text != textBox3.Text || textBox3.Text != textBox2.Text)
            {
                MessageBox.Show("两次输入的新密码必须一样！", "新密码与再次确认的值不相等", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm"))
                {
                    FileStream fs = new FileStream($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm", FileMode.Create);
                    File.SetAttributes($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm", FileAttributes.Hidden);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.Write(jiami(bianma(textBox2.Text)));
                    streamWriter.Flush();
                    streamWriter.Close();
                    MessageBox.Show("新密码设置成功！请牢记！","密码已经设置",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    if (textBox1.Text == "")
                        MessageBox.Show("你已经设置过密码，请输入原密码后继续","请先输入原密码",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            if(textBox4.Text != "")
            {
                if (!File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\mmts"))
                {
                    FileStream fs = new FileStream($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\mmts", FileMode.Create);
                    File.SetAttributes($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\mmts", FileAttributes.Hidden);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.Write(jiami(bianma(textBox4.Text)));
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                else
                {
                    File.SetAttributes($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\mmts", FileAttributes.Normal);
                    FileStream fs = new FileStream($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\mmts", FileMode.Create);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.Write(jiami(bianma(textBox4.Text)));
                    streamWriter.Flush();
                    streamWriter.Close();
                    File.SetAttributes($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\mmts", FileAttributes.Hidden);
                }
            }
        }
        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        { }
        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            if (!File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm"))
            {
                label1.Text = "设置密码";
                label2.Visible = false;
                textBox1.Visible = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '\0';
            textBox2.PasswordChar = '\0';
            textBox3.PasswordChar = '\0';
            pictureBox2.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '*';
            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
            pictureBox2.Visible = false;
        }
    }
}
