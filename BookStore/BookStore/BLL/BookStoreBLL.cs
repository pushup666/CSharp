﻿using System.Collections.Generic;
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

        public static bool VacuumDatabase()
        {
            if (LineDAL.ClearLines() && VersionDAL.ClearVersion() && BookDAL.ClearBook())
            {
                BookStoreDAL.VacuumDatabase();
                return true;
            }

            return false;
        }

        public static DataTable GetBookList()
        {
            return BookDAL.GetBookList();
        }

        public static DataTable GetBookList(string filterTitle, string filterRate, string orderBy)
        {
            return BookDAL.GetBookList(filterTitle, filterRate, orderBy);
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

        private static bool UpdateBookLengthAndModifyDate(string bookID)
        {
            var version = GetLatestVersion(bookID);
            if (version == null)
            {
                return false;
            }
            return BookDAL.UpdateBookLengthAndModifyDate(version.BookID, version.ContentLength);
        }

        public static bool UpdateBookLastRead(string bookID, int lastReadPosition)
        {
            return BookDAL.UpdateBookLastRead(bookID, lastReadPosition);
        }

        public static int GetBookLastReadPosition(string bookID)
        {
            return BookDAL.GetBookLastReadPosition(bookID);
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
            return VersionDAL.AddVersion(version) && UpdateBookLengthAndModifyDate(version.BookID);
        }

        public static bool RemoveVersion(string bookID, string versionID)
        {
            return VersionDAL.RemoveVersion(versionID) && UpdateBookLengthAndModifyDate(bookID);
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