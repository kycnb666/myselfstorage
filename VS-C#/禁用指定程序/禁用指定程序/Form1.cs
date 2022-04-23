using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections;

namespace 禁用指定程序
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入程序名","",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (radioButton1.Checked)
                {
                    try
                    {
                        RegistryKey key = Registry.LocalMachine;
                        RegistryKey software = key.CreateSubKey($"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\{textBox1.Text}");
                        RegistryKey create = key.OpenSubKey($"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\{textBox1.Text}", true);
                        create.SetValue("debugger", $"mshta vbscript:msgbox(\"{textBox3.Text}\",16,\"{textBox2.Text}\")(window.close)");
                        key.Close();
                        MessageBox.Show("禁用成功");
                    }
                    catch (Exception) { }
                }
                else if (radioButton2.Checked)
                {
                    if (textBox4.Text == "")
                    {
                        MessageBox.Show("您选择了重定向玩法，请输入路径后继续", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            RegistryKey key = Registry.LocalMachine;
                            RegistryKey software = key.CreateSubKey($"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\{textBox1.Text}");
                            RegistryKey create = key.OpenSubKey($"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\{textBox1.Text}", true);
                            create.SetValue("debugger", $"\"{textBox4.Text}\"");
                            key.Close();
                            MessageBox.Show("禁用成功");
                        }
                        catch (Exception) { }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入程序名", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    RegistryKey delKey = Registry.LocalMachine.OpenSubKey($"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\{textBox1.Text}", true);
                    delKey.DeleteValue("debugger");
                    delKey.Close();
                    RegistryKey key = Registry.LocalMachine;
                    key.DeleteSubKey($"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\{textBox1.Text}", true);
                    key.Close();
                    MessageBox.Show("恢复成功");
                }
                catch (Exception) { }
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label3.Text = textBox2.Text;
            label4.Text = textBox3.Text;
        }
        public string[] taskmgr = {"任务管理器","taskmgr","taskmanager" };
        public string[] cmd = {"cmd","命令提示符","命令行" };
        public string[] regedit= {"注册表编辑器","注册表","regedit" };
        public string[] mmc = {"组策略","gpedit","mmc","本地组策略编辑器" };
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                if (((IList)taskmgr).Contains(textBox1.Text))
                {
                    textBox1.Text = "taskmgr.exe";
                }
                else if (((IList)cmd).Contains(textBox1.Text))
                {
                    textBox1.Text = "cmd.exe";
                }
                else if (((IList)regedit).Contains(textBox1.Text))
                {
                    textBox1.Text = "regedit.exe";
                }
                else if (((IList)mmc).Contains(textBox1.Text))
                {
                    textBox1.Text = "mmc.exe";
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("直接输入你想禁用的程序名即可\n\n例如：\n我想禁用任务管理器，直接输入taskmgr.exe即可\n\n我想禁用一个名为123.exe的程序，直接输入123.exe即可", "使用帮助");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("你可以在此自定义禁用程序后弹出的窗口内容，当你点击禁用后，若尝试打开该禁用的程序，会弹出这个自定义的窗口","使用帮助");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("意思是当你禁用了一个程序后，若尝试打开该禁用的程序，会直接打开你在此输入的程序\n\n请注意：\n应输入完整的文件路径","使用帮助");
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("本软件禁用程序是通过IFEO（映像劫持）来实现，因此使用时电脑杀毒软件会弹出警告窗口，请点击允许本程序操作即可");
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible=false;
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel2.Visible=false ;
        }
    }
}
