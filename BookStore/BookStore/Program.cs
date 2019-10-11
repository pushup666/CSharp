using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BookStore
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            SQLiteFunction.RegisterFunction(typeof(SQLitePinYingSort));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmBookStore());
        }
    }
}
