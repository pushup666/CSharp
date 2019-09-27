using System.Data;
using System.Data.SQLite;
using BookStore.Model;

namespace BookStore.DAL
{
    static class BookDAL
    {
        public static BookDO GetBook(string bookID)
        {
            const string sql = "SELECT * FROM Book WHERE ID = @ID AND DeleteFlag = 0;";
            var pms = new[]
            {
                new SQLiteParameter("@ID", DbType.String){Value = bookID},
            };
            using var book = SqliteHelper.ExecuteReader(sql, pms);

            var id = book.Rows[0]["ID"].ToString();
            var title = book.Rows[0]["Title"].ToString();
            var alias = book.Rows[0]["Alias"].ToString();
            var author = book.Rows[0]["Author"].ToString();
            var note = book.Rows[0]["Note"].ToString();
            var rate = int.Parse(book.Rows[0]["Rate"].ToString());

            return book.Rows.Count == 1 ? new BookDO(id,title,alias,author,note,rate) : null;
        }

        public static DataTable GetBookList()
        {
            const string sql = "SELECT ID, Title, Alias, Author, Note, Rate, Length FROM Book WHERE DeleteFlag = 0;";

            return SqliteHelper.ExecuteReader(sql);
        }

        public static bool AddBook(BookDO book)
        {
            const string sql = "INSERT INTO Book(ID, Title, Alias, Author, Note) VALUES(@ID, @Title, @Alias, @Author, @Note);";
            var pms = new[]
            {
                new SQLiteParameter("@ID", DbType.String){Value = book.ID},
                new SQLiteParameter("@Title", DbType.String){Value = book.Title},
                new SQLiteParameter("@Alias", DbType.String){Value = book.Alias},
                new SQLiteParameter("@Author", DbType.String){Value = book.Author},
                new SQLiteParameter("@Note", DbType.String){Value = book.Note},
            };

            return SqliteHelper.ExecuteNonQuery(sql, pms) != -1;
        }

        public static bool ModifyBook(BookDO book)
        {
            const string sql = "UPDATE Book SET Title = @Title, Alias = @Alias, Author = @Author, Note = @Note, Rate = @Rate WHERE ID = @ID;";
            var pms = new[]
            {
                new SQLiteParameter("@Title", DbType.String){Value = book.Title},
                new SQLiteParameter("@Alias", DbType.String){Value = book.Alias},
                new SQLiteParameter("@Author", DbType.String){Value = book.Author},
                new SQLiteParameter("@Note", DbType.String){Value = book.Note},
                new SQLiteParameter("@Rate", DbType.Int32){Value = book.Rate},
                new SQLiteParameter("@ID", DbType.String){Value = book.ID},
            };

            return SqliteHelper.ExecuteNonQuery(sql, pms) != -1;
        }

        public static bool ModifyBookLength(string bookID, int length)
        {
            const string sql = "UPDATE Book SET Length = @Length WHERE ID = @ID;";
            var pms = new[]
            {
                new SQLiteParameter("@Length", DbType.String){Value = length},
                new SQLiteParameter("@ID", DbType.String){Value = bookID},
            };

            return SqliteHelper.ExecuteNonQuery(sql, pms) != -1;
        }

        public static bool RemoveBook(string bookID)
        {
            const string sql = "UPDATE Book SET DeleteFlag = 1 WHERE ID = @ID;";
            var pms = new[]
            {
                new SQLiteParameter("@ID", DbType.String){Value = bookID},
            };

            return SqliteHelper.ExecuteNonQuery(sql, pms) != -1;
        }
    }
}