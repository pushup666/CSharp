using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Text2Wav
{
    class Program
    {
        static void Main(string[] args)
        {
            const string str = "目前我院住院IIH项目全面上线的进度不及预期，为使医院老HIS系统的维护工作能够继续得到稳妥落实，确保医院今年住院业务各项工作顺利完成，确保新老系统的顺利交接，有必要续签本年度的HIS维保项目。";
            var synth = new SpeechSynthesizer();
            
            synth.SetOutputToWaveFile(@"C:\Users\ssf\Desktop\Wav\1.wav");
            synth.Rate = 4;

            Console.WriteLine(str);
            synth.Speak(str);
        }
    }
}
