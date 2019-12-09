using System.IO;
using System.Text;

namespace ByteFreqAnalysis
{
    static class Program
    {
        static void Main()
        {
            var file = File.ReadAllBytes(@"D:\VM\VPN_RAM.part05.rar");
            var arr = new int[256];

            foreach (var b in file)
            {
                arr[b]++;
            }

            StringBuilder sb = new StringBuilder();
            foreach (var a in arr)
            {
                sb.AppendLine(a.ToString());
            }

            File.WriteAllText(@"C:\Users\ssf\Desktop\新建文件夹\111.txt",sb.ToString());
        }
    }
}
