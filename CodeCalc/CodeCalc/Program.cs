using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeCalc
{
    internal static class Program
    {
        private const string CodeFolder = @"C:\Github\CSharp";
        private const string ExtName = ".cs";
        private static readonly List<string> FileNameList = new List<string>();

        private static void Main()
        {
            var lineConut = 0; 
            GetAllSubFiles(CodeFolder, ExtName);

            foreach (var file in FileNameList)
            {
                using (var sr = new StreamReader(file, Encoding.Default))
                {
                    while (sr.ReadLine() != null)
                    {
                        lineConut++;
                    }
                }
            }

            Console.WriteLine($"{FileNameList.Count} files      {lineConut} lines");
            Console.ReadKey();
        }
        
        private static void GetAllSubFiles(string folder, string extName)
        {
            foreach (var subFolder in Directory.GetDirectories(folder))
            {
                GetAllSubFiles(subFolder, extName);
            }

            foreach (var file in Directory.GetFiles(folder))
            {
                if (Path.GetExtension(file).ToLower() == extName)
                {
                    FileNameList.Add(file);
                }
            }
        }
    }
}
