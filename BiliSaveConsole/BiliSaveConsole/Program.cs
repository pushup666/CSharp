using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace BiliSaveConsole
{
    class Program
    {
        private static string pathLoad = @"C:\Users\ssf\Desktop\Videos\bilibili";
        private static string pathSave = @"C:\Users\ssf\Desktop\Video";
        JsonSerializer serializer = new JsonSerializer();

        static void Main(string[] args)
        {
            
            string[] listItem = Directory.GetDirectories(pathLoad,"*", SearchOption.TopDirectoryOnly);

            foreach (var itemID in listItem)
            {
                string filePlayUrl = itemID + "\\.playurl";
                if (File.Exists(filePlayUrl))
                {
                    
                    Dictionary<string, object> json = (Dictionary<string, object>)serializer.DeserializeObject(JsonData);
                    string firstKey = json.ElementAt(0).Key;
                    string secondKey = json.ElementAt(1).Key;
                }
            }
        }
    }
}
