using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 登录密码
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            Random sj = new Random();
            int hengposition = sj.Next(0, this.Width);
            int shuposition = sj.Next(0, this.Height);
            button1.Location = new Point(hengposition, shuposition);
        }
        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("你还没点到呢，是要退出嘛？", "确定要退出吗？", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (msg==DialogResult.Yes)
            this.Close();
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.Red)
                button1.BackColor = Color.Black;
            else
                button1.BackColor = Color.Red;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = false;
            label2.Visible = false;
        }
        private void button2_MouseMove(object sender, MouseEventArgs e)
        {}

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(this.label2, "单击我开始游戏，如果你能点到按钮，那么不用密码就能退出哦~~~");
        }
    }
}
