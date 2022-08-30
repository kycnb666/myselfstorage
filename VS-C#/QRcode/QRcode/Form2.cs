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

namespace QRcode
{
    public partial class Form2 : Form
    {
        private bool down = false;
        private Point firstPoint;
        private Pen p = new Pen(Color.Red);
        private Graphics gra;
        private Rectangle rectangle;//存储用户截取的矩形
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Image img = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);//创建一个和屏幕同样大小的图像
            Graphics g = Graphics.FromImage(img);//绘制这个图像
                                                 //将屏幕绘制到此图像，第一，二个Point是屏幕要截取的左上角的坐标和绘制到图像的左上角的坐标（哪个是哪个就忘了）
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size);
            this.BackgroundImage = img;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            gra = this.CreateGraphics();//主要为了用户截取方便
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                down = true;
                firstPoint = e.Location;
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                down = false;
            }
            if (e.Button == MouseButtons.Right)
            {
                this.Close();
            }
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (down)
            {
                gra.DrawImage(this.BackgroundImage, 0, 0);
                rectangle = new Rectangle(Math.Min(firstPoint.X, e.X), Math.Min(e.Y, firstPoint.Y), Math.Abs(e.X - firstPoint.X), Math.Abs(e.Y - firstPoint.Y));
                gra.DrawRectangle(p, rectangle);
            }
        }

        private void Form2_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void Form2_Click(object sender, EventArgs e)
        {
            if (rectangle.Width != 0 && rectangle.Height != 0)
            {
                gra.DrawImage(this.BackgroundImage, 0, 0);
                Image im = new Bitmap(rectangle.Width, rectangle.Height);
                Graphics g = Graphics.FromImage(im);
                g.CopyFromScreen(rectangle.Location, new Point(0, 0), rectangle.Size);
                if (((MouseEventArgs)e).Button == MouseButtons.Left)
                {
                    im.Save($"{Path.GetTempPath()}jietu.png");
                    this.Close();
                }
                if (((MouseEventArgs)e).Button == MouseButtons.Right)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        im.Save(saveFileDialog1.FileName);
                        MessageBox.Show("图像已经保存到本地！", "保存成功");
                        this.Close();
                    }
                }
            }
        }
    }
}
