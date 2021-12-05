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
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

namespace 登录密码
{
    
    public partial class Form1 : Form
    {
        public static void diaoyong(string x,string y)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = x;
            proc.StartInfo.Arguments = y;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Start();
            proc.WaitForExit();
        }
        public string jiemi(string jiemipw)
        {
            string jiemibase64;
            byte[] bytes = System.Convert.FromBase64String(jiemipw);
            jiemibase64 = System.Text.Encoding.UTF8.GetString(bytes);
            return jiemibase64;
        }
        public static string jiema(string s)
        {
            System.Text.RegularExpressions.CaptureCollection cs =
                System.Text.RegularExpressions.Regex.Match(s, @"([01]{8})+").Groups[1].Captures;
            byte[] data = new byte[cs.Count];
            for (int i = 0; i < cs.Count; i++)
            {
                data[i] = Convert.ToByte(cs[i].Value, 2);
            }
            return Encoding.Unicode.GetString(data, 0, data.Length);
        }
        public static class ProcessMgr
        {
            [Flags]
            public enum ProcessAccess : uint
            {
                Terminate = 0x1,
                CreateThread = 0x2,
                SetSessionId = 0x4,
                VmOperation = 0x8,
                VmRead = 0x10,
                VmWrite = 0x20,
                DupHandle = 0x40,
                CreateProcess = 0x80,
                SetQuota = 0x100,
                SetInformation = 0x200,
                QueryInformation = 0x400,
                SetPort = 0x800,
                SuspendResume = 0x800,
                QueryLimitedInformation = 0x1000,
                Synchronize = 0x100000
            }

            [DllImport("ntdll.dll")]
            private static extern uint NtResumeProcess([In] IntPtr processHandle);

            [DllImport("ntdll.dll")]
            private static extern uint NtSuspendProcess([In] IntPtr processHandle);

            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern IntPtr OpenProcess(
                ProcessAccess desiredAccess,
                bool inheritHandle,
                int processId);

            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool CloseHandle([In] IntPtr handle);

            public static void SuspendProcess(int processId)
            {
                IntPtr hProc = IntPtr.Zero;
                try
                {
                    hProc = OpenProcess(ProcessAccess.SuspendResume, false, processId);
                    if (hProc != IntPtr.Zero)
                        NtSuspendProcess(hProc);
                }
                finally
                {
                    if (hProc != IntPtr.Zero)
                        CloseHandle(hProc);
                }
            }

            public static void ResumeProcess(int processId)
            {
                IntPtr hProc = IntPtr.Zero;
                try
                {
                    hProc = OpenProcess(ProcessAccess.SuspendResume, false, processId);
                    if (hProc != IntPtr.Zero)
                        NtResumeProcess(hProc);
                }
                finally
                {
                    if (hProc != IntPtr.Zero)
                        CloseHandle(hProc);
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        //标志描述：
        const int AW_SLIDE = 0x40000;//使用滑动类型。缺省则为滚动动画类型。当使用AW_CENTER标志时，这个标志就被忽略。
        const int AW_ACTIVATE = 0x20000;//激活窗口。在使用了AW_HIDE标志后不要使用这个标志。
        const int AW_BLEND = 0x80000;//使用淡出效果。只有当hWnd为顶层窗口的时候才可以使用此标志。
        const int AW_HIDE = 0x10000;//隐藏窗口，缺省则显示窗口。(关闭窗口用)
        const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；若未使用AW_HIDE标志，则使窗口向外扩展。
        const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。
        const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。
        const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。
        const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "GetForegroundWindow", CharSet = System.Runtime.InteropServices.CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetF(); //获得本窗体的句柄
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetF(IntPtr hWnd); //设置此窗体为活动窗体
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Process[] pros = Process.GetProcesses();
            foreach (Process pro in pros)
            {
                if (pro.ProcessName.ToUpper() == "TASKMGR")
                {
                    pro.Kill();
                }
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string pw = textBox1.Text;
            try
            {
                if (!File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm"))
                {
                    MessageBox.Show("密码未设置！请先进入更改密码里设置密码！");
                }
                else
                {
                    StreamReader streamReader = new StreamReader($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm");
                    string a = streamReader.ReadToEnd();
                    string pwd = jiema(jiemi(a));
                    streamReader.Close();
                    if (pw == pwd)
                    {
                        Process[] pros = Process.GetProcessesByName("explorer");
                        ProcessMgr.ResumeProcess(pros[0].Id);
                        new Form3().ShowDialog(this);
                        diaoyong("cmd.exe", "/c taskkill /f /im \"火绒安全软件 安全辅助模块.exe\"");
                        this.Close();
                    }
                    else if (pw == "")
                    {
                        new Form2().ShowDialog(this);  //showdialog为打开第二个窗口时设置焦点
                        this.textBox1.Focus();
                    }
                    else
                    {
                        new Form2().ShowDialog(this);
                        this.textBox1.Focus();
                    }
                }
                
            }
            catch (Exception exobj){ MessageBox.Show(exobj.ToString(),"oh shitttt!!!!!"); }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {}
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm"))
                {
                    MessageBox.Show("密码未设置！请先进入更改密码里设置密码！");
                    e.Cancel = true;
                }
                else
                {
                    StreamReader streamReader = new StreamReader($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm");
                    string a = streamReader.ReadToEnd();
                    string pwd = jiema(jiemi(a));
                    streamReader.Close();
                    if (textBox1.Text == "")
                    {
                        new Form4().ShowDialog(this);
                        e.Cancel = true;
                    }
                    else if (textBox1.Text == pwd)
                    {
                        Process[] pros = Process.GetProcessesByName("explorer");
                        ProcessMgr.ResumeProcess(pros[0].Id);
                        diaoyong("cmd.exe", "/c taskkill /f /im \"火绒安全软件 安全辅助模块.exe\"");
                        AnimateWindow(this.Handle, 1000, AW_HIDE | AW_CENTER);

                    }
                    else
                    {
                        new Form4().ShowDialog(this);
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception exobj) { MessageBox.Show(exobj.ToString(), "oh shitttt!!!!!"); }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\mmts"))
            {
                label2.Text = "密码提示：暂无";
                label2.Visible = true;
            }
            else
            {
                StreamReader streamReader = new StreamReader($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\mmts");
                string a = streamReader.ReadToEnd();
                string ts = jiema(jiemi(a));
                streamReader.Close();
                label2.Text= "密码提示："+ts;
                label2.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AW_CENTER);
            Process[] pros = Process.GetProcessesByName("explorer");
            ProcessMgr.SuspendProcess(pros[0].Id);
            if (!File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\dlmm"))
            {
                DialogResult msg = MessageBox.Show("首次使用，请您前往设置密码\n点击‘是’立即设置，‘否’则退出", "您是否为第一次使用本软件？", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (msg == DialogResult.Yes)
                {
                    new Form6().ShowDialog(this);
                }else if(msg == DialogResult.No)
                {
                    diaoyong("cmd.exe", "/c taskkill /f /im \"火绒安全软件 安全辅助模块.exe\"");
                    ProcessMgr.ResumeProcess(pros[0].Id);
                    Environment.Exit(0);
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {}

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (label1.Visible)
                label1.Visible = false;
            else
                label1.Visible = true;


        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        { 
            if(e.KeyCode == Keys.LWin)
            {
                if (this.Handle != GetF()) //如果本窗口没有获得焦点
                    SetF(this.Handle); //设置本窗口获得焦点
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new Form5().ShowDialog(this);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new Form6().ShowDialog(this);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '\0';
            pictureBox2.Visible = true;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '*';
            pictureBox2.Visible = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {  }
    }
}
