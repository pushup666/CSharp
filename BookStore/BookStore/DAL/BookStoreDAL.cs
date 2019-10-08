using System.Collections.Generic;

namespace BookStore.DAL
{
    static class BookStoreDAL
    {
        public static void CreateTable()
        {
            var sqls = new List<string>
            {
                "CREATE TABLE Book (" +
                "ID TEXT PRIMARY KEY NOT NULL, " +
                "Title TEXT NOT NULL, " +
                "Alias TEXT, " +
                "Author TEXT, " +
                "Note TEXT, " +
                "Rate INTEGER DEFAULT(0) NOT NULL, " +
                "Length INTEGER DEFAULT(0) NOT NULL, " +
                "DeleteFlag INTEGER DEFAULT(0) NOT NULL); ",

                "CREATE TABLE Version (" +
                "ID TEXT PRIMARY KEY NOT NULL, " +
                "BookID TEXT NOT NULL REFERENCES Book (ID), " +
                "VersionNo INTEGER NOT NULL, " +
                "Content TEXT NOT NULL, ContentHash TEXT NOT NULL, " +
                "ContentLength INTEGER NOT NULL, " +
                "DeleteFlag INTEGER NOT NULL DEFAULT(0)); ",

                "CREATE TABLE Line(" +
                "ID TEXT PRIMARY KEY NOT NULL, " +
                "BookID TEXT REFERENCES Book(ID) NOT NULL, " +
                "LineNo INTEGER NOT NULL, " +
                "Content TEXT NOT NULL); "
            };

            SqliteHelper.ExecuteNonQueryBat(sqls);
        }

        public static void VacuumDatabase()
        {
            var sql = "VACUUM;";
            SqliteHelper.ExecuteNonQuery(sql);
        }
    }
}