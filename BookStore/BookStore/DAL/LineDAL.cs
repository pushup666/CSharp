using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using BookStore.Model;

namespace BookStore.DAL
{
    static class LineDAL
    {
        public static DataTable GetLineList(string versionID)
        {
            const string sql = "SELECT UID, LineNo, Content FROM Line WHERE VersionID = @VersionID ORDER BY LineNo;";
            var pms = new[]
            {
                new SQLiteParameter("@VersionID", DbType.String){Value = versionID},
            };

            return SqliteHelper.ExecuteReader(sql, pms);
        }

        public static bool Version2Lines(string versionID, List<string> lines )
        {
            const string sql1 = "DELETE FROM Line WHERE VersionID = @VersionID;";

            var pms1 = new[]
            {
                new SQLiteParameter("@VersionID", DbType.String){Value = versionID},
            };
            SqliteHelper.ExecuteNonQuery(sql1, pms1);


            const string sql2 = "INSERT INTO Line (UID, VersionID, LineNo, Content) VALUES (@UID, @VersionID, @LineNo, @Content);";

            var pms2 = new SQLiteParameter[lines.Count][];
            for (var i = 0; i < lines.Count; i++)
            {
                var pm = new SQLiteParameter[4];

                pm[0] = new SQLiteParameter("@UID", DbType.String) {Value = Utils.GetUID()};
                pm[1] = new SQLiteParameter("@VersionID", DbType.String) {Value = versionID};
                pm[2] = new SQLiteParameter("@LineNo", DbType.Int32) {Value = i};
                pm[3] = new SQLiteParameter("@Content", DbType.String) {Value = lines[i]};

                pms2[i] = pm;
            }

            return SqliteHelper.ExecuteNonQueryBat(sql2, pms2) != -1;
        }
    }
}
