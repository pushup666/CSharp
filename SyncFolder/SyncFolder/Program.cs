using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SyncFolder
{
    static class Program
    {
        //SyncFolder.exe D:\111\ D:\222\ >> Log%date:~0,4%%date:~5,2%%date:~8,2%.txt
        private static List<string> _srcFileList, _dstFileList, _srcCopyFileList, _dstDeleteFileList;
        private static string _srcFolder, _dstFolder;

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                _srcFolder = args[0];
                _dstFolder = args[1];

                _srcFileList = new List<string>();
                _dstFileList = new List<string>();
                GetFiles(_srcFolder, _srcFolder, _srcFileList);
                GetFiles(_dstFolder, _dstFolder, _dstFileList);

                _srcCopyFileList = _srcFileList.Except(_dstFileList).ToList();
                _dstDeleteFileList = _dstFileList.Except(_srcFileList).ToList();
                

                foreach (var file in _srcCopyFileList)
                {
                    File.Copy(_srcFolder + file, _dstFolder + file);
                    Console.WriteLine("Copy {0} {1}", _srcFolder + file, _dstFolder + file);
                }

                foreach (var file in _dstDeleteFileList)
                {
                    File.Delete(_dstFolder + file);
                    Console.WriteLine("Delete {0}", _dstFolder + file);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
        }

        private static void GetFiles(string folder, string removePrefix, ICollection<string> list)
        {
            var rootFolder = new DirectoryInfo(folder);

            foreach (var file in rootFolder.GetFiles())
            {
                list.Add(file.FullName.Replace(removePrefix,""));
            }

            foreach (var subFolder in rootFolder.GetDirectories())
            {
                GetFiles(subFolder.FullName, removePrefix, list);
            }
        }
    }
}
