using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;


namespace MediaCoderCracker
{
    
    public partial class FormMain : Form
    {
        [DllImport("User32.dll")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);   

        [DllImport("User32.DLL")]
        private static extern int FindWindowEx(int hwndParent, int hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("User32.DLL")]
        private static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);

        [DllImport("User32.DLL")]
        private static extern int SendMessage(int hWnd, int Msg, int wParam, string lParam);

        [DllImport("User32.DLL")]
        private static extern int GetWindowText(int hWnd, StringBuilder lpString, int nMaxCount);

        
        const int BM_CLICK = 0x00F5;
        const int WM_SETTEXT = 0x000C;


        public FormMain()
        {
            InitializeComponent();
        }

        private static int Calc(string input)
        {
            string[] arr = input.Replace("做一个简单算术题吧：", "").Split(' ');
            if(arr[1] == "+")
            {
                return int.Parse(arr[0]) + int.Parse(arr[2]);
            }

            if (arr[1] == "-")
            {
                return int.Parse(arr[0]) - int.Parse(arr[2]);
            }
            return 0;
        }
        
        private void Timer1Tick(object sender, EventArgs e)
        {
            try
            {
                int maindHwnd = FindWindow(null, "将在120分钟后自动继续");

                if(maindHwnd == 0)
                {
                    return;
                }

                int calcHwnd0 = FindWindowEx(maindHwnd, 0, "Static", null);
                int calcHwnd1 = FindWindowEx(maindHwnd, calcHwnd0, "Static", null);
                int calcHwnd2 = FindWindowEx(maindHwnd, calcHwnd1, "Static", null);
                int calcHwnd3 = FindWindowEx(maindHwnd, calcHwnd2, "Static", null);
                int calcHwnd4 = FindWindowEx(maindHwnd, calcHwnd3, "Static", null);

                StringBuilder msg = new StringBuilder(256);
                GetWindowText(calcHwnd4, msg, msg.Capacity);

                int i = Calc(msg.ToString());

                int childHwnd1 = FindWindowEx(maindHwnd, 0, "Edit", null);
                int childHwnd2 = FindWindowEx(maindHwnd, childHwnd1, "Edit", null);
                if (childHwnd2 != 0)
                {
                    SendMessage(childHwnd2, WM_SETTEXT, 0, i.ToString());
                }

                int buttonHwnd = FindWindowEx(maindHwnd, 0, "Button", "继续");
                if (buttonHwnd != 0)
                {
                    SendMessage(buttonHwnd, BM_CLICK, 0, 0);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonBenginClick(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
                buttonBengin.Text = "开始";
            }
            else
            {
                timer1.Enabled = true;
                buttonBengin.Text = "运行中";
            }
            
        }
    }
}
