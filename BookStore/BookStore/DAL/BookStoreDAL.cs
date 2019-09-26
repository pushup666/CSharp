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
        //INSERT INTO Book(UID, Title, Alias, Author, Note, Rate, DeleteFlag) VALUES(@UID, @Title, @Alias, @Author, @Note, @Rate, @DeleteFlag);
        //INSERT INTO Version(UID, BookID, VersionNo, Content, ContentHash, ContentLength) VALUES(@UID, @BookID, @VersionNo, @Content, @ContentHash, @ContentLength);
        //INSERT INTO Line(UID, VersionID, LineNo, Content) VALUES(@UID, @VersionID, @LineNo, @Content);

        public static bool CreateTable()
        {
            var sqls = new List<string>();

            sqls.Add("CREATE TABLE Book ( UID CHAR (32) PRIMARY KEY NOT NULL, Title VARCHAR (100) NOT NULL, Alias VARCHAR (100), Author VARCHAR (100), Note VARCHAR (100), Rate INTEGER DEFAULT (0) NOT NULL, DeleteFlag INTEGER DEFAULT (0) NOT NULL);");
            sqls.Add("CREATE TABLE Version ( UID CHAR (32) PRIMARY KEY NOT NULL, BookID CHAR (32) NOT NULL REFERENCES Book (UID), VersionNo INTEGER NOT NULL DEFAULT (1), Content TEXT NOT NULL, ContentHash CHAR (32) NOT NULL, ContentLength INTEGER NOT NULL, DeleteFlag INTEGER NOT NULL DEFAULT (0) );");
            sqls.Add("CREATE TABLE Line ( UID CHAR (32) PRIMARY KEY NOT NULL, VersionID CHAR (32) REFERENCES Version (UID) NOT NULL, LineNo INTEGER NOT NULL DEFAULT (1), Content TEXT NOT NULL, DeleteFlag INTEGER NOT NULL DEFAULT (0) );");

            return SqliteHelper.ExecuteNonQueryBat(sqls) != -1;
        }
    }
}
