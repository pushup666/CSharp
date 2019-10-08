using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace BookStore.DAL
{
    static class LineDAL
    {
        public static DataTable GetLineList(string bookID)
        {
            const string sql = "SELECT ID, LineNo, Content FROM Line WHERE BookID = @BookID AND Content <> '' ORDER BY LineNo;";

            var pms = new[]
            {
                new SQLiteParameter("@BookID", DbType.String){Value = bookID},
            };

            return SqliteHelper.ExecuteReader(sql, pms);
        }

        public static string Lines2String(string bookID)
        {
            const string sql = "SELECT ID, LineNo, Content FROM Line WHERE BookID = @BookID ORDER BY LineNo;";

            var pms = new[]
            {
                new SQLiteParameter("@BookID", DbType.String){Value = bookID},
            };

            using var dt = SqliteHelper.ExecuteReader(sql, pms);
            var sb = new StringBuilder();

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                sb.AppendLine(dt.Rows[i]["Content"].ToString());
            }

            return sb.ToString();
        }


        public static bool ClearLines(string bookID)
        {
            const string sql = "DELETE FROM Line WHERE BookID = @BookID;";

            var pms = new[]
            {
                new SQLiteParameter("@BookID", DbType.String){Value = bookID},
            };

            return SqliteHelper.ExecuteNonQuery(sql, pms) != -1;
        }

        public static bool ClearLines()
        {
            const string sql = "DELETE FROM Line;";
            return SqliteHelper.ExecuteNonQuery(sql) != -1;
        }

        public static bool Version2Lines(string bookID, List<string> lines )
        {
            const string sql = "INSERT INTO Line (ID, BookID, LineNo, Content) VALUES (@ID, @BookID, @LineNo, @Content);";

            var pms = new SQLiteParameter[lines.Count][];
            for (var i = 0; i < lines.Count; i++)
            {
                var pm = new SQLiteParameter[4];

                pm[0] = new SQLiteParameter("@ID", DbType.String) {Value = Utils.GetID()};
                pm[1] = new SQLiteParameter("@BookID", DbType.String) {Value = bookID };
                pm[2] = new SQLiteParameter("@LineNo", DbType.Int32) {Value = i};
                pm[3] = new SQLiteParameter("@Content", DbType.String) {Value = lines[i]};

                pms[i] = pm;
            }

            return SqliteHelper.ExecuteNonQueryBat(sql, pms) != -1;
        }

        public static bool DeleteLines(List<string> lineIDList)
        {
            const string sql = "DELETE FROM Line WHERE ID = @ID;";

            var pms = new SQLiteParameter[lineIDList.Count][];
            for (var i = 0; i < lineIDList.Count; i++)
            {
                var pm = new SQLiteParameter[1];
                pm[0] = new SQLiteParameter("@ID", DbType.String) { Value = lineIDList[i] };

                pms[i] = pm;
            }

            return SqliteHelper.ExecuteNonQueryBat(sql, pms) != -1;
        }
    }
}
