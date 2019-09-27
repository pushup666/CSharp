using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.DAL
{
    class BookStoreDAL
    {
        public static bool CreateTable()
        {
            var sqls = new List<string>();

            sqls.Add(
                "CREATE TABLE Book (" +
                "ID TEXT PRIMARY KEY NOT NULL, " +
                "Title TEXT NOT NULL, " +
                "Alias TEXT, " +
                "Author TEXT, " +
                "Note TEXT, " +
                "Rate INTEGER DEFAULT(0) NOT NULL, " +
                "DeleteFlag INTEGER DEFAULT(0) NOT NULL); ");

            sqls.Add(
                "CREATE TABLE Version (" +
                "ID TEXT PRIMARY KEY NOT NULL, " +
                "BookID TEXT NOT NULL REFERENCES Book (ID), " +
                "VersionNo INTEGER NOT NULL, " +
                "Content TEXT NOT NULL, ContentHash TEXT NOT NULL, " +
                "ContentLength INTEGER NOT NULL, " +
                "DeleteFlag INTEGER NOT NULL DEFAULT(0)); ");

            sqls.Add(
                "CREATE TABLE Line(" +
                "ID TEXT PRIMARY KEY NOT NULL, " +
                "BookID TEXT REFERENCES Book(ID) NOT NULL, " +
                "LineNo INTEGER NOT NULL, " +
                "Content TEXT NOT NULL); ");

            return SqliteHelper.ExecuteNonQueryBat(sqls) != -1;
        }
    }

}