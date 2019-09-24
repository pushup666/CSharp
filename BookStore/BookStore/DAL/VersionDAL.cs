using System.Data;
using System.Data.SQLite;
using BookStore.Model;

namespace BookStore.DAL
{
    static class VersionDAL
    {
        public static VersionDO GetVersion(string bookID, int versionNo)
        {
            const string sql = "SELECT * FROM Version WHERE BookID = @BookID AND VersionNo = @VersionNo AND DeleteFlag = 0;";
            var pms = new[]
            {
                new SQLiteParameter("@BookID", DbType.String){Value = bookID},
                new SQLiteParameter("@VersionNo", DbType.Int32){Value = versionNo},
            };
            var version = SqliteHelper.ExecuteReader(sql, pms);

            return version.Rows.Count == 1 ? new VersionDO(version.Rows[0]["UID"].ToString(), version.Rows[0]["BookID"].ToString(), int.Parse(version.Rows[0]["VersionNo"].ToString()), version.Rows[0]["Content"].ToString(), version.Rows[0]["ContentHash"].ToString(), int.Parse(version.Rows[0]["ContentLength"].ToString())) : null;
        }

        public static DataTable GetVersionList(string bookID)
        {
            const string sql = "SELECT b.Title, v.VersionNo AS No, v.ContentLength AS Length FROM Version v, Book b WHERE v.BookID = b.UID AND v.BookID = @BookID AND v.DeleteFlag = 0 ORDER BY v.VersionNo DESC;";
            var pms = new[]
            {
                new SQLiteParameter("@BookID", DbType.String){Value = bookID},
            };

            return SqliteHelper.ExecuteReader(sql, pms);
        }

        public static int GetNextVersionNo(string bookID)
        {
            const string sql = "SELECT MAX(VersionNo) FROM Version WHERE BookID = @BookID;";
            var versionNo = SqliteHelper.ExecuteScalar(sql, new SQLiteParameter("@BookID", DbType.String) { Value = bookID });
            if (string.IsNullOrEmpty(versionNo))
            {
                return 1;
            }
            else
            {
                return int.Parse(versionNo) + 1;
            }
        }

        public static bool AddVersion(VersionDO version)
        {
            const string sql = "INSERT INTO Version(UID, BookID, VersionNo, Content, ContentHash, ContentLength) VALUES (@UID, @BookID, @VersionNo, @Content, @ContentHash, @ContentLength);";
            var pms = new[]
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

        public static bool RemoveVersion(VersionDO version)
        {
            const string sql = "UPDATE Version SET DeleteFlag = 1 WHERE UID = @UID;";
            var pms = new[]
            {
                new SQLiteParameter("@UID", DbType.String){Value = version.UID},
            };

            return SqliteHelper.ExecuteNonQuery(sql, pms) != -1;
        }

        public static bool IsThisHashExist(string hash)
        {
            const string sql = "SELECT UID FROM Version WHERE ContentHash = @ContentHash;";
            var pms = new[]
            {
                new SQLiteParameter("@ContentHash", DbType.String){Value = hash},
            };

            var uid = SqliteHelper.ExecuteScalar(sql, pms);

            return uid != null;
        }
    }
}