using System.Collections.Generic;
using System.Data;
using BookStore.DAL;
using BookStore.Model;

namespace BookStore.BLL
{
    static class BookStoreBLL
    {
        public static DataTable GetBookList()
        {
            return BookDAL.GetBookList();
        }

        public static BookDO GetBook(string bookID)
        {
            return BookDAL.GetBook(bookID);
        }

        public static bool AddBook(BookDO book)
        {
            return BookDAL.AddBook(book);
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

        public static bool AddVersion(VersionDO version)
        {
            return VersionDAL.AddVersion(version);
        }

        public static bool IsThisHashExist(string hash)
        {
            return VersionDAL.IsThisHashExist(hash);
        }


        public static DataTable GetLineList(string versionID)
        {
            return LineDAL.GetLineList(versionID);
        }

        public static bool Version2Lines(string versionID, List<string> lines)
        {
            return LineDAL.Version2Lines(versionID, lines);
        }
    }
}