using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace 测试
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            while (true)
            {
                Thread.Sleep(10);
                Application.DoEvents();
                if (time.ToString("Hmm") == "2210")
                {
                    MessageBox.Show("time up");
                }
            }

        }
    }
}
