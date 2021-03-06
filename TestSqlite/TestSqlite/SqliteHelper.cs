﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace TestSqlite
{
    static class SqliteHelper
    {
        private const string ConnStr = @"Data Source = D:\Test.db3";

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

        public static int ExecuteNonQueryBat(IEnumerable<string> sqls)
        {
            try
            {
                using (var conn = new SQLiteConnection(ConnStr))
                {
                    using (var cmd = new SQLiteCommand(conn))
                    {
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
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        public static int ExecuteNonQueryBat(string sql, IEnumerable<SQLiteParameter[]> pms)
        {
            try
            {
                using (var conn = new SQLiteConnection(ConnStr))
                {
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        var affectRows = 0;
                        conn.Open();

                        foreach (var pm in pms)
                        {
                            if (pm != null)
                            {
                                cmd.Parameters.AddRange(pm);
                            }
                            affectRows += cmd.ExecuteNonQuery();
                        }

                        return affectRows;
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