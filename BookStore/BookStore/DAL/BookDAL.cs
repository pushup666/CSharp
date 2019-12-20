using System;
using System.Data;
using System.Data.SQLite;
using System.Text;
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
            using var book = SQLiteHelper.ExecuteReader(sql, pms);

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
            const string sql = "SELECT ID, Title, Length, Rate, Alias, Author, Note, ModifyDate, LastReadDate FROM Book WHERE DeleteFlag = 0 ORDER BY Title COLLATE PinYin;";

            return SQLiteHelper.ExecuteReader(sql);
        }

        public static DataTable GetBookList(string filterTitle, string filterRate, string filterLength)
        {
            var filterSql = new StringBuilder();

            if (filterTitle != "")
            {
                filterSql.Append($"AND Title like '%{filterTitle}%' ");
            }

            if (int.TryParse(filterRate, out var filterRateInt))
            {
                filterSql.Append($"AND Rate = {filterRateInt} ");
            }

            if (filterLength != "")
            {
                filterSql.Append($"AND Length {filterLength} ");
            }

            var sql = $"SELECT ID, Title, Length, Rate, Alias, Author, Note, ModifyDate, LastReadDate FROM Book WHERE DeleteFlag = 0 {filterSql}ORDER BY Title COLLATE PinYin;";

            return SQLiteHelper.ExecuteReader(sql);
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

            return SQLiteHelper.ExecuteNonQuery(sql, pms) != -1;
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

            return SQLiteHelper.ExecuteNonQuery(sql, pms) != -1;
        }

        public static bool UpdateBookLengthAndModifyDate(string bookID, int length)
        {
            const string sql = "UPDATE Book SET Length = @Length, ModifyDate = @ModifyDate WHERE ID = @ID;";
            var pms = new[]
            {
                new SQLiteParameter("@Length", DbType.Int32){Value = length},
                new SQLiteParameter("@ModifyDate", DbType.DateTime){Value = DateTime.Now},
                new SQLiteParameter("@ID", DbType.String){Value = bookID},
            };

            return SQLiteHelper.ExecuteNonQuery(sql, pms) != -1;
        }

        public static bool UpdateBookLastRead(string bookID, int lastReadPosition)
        {
            const string sql = "UPDATE Book SET LastReadDate = @LastReadDate, LastReadPosition = @LastReadPosition WHERE ID = @ID;";
            var pms = new[]
            {
                new SQLiteParameter("@LastReadDate", DbType.DateTime){Value = DateTime.Now},
                new SQLiteParameter("@LastReadPosition", DbType.Int32){Value = lastReadPosition},
                new SQLiteParameter("@ID", DbType.String){Value = bookID},
            };

            return SQLiteHelper.ExecuteNonQuery(sql, pms) != -1;
        }


        public static int GetBookLastReadPosition(string bookID)
        {
            const string sql = "SELECT LastReadPosition FROM Book WHERE ID = @ID AND DeleteFlag = 0;";
            var pms = new[]
            {
                new SQLiteParameter("@ID", DbType.String){Value = bookID},
            };
            return int.Parse(SQLiteHelper.ExecuteScalar(sql, pms));
        }

        public static bool RemoveBook(string bookID)
        {
            const string sql = "UPDATE Book SET DeleteFlag = 1 WHERE ID = @ID;";
            var pms = new[]
            {
                new SQLiteParameter("@ID", DbType.String){Value = bookID},
            };

            return SQLiteHelper.ExecuteNonQuery(sql, pms) != -1;
        }

        public static bool ClearBook()
        {
            const string sql = "DELETE FROM Book WHERE DeleteFlag = 1;";
            return SQLiteHelper.ExecuteNonQuery(sql) != -1;
        }
    }
}