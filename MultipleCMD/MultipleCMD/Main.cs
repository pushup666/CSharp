using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace MultipleCMD
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            ThreadPool.SetMinThreads(1, 1);
            ThreadPool.SetMaxThreads(5, 5);

            foreach (var cmdArguments in richTextBoxCmdInput.Lines)
            {
                ThreadPool.QueueUserWorkItem(ExecCmd, cmdArguments);
            }
        }


        private void ExecCmd(object cmdArguments)
        {
            try
            {
                Process p = new Process();

                p.StartInfo.WorkingDirectory = @"D:\Git\you-get";
                p.StartInfo.FileName = "python";
                p.StartInfo.Arguments = cmdArguments.ToString();

                p.Start();
                p.WaitForExit();
                p.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n跟踪;" + ex.StackTrace);
            }
        }
    }
}
