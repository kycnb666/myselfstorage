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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide  ();
            new Form1().Show();
            

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(this.textBox1, @"请在此输入网址
需要完整的网址 
例如上百度要填入http://www.baidu.com
而不是填 www.baidu.com");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1 .Text == "")
            {
                MessageBox.Show("你没有输入网址！", "没有网址", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                
                string s = textBox1.Text;
                bool iscontain = (s.Contains("http"));
                if (iscontain == false)
                {
                    MessageBox.Show("不是完整的网址");

                }
                else if (iscontain ==true)
                {
                    Uri uri = new Uri(s);
                    webBrowser1.Url = uri;
                }
                

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                string d = "http://www.baidu.com";
                Uri uri=new Uri(d);
                webBrowser1.Url = uri ;

            }
            else if (textBox1 .Text != "")
            {
                string s = textBox1.Text;
                Uri uri = new Uri(s);
                webBrowser1.Url = uri;
            }
        }
    }
}



