using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 隐藏文件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1 .Text == "")
            {
                MessageBox.Show("你没有输入路径！", "没有路径，请检查",MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
            else
            {
                if (checkBox1.Checked == false)
                {
                    System.Diagnostics.Process.Start("cmd.exe", "/c attrib +h " + textBox1.Text);
                }
                else if (checkBox1 .Checked == true)
                {
                    System.Diagnostics.Process.Start("cmd.exe", "/c attrib +s +a +h +r " + textBox1.Text);
                }
            }
            
        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(this.textBox1, @"请输入正确文件或文件夹的路径
例如 隐藏单个文件 D:\sample\hide.txt
       隐藏文件夹 D:\sample
不输入正确的路径隐藏会无效");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(this.textBox2, @"请输入正确文件或文件夹的路径
例如 解除隐藏单个文件 D:\sample\hide.txt
       解除隐藏文件夹 D:\sample
不输入正确的路径隐藏会无效");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("你没有输入路径！", "没有路径，请检查", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (checkBox2.Checked == false)
                {
                    System.Diagnostics.Process.Start("cmd.exe", "/c attrib -h " + textBox2.Text);
                }
                else if (checkBox2.Checked == true)
                {
                    System.Diagnostics.Process.Start("cmd.exe", "/c attrib -s -a -h -r " + textBox2.Text);
                }
            }
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(this.label3 , @"此功能用于融合文件
例如在当前文件夹下，你有一个图片和一个压缩包，你可以用此功能将图片和压缩包融合，
融合后生成的文件就是你原来那张图片，但是图片大小会有所增加，增加量取决于压缩包大小，
如果你想从这张图片中获得原来的压缩包，只需把文件后缀名改回压缩文件的后缀名即可。
使用方法：
在第一个框框直接输入你的文件名（要有后缀）（第一个文件）
在第二个框框输入你要融合的文件名（要有后缀）（第二个文件）
点击确定
这样一来第二个文件就融入到第一个文件里去了
注意：
这两个文件必须和此程序在同一个文件夹下");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox3 .Text ==""|| textBox4 .Text == "")
            {
                MessageBox.Show("请输入文件名","没有输入文件名",MessageBoxButtons.OK ,MessageBoxIcon.Error );
            }
            else
            {
                System.Diagnostics.Process.Start("cmd.exe", "/c copy " + textBox3.Text + "/b + " + textBox4.Text + " = 已融合" + textBox3.Text);
                MessageBox.Show("操作完成！", "success");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("开发者QQ：3524829413", "关于", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
