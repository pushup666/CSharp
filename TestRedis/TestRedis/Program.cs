using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace TestRedis
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var redis = ConnectionMultiplexer.Connect("192.168.10.134:6379");
                var db = redis.GetDatabase();

                db.StringSet("sss", 666);
                Console.WriteLine(db.StringGet("sss"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
