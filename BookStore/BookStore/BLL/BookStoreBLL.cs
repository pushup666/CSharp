using System.Collections.Generic;
using System.Data;
using BookStore.DAL;
using BookStore.Model;


namespace BookStore.BLL
{
    static class BookStoreBLL
    {
        public static void CreateTable()
        {
            using var bookList = BookDAL.GetBookList();

            if (bookList == null)
            {
                BookStoreDAL.CreateTable();
            }
        }

        public static void VacuumDatabase()
        {
            LineDAL.ClearLines();
            VersionDAL.ClearVersion();
            BookDAL.ClearBook();

            BookStoreDAL.VacuumDatabase();
        }

        public static DataTable GetBookList()
        {
            return BookDAL.GetBookList();
        }

        public static DataTable GetBookList(string filterTitle, int filterRate, string filterLength)
        {
            return BookDAL.GetBookList(filterTitle, filterRate, filterLength);
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
            return VersionDAL.RemoveVersionByBookID(bookID) && BookDAL.RemoveBook(bookID);
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

        public static VersionDO GetLatestVersion(string bookID)
        {
            var versionNo = VersionDAL.GetNextVersionNo(bookID) - 1;
            return versionNo < 0 ? null : VersionDAL.GetVersion(bookID, versionNo);
        }

        public static bool AddVersion(VersionDO version)
        {
            version.VersionNo = VersionDAL.GetNextVersionNo(version.BookID);
            return VersionDAL.AddVersion(version) && BookDAL.ModifyBookLength(version.BookID, version.ContentLength);
        }

        public static bool RemoveVersion(string versionID)
        {
            return VersionDAL.RemoveVersion(versionID);
        }

        public static bool IsThisHashExist(string hash)
        {
            return VersionDAL.IsThisHashExist(hash);
        }




        public static DataTable GetLineList(string bookID)
        {
            return LineDAL.GetLineList(bookID);
        }

        public static bool Version2Lines(string bookID, List<string> lines)
        {
            return LineDAL.ClearLines(bookID) && LineDAL.Version2Lines(bookID, lines);
        }

        public static string Lines2String(string bookID)
        {
            return LineDAL.Lines2String(bookID);
        }

        public static bool DeleteLines(List<string> lineIDList)
        {
            return LineDAL.DeleteLines(lineIDList);
        }
    }
}