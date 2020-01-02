using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace SysMonTest
{
    public partial class SysMonTest : Form
    {
        [StructLayout(LayoutKind.Sequential)]
        struct CURSORINFO
        {
            public int cbSize;
            public int flags;
            public IntPtr hCursor;
            public POINTAPI ptScreenPos;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct POINTAPI
        {
            public int x;
            public int y;
        }

        [DllImport("user32.dll")]
        private static extern bool GetCursorInfo(out CURSORINFO pci);

        [DllImport("user32.dll")]
        private static extern bool DrawIcon(IntPtr hDC, int x, int y, IntPtr hIcon);

        private readonly string _folderName = $@"C:\Codec\SysMon\{DateTime.Now:yyyyMMddHHmmss}";
        private static int _fileNameNo = 1;


        private static Bitmap CaptureScreen(bool captureMouse)
        {
            var result = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format24bppRgb);

            try
            {
                using (var g = Graphics.FromImage(result))
                {
                    g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

                    if (captureMouse)
                    {
                        if (GetCursorInfo(out var pci))
                        {
                            if (pci.flags == 1)
                            {
                                DrawIcon(g.GetHdc(), pci.ptScreenPos.x, pci.ptScreenPos.y, pci.hCursor);
                                g.ReleaseHdc();
                            }
                        }
                    }
                }
            }
            catch
            {
                result = null;
            }

            return result;
        }

        public SysMonTest()
        {
            InitializeComponent();
        }

        private void SysMonTest_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(_folderName))
            {
                Directory.CreateDirectory(_folderName);
            }

            timerMain.Interval = 5000;
            timerMain.Enabled = true;
        }

        private void TimerMain_Tick(object sender, EventArgs e)
        {
            using (var bmp = CaptureScreen(true))
            {
                bmp.Save($@"{_folderName}\Sample{_fileNameNo++.ToString().PadLeft(5, '0')}.dat", ImageFormat.Jpeg);
            }
        }
    }
}