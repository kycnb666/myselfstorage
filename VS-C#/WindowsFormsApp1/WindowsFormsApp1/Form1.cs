using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {int  k=1;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult a;
            a=MessageBox.Show("hello","hello",MessageBoxButtons.OKCancel ,MessageBoxIcon.Information );
            if (a == DialogResult.OK)
                label1.Text = "ok";
            else if (a == DialogResult.Cancel)
                label1.Text = "cancel";
            else 
                label1.Text = "你点了×";


        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            Application.Exit();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           string b=Convert .ToString(k );
            if (k == 1)
            {
                
                label2.Text = b;
                k = k + 1;

            }
            else if (k != 1)
            {
                label2.Text = b;
                k = k + 1;
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            button7.Visible = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;


        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show ("你没有输入时间！请输入秒数", "no data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
            {
                System.Diagnostics.Process.Start("cmd.exe", "/c shutdown /s /t " + textBox1.Text);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("cmd.exe", "/c shutdown /a");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Visible = false;
            timer1.Enabled = false;

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {toolTip1.SetToolTip(this.textBox1, @"请输入阿拉伯数字");

        }
    }
}

