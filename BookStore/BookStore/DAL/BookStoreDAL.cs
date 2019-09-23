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
        //INSERT INTO Book(UID, Title, Alias, Author, Note, Rate, DeleteFlag) VALUES(@UID, @Title, @Alias, @Author, @Note, @Rate, @DeleteFlag);
        //INSERT INTO Version(UID, BookID, VersionNo, Content, ContentHash, ContentLength) VALUES(@UID, @BookID, @VersionNo, @Content, @ContentHash, @ContentLength);
        //INSERT INTO Line(UID, VersionID, LineNo, Content) VALUES(@UID, @VersionID, @LineNo, @Content);


        
    }

    class BookDAL
    {
        public static BookDO GetBook(string bookID)
        {
            const string sql = "SELECT * FROM Book WHERE DeleteFlag = 0 AND UID = @UID;";
            var pms = new SQLiteParameter[]
            {
                new SQLiteParameter("@UID", DbType.String){Value = bookID},
            };
            var book = SqliteHelper.ExecuteReader(sql, pms);

            return book.Rows.Count == 1 ? new BookDO(book.Rows[0]["UID"].ToString(), book.Rows[0]["Title"].ToString(), book.Rows[0]["Alias"].ToString(), book.Rows[0]["Author"].ToString(), book.Rows[0]["Note"].ToString(), int.Parse(book.Rows[0]["Rate"].ToString())) : null;
        }

        public static DataTable GetBookList()
        {
            const string sql = "SELECT UID, Title, Alias, Author, Note, Rate FROM Book WHERE DeleteFlag = 0;";

            return SqliteHelper.ExecuteReader(sql);
        }

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

        public static bool ModifyBook(BookDO book)
        {
            const string sql = "UPDATE Book SET Title = @Title, Alias = @Alias, Author = @Author, Note = @Note, Rate = @Rate WHERE UID = @UID;";
            var pms = new SQLiteParameter[]
            {
                new SQLiteParameter("@Title", DbType.String){Value = book.Title},
                new SQLiteParameter("@Alias", DbType.String){Value = book.Alias},
                new SQLiteParameter("@Author", DbType.String){Value = book.Author},
                new SQLiteParameter("@Note", DbType.String){Value = book.Note},
                new SQLiteParameter("@Rate", DbType.Int32){Value = book.Rate},
                new SQLiteParameter("@UID", DbType.String){Value = book.UID},
            };

            return SqliteHelper.ExecuteNonQuery(sql, pms) != -1;
        }

        public static bool RemoveBook(BookDO book)
        {
            const string sql = "UPDATE Book SET DeleteFlag = 1 WHERE UID = @UID;";
            var pms = new SQLiteParameter[]
            {
                new SQLiteParameter("@UID", DbType.String){Value = book.UID},
            };

            return SqliteHelper.ExecuteNonQuery(sql, pms) != -1;
        }
    }


    class VersionDAL
    {

        public static DataTable GetVersionList(string bookID)
        {
            const string sql = "SELECT b.Title, v.VersionNo, v.ContentLength FROM Book b, Version v where b.UID = v.BookID and b.UID = @UID;";
            var pms = new SQLiteParameter[]
            {
                new SQLiteParameter("@UID", DbType.String){Value = bookID},
            };

            return SqliteHelper.ExecuteReader(sql, pms);
        }

        public static string GetVersionContent(string bookID, int versionNo)
        {
            const string sql = "SELECT Content FROM Version WHERE BookID = @BookID AND VersionNo = @VersionNo;";
            var pms = new SQLiteParameter[]
            {
                new SQLiteParameter("@BookID", DbType.String){Value = bookID},
                new SQLiteParameter("@VersionNo", DbType.Int32){Value = versionNo},
            };
            var version = SqliteHelper.ExecuteReader(sql, pms);

            return version.Rows.Count == 1 ? version.Rows[0]["Content"].ToString() : "";
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
                version.VersionNo = (int)versionNo + 1;
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

        public static bool IsThisHashExist(string hash)
        {
            const string sql = "SELECT UID FROM Version WHERE ContentHash = @ContentHash;";
            var pms = new SQLiteParameter[]
            {
                new SQLiteParameter("@ContentHash", DbType.String){Value = hash},
            };

            var UID = SqliteHelper.ExecuteScalar(sql, pms);

            return UID != null;
        }
    }
}
