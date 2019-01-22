using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchConvertTxtCode
{
    class Program
    {
        static void Main(string[] args)
        {

            var dir = new DirectoryInfo(@"C:\Users\ssf\Desktop\一体化\IIH视图");
            
            foreach (var file in dir.GetFiles())
            {
                var txt = "";

                using (var sr = new StreamReader(file.FullName,  Encoding.Default))
                {
                    txt = sr.ReadToEnd();
                }

                using (var sw = new StreamWriter(file.FullName,false, Encoding.UTF8))
                {
                    sw.Write(txt);
                }
            }
        }
    }
}
