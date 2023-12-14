using System.IO;
using System.Text;

namespace BatchConvertTxtCode
{
    class Program
    {
        static void Main(string[] args)
        {

            var dir = new DirectoryInfo(@"C:\Users\ssf\Desktop\111");
            
            foreach (var file in dir.GetFiles())
            {
                var txt = "";

                using (var sr = new StreamReader(file.FullName,  Encoding.UTF8))
                {
                    txt = sr.ReadToEnd();
                }

                using (var sw = new StreamWriter(file.FullName, false, Encoding.Default))
                {
                    sw.Write(txt);
                }
            }
        }
    }
}
