using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace 冻结恢复进程
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) { MessageBox.Show("请先选择你要冻结的程序！", "未选择", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else
            {
                Process[] pros = Process.GetProcessesByName(listBox1.SelectedItem.ToString());
                DialogResult msg = MessageBox.Show($"确定要冻结{listBox1.SelectedItem.ToString()}吗？", "请确认", MessageBoxButtons.YesNo);
                if (msg == DialogResult.Yes)
                    ProcessMgr.SuspendProcess(pros[0].Id);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) { MessageBox.Show("请先选择你要恢复的程序！", "未选择", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else
            {
                Process[] pros = Process.GetProcessesByName(listBox1.SelectedItem.ToString());
                ProcessMgr.ResumeProcess(pros[0].Id);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();
            foreach(Process proc in processes)
            {
                if(proc.ProcessName!="svchost")
                listBox1.Items.Add(proc.ProcessName);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i=0;
            Process[] processes = Process.GetProcesses();
            foreach (Process proc in processes)
            {
                if (proc.ProcessName != "svchost")
                    ++i;
            }label1.Text= $"已读取到{i.ToString()}个进程";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Process[] processes = Process.GetProcesses();
            foreach (Process proc in processes)
            {
                if (proc.ProcessName != "svchost")
                    listBox1.Items.Add(proc.ProcessName);
            }
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(this.label2, "请先确认你要冻结的程序再继续！\n谨慎操作，防止冻到系统进程！");
        }
    }
}
