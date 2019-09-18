using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSqlite
{
    class Program
    {
        static void Main(string[] args)
        {
            //INSERT INTO Test (ID, Name) VALUES ('ID', 'Name');
            //DELETE FROM Test WHERE ID = 'ID';
            //UPDATE Test SET Name = 'Name' WHERE ID = 'ID';
            //SELECT * FROM Test;

            var re1 = SqliteHelper.ExecuteNonQuery("INSERT INTO Test (ID, Name) VALUES (321, 'haha');");
            Console.WriteLine(re1);

            var re2 = SqliteHelper.ExecuteNonQuery("DELETE FROM Test WHERE ID = 321;");
            Console.WriteLine(re2);

            var dd = new SQLiteParameter("@Name", DbType.String) {Value = "piqiukou"};
            var re3 = SqliteHelper.ExecuteNonQuery("UPDATE Test SET Name = @Name WHERE ID = 11;", dd);
            Console.WriteLine(re3);


            var name = SqliteHelper.ExecuteScalar("SELECT Name FROM Test where ID = 11;").ToString();
            Console.WriteLine(name);


            using (var dt = SqliteHelper.ExecuteReader("SELECT * FROM Test"))
            {
                Console.WriteLine(dt.Rows[1].ItemArray[1]);
            }

            Console.ReadKey();
        }
    }
}
