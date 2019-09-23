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
            return VersionDAL.IsThisHashExist(hash);
        }

        public static bool AddBook(BookDO book)
        {
            return BookDAL.AddBook(book);
        }

        public static DataTable GetBookList()
        {
            return BookDAL.GetBookList();
        }

        public static bool AddVersion(VersionDO version)
        {
            return VersionDAL.AddVersion(version);
        }

        public static BookDO GetBook(string bookID)
        {
            return BookDAL.GetBook(bookID);
        }

        public static bool RemoveBook(BookDO book)
        {
            return BookDAL.RemoveBook(book);
        }

        public static bool ModifyBook(BookDO book)
        {
            return BookDAL.ModifyBook(book);
        }

        public static DataTable GetVersionList(string bookID)
        {
            return VersionDAL.GetVersionList(bookID);
        }

        public static VersionDO GetVersion(string bookID, int versionNo)
        {
            return VersionDAL.GetVersion(bookID, versionNo);
        }
    }
}