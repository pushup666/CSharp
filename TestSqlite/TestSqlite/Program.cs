using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace TestSqlite
{
    static class Program
    {
        private static void Main()
        {
            //SqliteHelper.ExecuteNonQuery("CREATE TABLE Test (ID INTEGER PRIMARY KEY NOT NULL, Name TEXT);");

            const int scale = 100;
            var sw = new Stopwatch();


            sw.Reset();
            sw.Start();
            SqliteHelper.ExecuteNonQuery("begin;");
            InsertTest(scale);
            //UpdateTest(scale);
            //DeleteTest(scale);
            SqliteHelper.ExecuteNonQuery("commit;");
            sw.Stop();
            Console.WriteLine(scale * 1000 / sw.ElapsedMilliseconds);



            //sw.Reset();
            //sw.Start();
            //InsertTestBat(scale);
            //UpdateTestBat(scale);
            //DeleteTestBat(scale);
            //sw.Stop();
            //Console.WriteLine(scale * 1000 / sw.ElapsedMilliseconds);




            //var lines = new List<string>();
            //var sw = new Stopwatch();

            //using (var sr = new StreamReader(@"Z:\111.txt", Encoding.Default))
            //{
            //    string line;
            //    while ((line = sr.ReadLine()) != null)
            //    {
            //        lines.Add(line);
            //    }
            //}

            //sw.Reset();
            //sw.Start();
            //InsertListBat(lines);
            //sw.Stop();
            //Console.WriteLine(lines.Count * 1000.0 / sw.ElapsedMilliseconds);

            Console.ReadKey();
        }

        static void Test()
        {
            //INSERT INTO Test (ID, Name) VALUES ('ID', 'Name');
            //DELETE FROM Test WHERE ID = 'ID';
            //UPDATE Test SET Name = 'Name' WHERE ID = 'ID';
            //SELECT * FROM Test;

            //var re1 = SqliteHelper.ExecuteNonQuery("INSERT INTO Test (ID, Name) VALUES (321, 'haha');");
            //Console.WriteLine(re1);

            //var re2 = SqliteHelper.ExecuteNonQuery("DELETE FROM Test WHERE ID = 321;");
            //Console.WriteLine(re2);

            //var dd = new SQLiteParameter("@Name", DbType.String) { Value = "piqiukou" };
            //var re3 = SqliteHelper.ExecuteNonQuery("UPDATE Test SET Name = @Name WHERE ID = 11;", dd);
            //Console.WriteLine(re3);


            //var name = SqliteHelper.ExecuteScalar("SELECT Name FROM Test where ID = 11;").ToString();
            //Console.WriteLine(name);


            //using (var dt = SqliteHelper.ExecuteReader("SELECT * FROM Test"))
            //{
            //    Console.WriteLine(dt.Rows[1].ItemArray[1]);
            //}
        }

        static void InsertTest(int n)
        {
            for (var i = 0; i < n; i++)
            {
                SqliteHelper.ExecuteNonQuery($"INSERT INTO Test (ID, Name) VALUES ({i}, '{i.ToString().PadLeft(10, '0')}');");
            }
        }

        static void UpdateTest(int n)
        {
            for (var i = 0; i < n; i++)
            {
                SqliteHelper.ExecuteNonQuery($"UPDATE Test SET Name = {(n-1-i).ToString().PadLeft(10, '0')} WHERE ID = {i};");
            }
        }

        static void DeleteTest(int n)
        {
            for (var i = 0; i < n; i++)
            {
                SqliteHelper.ExecuteNonQuery($"DELETE FROM Test WHERE ID = {i};");
            }
        }

        static void InsertTestBat(int n)
        {
            var sqls = new List<string>();
            for (var i = 0; i < n; i++)
            {
                sqls.Add($"INSERT INTO Test (ID, Name) VALUES ({i}, '{i.ToString().PadLeft(10, '0')}');");
            }
            SqliteHelper.ExecuteNonQueryBat(sqls);
        }

        static void UpdateTestBat(int n)
        {
            var sqls = new List<string>();
            for (var i = 0; i < n; i++)
            {
                sqls.Add($"UPDATE Test SET Name = {(n - 1 - i).ToString().PadLeft(10, '0')} WHERE ID = {i};");
            }
            SqliteHelper.ExecuteNonQueryBat(sqls);
        }

        static void DeleteTestBat(int n)
        {
            var sqls = new List<string>();
            for (var i = 0; i < n; i++)
            {
                sqls.Add($"DELETE FROM Test WHERE ID = {i};");
            }
            SqliteHelper.ExecuteNonQueryBat(sqls);
        }



        //static void InsertList(List<string> lines)
        //{
        //    for (var i = 0; i < lines.Count; i++)
        //    {
        //        var id = new SQLiteParameter("@ID", DbType.Int32) {Value = i};
        //        var name = new SQLiteParameter("@Name", DbType.String) { Value = lines[i] };

        //        SqliteHelper.ExecuteNonQuery($"INSERT INTO Test (ID, Name) VALUES (@ID, @Name);", id, name);
        //    }

        //}

        //static void InsertListBat(List<string> lines)
        //{
        //    SQLiteParameter[][] pms = new SQLiteParameter[lines.Count][];
        //    for (var i = 0; i < lines.Count; i++)
        //    {
        //        SQLiteParameter[] pm = new SQLiteParameter[2];
        //        var id = new SQLiteParameter("@ID", DbType.Int32) { Value = i };
        //        var name = new SQLiteParameter("@Name", DbType.String) { Value = lines[i] };
        //        pm[0] = id;
        //        pm[1] = name;

        //        pms[i] = pm;
        //    }
        //    SqliteHelper.ExecuteNonQueryBat($"INSERT INTO Test (ID, Name) VALUES (@ID, @Name);", pms);
        //}
    }
}
