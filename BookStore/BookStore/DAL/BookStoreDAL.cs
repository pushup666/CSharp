using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStore.Model;

namespace BookStore.DAL
{
    class BookStoreDAL
    {
        public static bool isThisHashExist(string hash)
        {
            const string sql = "SELECT UID FROM Version WHERE ContentHash = @ContentHash;";
            var UID = SqliteHelper.ExecuteScalar(sql, new SQLiteParameter("@ContentHash", DbType.String) { Value = hash });

            return UID != null;
        }

        public static bool AddBook(BookDO book)
        {
            return true;
        }
    }
}
