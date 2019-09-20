using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStore.DAL;
using BookStore.Model;

namespace BookStore.BLL
{
    class BookStoreBLL
    {
        public static bool IsThisHashExist(string hash)
        {
            return BookStoreDAL.IsThisHashExist(hash);
        }

        public static bool AddBook(BookDO book)
        {
            return BookStoreDAL.AddBook(book);
        }

        public static DataTable GetBookList()
        {
            return BookStoreDAL.GetBookList();
        }

        public static bool AddVersion(VersionDO version)
        {
            return BookStoreDAL.AddVersion(version);
        }
    }
}
