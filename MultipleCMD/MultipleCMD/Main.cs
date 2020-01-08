﻿using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MultipleCMD
{
    public partial class Main : Form
    {
        private int _finishLines;
        private int _allLines;

        private delegate void SetLabelCountTextCallback(string txt);

        public Main()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            ThreadPool.SetMinThreads(1, 1);
            ThreadPool.SetMaxThreads(4, 4);

            _finishLines = 0;
            _allLines = richTextBoxCmdInput.Lines.Length;
            richTextBoxCmdInput.Enabled = false;

            SetLabelCountText($@"{_finishLines} / {_allLines}");

            foreach (var cmdArguments in richTextBoxCmdInput.Lines)
            {
                ThreadPool.QueueUserWorkItem(ExecCmd, cmdArguments);
            }
        }


        private void ExecCmd(object cmdArguments)
        {
            try
            {
                var p = new Process();

                p.StartInfo.WorkingDirectory = textBoxWorkingDirectory.Text;
                p.StartInfo.FileName = textBoxFileName.Text;

                //p.StartInfo.WorkingDirectory = @"D:\Music";
                //p.StartInfo.FileName = "SpectrumPicAnalysis";

                p.StartInfo.Arguments = cmdArguments.ToString();
                p.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;

                p.Start();
                p.WaitForExit();
                p.Close();

                _finishLines++;
                SetLabelCountText($@"{_finishLines} / {_allLines}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n跟踪;" + ex.StackTrace);
            }
        }

        private void SetLabelCountText(string txt)
        {
            if (labelCount.InvokeRequired)
            {
                while (labelCount.IsHandleCreated == false)
                {
                    if (labelCount.Disposing || labelCount.IsDisposed) return;
                }

                var d = new SetLabelCountTextCallback(SetLabelCountText);
                labelCount.Invoke(d, txt);
            }
            else
            {
                labelCount.Text = txt;
            }
        }

        private void ButtonGenCMD_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            foreach (var line in richTextBoxCmdInput.Lines)
            {
                //sb.AppendLine($"-i \"{line}\" -lavfi showspectrumpic=legend=false \"{line}.png\"");
                sb.AppendLine($"you-get \"{line}\"");
            }
            richTextBoxCmdInput.Text = sb.ToString().TrimEnd();
        }
    }
}
