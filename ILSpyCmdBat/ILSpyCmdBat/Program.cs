using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace ILSpyCmdBat
{
    class Program
    {
        static void Main(string[] args)
        {
            var src = new DirectoryInfo(args[0]);
            var dst = new DirectoryInfo(args[1]);

            string [] blacklist = { "d3dcompiler_43.dll", "d3dcompiler_47.dll", "DCSoft.Writer.dll", "Dewlt.dll", "DTKit.dll", "DtUICtl.dll", "dtywzxUI.dll", "EachCommunicationCom.dll", "gsdll32.dll", "libcef.dll", "libEGL.dll", "libGLESv2.dll", "MedicareCom.dll", "mwrf32.dll", "PASS4Invoke.dll", "PASS4Invoke64.dll", "PASS4Test.exe", "PASS4Test64.exe", "PASSIMClient.dll", "PASSIMClient.exe", "PASSWeb.dll", "SavePhoto.dll", "Sdtapi.dll", "SQLite.Interop.dll", "widevinecdmadapter.dll" };
            
            var list = new List<string>();

            list.AddRange(src.GetFiles("*.dll").Select(file => file.Name));
            list.AddRange(src.GetFiles("*.exe").Select(file => file.Name));

            foreach (var name in blacklist)
            {
                list.Remove(name);
            }

            var sb = new StringBuilder();
            foreach (var name in list)
            {

                sb.AppendLine($"md {dst}{name}");
                sb.AppendLine($"ilspycmd \"{src}{name}\" -p -o \"{dst}{name}\"");
            }

            sb.AppendLine($"forfiles /p \"{dst}\" /m *.csproj /s /c \"cmd /c del /Q @file\"");

            using (var sw = new StreamWriter($"{dst}111.bat", false, Encoding.Default))
            {
                sw.Write(sb.ToString());
            }
        }
    }
}
