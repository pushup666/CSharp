using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSqlite
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = SqliteHelper.ExecuteScalar("SELECT Name FROM Test;",null).ToString();
            Console.WriteLine(name);
            Console.ReadKey();
        }
    }
}
