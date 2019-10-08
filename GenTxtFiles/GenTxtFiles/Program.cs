using System;
using System.IO;
using System.Text;

namespace GenTxtFiles
{
    static class Program
    {
        private static readonly string[] Dict = new[]
        {
            "a", "b", "c", "d", "e", "f", "g",
            "h", "i", "j", "k", "l", "m", "n",
            "o", "p", "q", "r", "s", "t",
            "u", "v", "w", "x", "y", "z",
            " ", " ", " ", " "
        };

        private const int FilesCount = 1000;
        private const int AvrgFileLines = 1000;
        private const int AvrgLineLength = 100;
        private const string FilePath = @"C:\Users\ssf\Desktop\111\";
        private static readonly Random R = new Random();

        static void Main()
        {
            for (var i = 0; i < FilesCount; i++)
            {
                var fileLines = R.Next((int) (AvrgFileLines * 0.5), (int) (AvrgFileLines * 1.5));
                var sb = new StringBuilder();

                for (var j = 0; j < fileLines; j++)
                {
                    sb.AppendLine(GenRandomLine());
                }

                using var sw = new StreamWriter($"{FilePath}{i.ToString().PadLeft(10, '0')}.txt", false);
                sw.Write(sb.ToString());
            }
        }

        private static string GenRandomLine()
        {
            var lineLength = R.Next((int)(AvrgLineLength * 0.5), (int)(AvrgLineLength * 1.5));
            var sb = new StringBuilder();

            for (var i = 0; i < lineLength; i++)
            {
                sb.Append(Dict[R.Next(Dict.Length)]);
            }

            return sb.ToString();
        }
    }
}
