using System.Collections.Generic;
using System.Data;
using BookStore.DAL;
using BookStore.Model;

namespace BookStore.BLL
{
    static class BookStoreBLL
    {
        public static bool CreateTable()
        {
            return BookStoreDAL.CreateTable();
        }

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

        public static bool RemoveBook(string bookID)
        {
            return BookDAL.RemoveBook(bookID);
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
            version.VersionNo = VersionDAL.GetNextVersionNo(version.BookID);
            return VersionDAL.AddVersion(version);
        }

        public static bool RemoveVersion(string versionID)
        {
            return VersionDAL.RemoveVersion(versionID);
        }

        public static bool IsThisHashExist(string hash)
        {
            return VersionDAL.IsThisHashExist(hash);
        }

        public static bool IsVersionLineHashMatch(string versionID)
        {
            var versionHash = VersionDAL.GetVersion(versionID).ContentHash;

            var dt = LineDAL.GetLineList(versionID);

            return true;
        }





        public static DataTable GetLineList(string versionID)
        {
            return LineDAL.GetLineList(versionID);
        }

        public static bool Version2Lines(string versionID, List<string> lines)
        {
            return LineDAL.RemoveLines(versionID) && LineDAL.Version2Lines(versionID, lines);
        }
    }
}