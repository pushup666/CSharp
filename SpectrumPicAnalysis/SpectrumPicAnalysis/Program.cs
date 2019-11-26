using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace SpectrumPicAnalysis
{
    static class Program
    {
        //SpectrumPicAnalysis -l picFileNameList.txt
        //SpectrumPicAnalysis picFileName.png
        private static void Main(string[] args)
        {
            //CMD To Generate Spectrum PNG
            //for %%a in ("*.mp3") do ffmpeg -i "%%a" -lavfi showspectrumpic=legend=false "%%~na.png"

            string picFileName;
            if (args[0] == "-l")
            {
                var result = "";
                using (var sr = new StreamReader(args[1], Encoding.Default))
                {
                    while ((picFileName = sr.ReadLine()) !=null)
                    {
                        result += $"{CalcAvgFreq(picFileName)}\t{picFileName}\r\n";
                        Console.WriteLine(picFileName);
                    }
                }
                using (var sw = new StreamWriter("ListResult.txt", false, Encoding.Default))
                {
                    sw.Write(result);
                }
            }
            else
            {
                picFileName = args[0];
                using (var sw = new StreamWriter($"{picFileName}.txt", false, Encoding.Default))
                {
                    sw.Write($"{CalcAvgFreq(picFileName)}\t{picFileName}\r\n");
                }
            }
        }

        private static string CalcAvgFreq(string picName)
        {
            using (var img = new Bitmap(picName))
            {
                double allSum = 0;
                for (var i = 0; i < img.Width; ++i)
                {
                    var colSum = 0;
                    for (var j = 0; j < img.Height; ++j)
                    {
                        if (img.GetPixel(i, j).R + img.GetPixel(i, j).G + img.GetPixel(i, j).B == 0)
                        {
                            colSum++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    allSum += colSum;
                }

                var result = (img.Height - allSum / img.Width) * 21963.87 / img.Height / 1000;
                return $"{result:F} khz";
            }
        }
    }
}