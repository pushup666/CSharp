using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BookStore
{
    static class SQLiteHelper
    {
        private static readonly string ConnStr = $@"Data Source = {Environment.CurrentDirectory}\BookStore.db3";
        
        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] pms)
        {
            try
            {
                using var conn = new SQLiteConnection(ConnStr);
                using var cmd = new SQLiteCommand(sql, conn);

                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return -1;
            }
        }

        public static int ExecuteNonQueryBat(IEnumerable<string> sqls)
        {
            try
            {
                using var conn = new SQLiteConnection(ConnStr);
                using var cmd = new SQLiteCommand(conn);

                var affectRows = 0;
                conn.Open();

                cmd.CommandText = "begin;";
                cmd.ExecuteNonQuery();

                foreach (var sql in sqls)
                {
                    cmd.CommandText = sql;
                    affectRows += cmd.ExecuteNonQuery();
                }

                cmd.CommandText = "commit;";
                cmd.ExecuteNonQuery();

                return affectRows;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return -1;
            }
        }

        public static int ExecuteNonQueryBat(string sql, IEnumerable<SQLiteParameter[]> pms)
        {
            try
            {
                var affectRows = 0;

                using var conn = new SQLiteConnection(ConnStr);
                using var cmd = new SQLiteCommand(conn);

                conn.Open();

                cmd.CommandText = "begin;";
                cmd.ExecuteNonQuery();

                foreach (var pm in pms)
                {
                    cmd.CommandText = sql;
                    if (pm != null)
                    {
                        cmd.Parameters.AddRange(pm);
                    }
                    affectRows += cmd.ExecuteNonQuery();
                }

                cmd.CommandText = "commit;";
                cmd.ExecuteNonQuery();

                return affectRows;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return -1;
            }
        }

        public static string ExecuteScalar(string sql, params SQLiteParameter[] pms)
        {
            try
            {
                using var conn = new SQLiteConnection(ConnStr);
                using var cmd = new SQLiteCommand(sql, conn);

                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                conn.Open();

                return cmd.ExecuteScalar()?.ToString();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public static DataTable ExecuteReader(string sql, params SQLiteParameter[] pms)
        {
            try
            {
                using var conn = new SQLiteConnection(ConnStr);
                using var cmd = new SQLiteCommand(sql, conn);

                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                conn.Open();
                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
    }
}