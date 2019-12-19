using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;


namespace SysMonTest
{
    public partial class SysMonTest : Form
    {
        public SysMonTest()
        {
            InitializeComponent();
        }

        private void SysMonTest_Load(object sender, EventArgs e)
        {
            timerMain.Interval = 1000;
            timerMain.Enabled = true;
        }

        private void TimerMain_Tick(object sender, EventArgs e)
        {
            using (var bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            {
                using (var g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(new Point(0, 0), new Point(0, 0), bmp.Size);
                    bmp.Save($@"C:\Codec\{DateTime.Now:yyyyMMddHHmmssffff}.jpg",ImageFormat.Jpeg);
                }
            }
        }
    }
}
