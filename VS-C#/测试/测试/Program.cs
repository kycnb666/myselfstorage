using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace 测试
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            
            DialogResult  msg = MessageBox.Show("open window?","pls confirm",MessageBoxButtons.OKCancel);
            if (msg ==DialogResult.OK)
            {
                Application.Run(new Form1());
            }else
            {
                MessageBox.Show("programme will still run in background!", "msg");
                DateTime time = DateTime.Now;
                MessageBox.Show(time.ToString("Hmm"));


                Application.Run();
                
                
                    

                    
                   
                        
                    
                

            }
        }
    }
}
