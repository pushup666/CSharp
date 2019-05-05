using System.IO;
using System.Text;

namespace BatchConvertTxtCode
{
    class Program
    {
        static void Main(string[] args)
        {

            var dir = new DirectoryInfo(@"C:\Users\ssf\Desktop");
            
            foreach (var file in dir.GetFiles())
            {
                var txt = "";

                using (var sr = new StreamReader(file.FullName,  Encoding.Default))
                {
                    txt = sr.ReadToEnd();
                }

                using (var sw = new StreamWriter(file.FullName, false, Encoding.UTF8))
                {
                    sw.Write(txt);
                }
            }
        }
    }
}
