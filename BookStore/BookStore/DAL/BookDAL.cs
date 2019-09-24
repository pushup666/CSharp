using System.Data;
using System.Data.SQLite;
using BookStore.Model;

namespace BookStore.DAL
{
    static class BookDAL
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
            var pms = new[]
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
            var pms = new[]
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
            var pms = new[]
            {
                new SQLiteParameter("@UID", DbType.String){Value = book.UID},
            };

            return SqliteHelper.ExecuteNonQuery(sql, pms) != -1;
        }
    }
}