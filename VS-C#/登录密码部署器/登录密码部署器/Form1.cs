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
using System.Diagnostics;
using Microsoft.Win32;

namespace 登录密码部署器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void ReleaseFile(string path)
        {
            byte[] byFile = global::登录密码部署器.Properties.Resources.登录密码;//获取嵌⼊dll⽂件的字节数组
            string strPath = path + @"\登录密码.exe";//设置释放路径导出路径
                                                                    //创建dll⽂件（覆盖模式）
            using (FileStream fs = new FileStream(strPath, FileMode.Create))
            {
                fs.Write(byFile, 0, byFile.Length);
            }
        }
        void setstartup(string apppath)
        {
            RegistryKey R_local = Registry.LocalMachine;
            RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            R_run.SetValue("1dlmm", apppath);
            R_run.Close();
            R_local.Close();
        }
        void cancelstartup()
        {
            RegistryKey R_local = Registry.LocalMachine;
            RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            R_run.DeleteValue("1dlmm", false);
            R_run.Close();
            R_local.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmminstallpathsave"))
            {
                tabControl1.SelectedTab = tabControl1.TabPages[4];
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }



        private void button3_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请选择安放路径", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (textBox1.Text != "")
                {
                    textBox2.Text += $"1.安放目录为：{textBox1.Text}     ";
                }
                if (checkBox1.Checked)
                {
                    textBox2.Text += "2.开机自启";
                }
                else if (!checkBox1.Checked)
                {
                    textBox2.Text += "2.您没有选择开机自启，确定吗？（你也可以随时去安放目录手动打开）";
                }
                tabControl1.SelectedTab = tabControl1.TabPages[2];
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string defaultPath = "";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择一个文件夹";
            if (defaultPath != "")
            {
                //设置此次默认目录为上一次选中目录  
                dialog.SelectedPath = defaultPath;
            }
            //按下确定选择的按钮  
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //记录选中的目录  
                defaultPath = dialog.SelectedPath;
            }
            textBox1.Text = defaultPath;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            textBox2.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmminstallpathsave", FileMode.Create);
            File.SetAttributes($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmminstallpathsave", FileAttributes.Hidden);
            StreamWriter streamWriter = new StreamWriter(fs);
            streamWriter.Write(textBox1.Text);
            streamWriter.Flush();
            streamWriter.Close();
            ReleaseFile(textBox1.Text);
            if (checkBox1.Checked)
            {
                setstartup($"{textBox1.Text}\\登录密码.exe");
            }
            tabControl1.SelectedTab = tabControl1.TabPages[3];
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Process.Start($"{textBox1.Text}\\登录密码.exe");
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (groupBox1.Visible == false)
            {
                groupBox1.Visible = true;
                linkLabel1.Text = "↑ 收起 ↑";
            }
            else
            {
                groupBox1.Visible = false;
                linkLabel1.Text = "↓ 其他操作 ↓";
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm"))
            {
                File.Delete($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm");
                File.Delete($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\mmts");
                MessageBox.Show("清除完成！", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm"))
            {
                MessageBox.Show("已经清除了密码", "已清除", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmminstallpathsave"))
            {
                StreamReader streamReader = new StreamReader($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmminstallpathsave");
                string c = streamReader.ReadToEnd();
                streamReader.Close();
                File.Delete($"{c}\\登录密码.exe");
                File.Delete($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm");
                File.Delete($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\mmts");
                File.Delete($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmminstallpathsave");
                cancelstartup();
                MessageBox.Show("“登录密码”已成功从你的电脑移除", "已卸载", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("已经卸载过了", "已经卸载了！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmminstallpathsave"))
            {
                StreamReader streamReader = new StreamReader($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmminstallpathsave");
                string a = streamReader.ReadToEnd();
                streamReader.Close();
                Process.Start($"{a}\\登录密码.exe");
            }
            else
            {
                MessageBox.Show("你已经卸载了本软件，请重新安装", "需要重新安装", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader streamReader = new StreamReader($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmminstallpathsave");
                string b = streamReader.ReadToEnd();
                streamReader.Close();
                setstartup($"{b}\\登录密码.exe");
                MessageBox.Show("设置成功！", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch (Exception) { }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            cancelstartup();
            MessageBox.Show("开机自启已关闭", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
