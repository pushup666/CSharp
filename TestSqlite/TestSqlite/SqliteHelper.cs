using System;
using System.Data;
using System.Data.SQLite;

namespace TestSqlite
{
    static class SqliteHelper
    {
        private const string ConnStr = @"Data Source = C:\Users\ssf\Desktop\sqlite\db\cs.db";

        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] pms)
        {
            try
            {
                using (var conn = new SQLiteConnection(ConnStr))
                {
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        if (pms != null)
                        {
                            cmd.Parameters.AddRange(pms);
                        }
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        public static object ExecuteScalar(string sql, params SQLiteParameter[] pms)
        {
            try
            {
                using (var conn = new SQLiteConnection(ConnStr))
                {
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        if (pms != null)
                        {
                            cmd.Parameters.AddRange(pms);
                        }
                        conn.Open();
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static DataTable ExecuteReader(string sql, params SQLiteParameter[] pms)
        {
            try
            {
                using (var conn = new SQLiteConnection(ConnStr))
                {
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        if (pms != null)
                        {
                            cmd.Parameters.AddRange(pms);
                        }
                        conn.Open();
                        var dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        return dt;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}