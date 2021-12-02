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

namespace 遍历文件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo TheFolder = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            //遍历文件夹
            foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
            {
                if (NextFolder.Name != "课件" && NextFolder.Name != "软件" && NextFolder.Name != "杂物" && NextFolder.Name != "语文")
                {
                   Process.Start("cmd.exe", $"/c move \"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\{NextFolder.Name}\" \"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\杂物\\杂七杂八的文件夹\\\"");
                }
            }
            //遍历文件
            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                bool isHidden = ((File.GetAttributes($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\{NextFile}") & FileAttributes.Hidden) == FileAttributes.Hidden);
                if (isHidden != true)
                {
                    string extension = Path.GetExtension($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\{ NextFile.Name}");
                    if ( extension == ".zip"||extension==".txt")
                     Process.Start("cmd.exe",$"/c move \"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\{NextFile.Name}\" \"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\杂物\\\"");
                    else if (extension == ".pptx"||extension==".doc"||extension==".docx"||extension==".ppt"||extension==".xlsx"||extension==".xls"||extension==".pdf"||extension==".et") 
                     Process.Start("cmd.exe", $"/c move \"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\{NextFile.Name}\" \"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\课件\\\"");
                    else if (extension == ".lnk") 
                     Process.Start("cmd.exe", $"/c move \"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\{NextFile.Name}\" \"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\软件\\\""); 
                    else if(extension==".jpg"|| extension == ".png" || extension == ".bmp" || extension == ".ico" || extension == ".jpeg"||extension == ".gif"  )
                     Process.Start("cmd.exe", $"/c move \"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\{NextFile.Name}\" \"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\杂物\\图片\\\"");
                    else if(extension==".mp3"||extension==".mp4"||extension==".avi"||extension==".m4a")
                     Process.Start("cmd.exe", $"/c move \"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\{NextFile.Name}\" \"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\杂物\\视频与音频\\\"");

                }
               
            }
            MessageBox.Show("整理完毕！", "success!!!", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
