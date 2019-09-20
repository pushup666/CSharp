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
        public static bool IsThisHashExist(string hash)
        {
            const string sql = "SELECT UID FROM Version WHERE ContentHash = @ContentHash;";
            var UID = SqliteHelper.ExecuteScalar(sql, new SQLiteParameter("@ContentHash", DbType.String) { Value = hash });

            return UID != null;
        }

        //INSERT INTO Book(UID, Title, Alias, Author, Note, Rate, DeleteFlag) VALUES(@UID, @Title, @Alias, @Author, @Note, @Rate, @DeleteFlag);
        //INSERT INTO Version(UID, BookID, VersionNo, Content, ContentHash, ContentLength) VALUES(@UID, @BookID, @VersionNo, @Content, @ContentHash, @ContentLength);
        //INSERT INTO Line(UID, VersionID, LineNo, Content) VALUES(@UID, @VersionID, @LineNo, @Content);
        public static bool AddBook(BookDO book)
        {
            const string sql = "INSERT INTO Book(UID, Title, Alias, Author, Note) VALUES(@UID, @Title, @Alias, @Author, @Note);";
            var pms = new SQLiteParameter[]
            {
                new SQLiteParameter("@UID", DbType.String){Value = book.UID},
                new SQLiteParameter("@Title", DbType.String){Value = book.Title},
                new SQLiteParameter("@Alias", DbType.String){Value = book.Alias},
                new SQLiteParameter("@Author", DbType.String){Value = book.Author},
                new SQLiteParameter("@Note", DbType.String){Value = book.Note},
            };

            return SqliteHelper.ExecuteNonQuery(sql, pms) != -1;
        }

        public static DataTable GetBookList()
        {
            var sql = "SELECT Title, Alias, Author, Note, Rate FROM Version WHERE DeleteFlag = 0;";
            return SqliteHelper.ExecuteReader(sql);
        }

        public static bool AddVersion(VersionDO version)
        {
            var sql = "SELECT VersionNo FROM Version WHERE BookID = @BookID;";
            var versionNo = SqliteHelper.ExecuteScalar(sql, new SQLiteParameter("@BookID", DbType.String) { Value = version.BookID });
            if (versionNo == null)
            {
                version.VersionNo = 1;
            }
            else
            {
                version.VersionNo = (int) versionNo + 1;
            }

            sql = "INSERT INTO Version(UID, BookID, VersionNo, Content, ContentHash, ContentLength) VALUES(@UID, @BookID, @VersionNo, @Content, @ContentHash, @ContentLength);";
            var pms = new SQLiteParameter[]
            {
                new SQLiteParameter("@UID", DbType.String){Value = version.UID},
                new SQLiteParameter("@BookID", DbType.String){Value = version.BookID},
                new SQLiteParameter("@VersionNo", DbType.String){Value = version.VersionNo},
                new SQLiteParameter("@Content", DbType.String){Value = version.Content},
                new SQLiteParameter("@ContentHash", DbType.String){Value = version.ContentHash},
                new SQLiteParameter("@ContentLength", DbType.Int32){Value = version.ContentLength},
            };

            return SqliteHelper.ExecuteNonQuery(sql, pms) != -1;
        }
    }
}
