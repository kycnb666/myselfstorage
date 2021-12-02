using System;


using System.Threading;

namespace automaticshutdown
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            while (true)
            {
                DateTime time = DateTime.Now;
                Thread.Sleep(500);
                if (time.ToString("Hmm") == "1153")
                {
                    System.Diagnostics.Process.Start("cmd /c" + "shutdown /s /t 30");
                    Environment.Exit(0);
                }else if (time.ToString("Hmm")=="2215")
                {
                    System.Diagnostics.Process.Start("cmd /c" + "shutdown /s /t 30");
                    Environment.Exit(0);
                }

                
            }
        }
    }
}
