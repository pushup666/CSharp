using System;
using System.Speech.Synthesis;

namespace Text2Wav
{
    static class Program
    {
        private static void Main()
        {
            const string str = "唐一仙笑道：“当然不是。”她幽幽一叹道：“在代王府时，王爷有二十三房妻妾，可是代王爷就从来没有这种顾忌，他想喜欢谁那便喜欢谁，又岂会在意谁伤心谁难过？身居高位的人，整日操心的是仕途前程，妻妾不过是微不足道的附庸之物，谁会放在心上？”\r\n\r\n她拿一双黑白分明的杏眼微微瞟着杨凌，笑微微地道：“听说我还有位嫂嫂正在金陵，文心姐姐对你也是情有独钟，我看你还真是个风流种子呢。不过听说表哥现在正和两位京城名妓打得火热，文心姐姐的脸色好像不太好看，你要一视同仁，还是先去哄哄她吧，嘿嘿。”\r\n\r\n她倒背双手，蹦蹦跳跳走出几步，忽又回头，小巧的脚尖轻轻点地，脸色微赧道：“明日你去蓟州，那个……要带侍卫是吧？”\r\n\r\n杨凌一怔，心中忽地若有所悟，眸中不觉露出笑意，颔首道：“是啊，自然要带侍卫。”\r\n\r\n唐一仙咬咬唇，又道：“那么……小黄是你的亲兵，他会随你去了？”\r\n\r\n杨凌眼中笑意更盛，却摇了摇头道：“黄校尉么……其实是大内侍卫，皇上身边的人，他可不是我的亲兵。”\r\n\r\n唐一仙有些失望，杨凌又笑道：“不过我去蓟州，正是陪伴圣驾，我想黄校尉是一定会同去的，怎么，你想见他？”\r\n\r\n唐一仙俏脸一红，微羞道：“他在大同时向我吹嘘要创作一曲《杀边乐》，我想看看这家伙现在弄的怎么样了。”\r\n\r\n杨凌干笑一声，皇上现在正忙着马杀鸡，《杀边乐》恐怕仍在酝酿当中。";

            using (var synth = new SpeechSynthesizer())
            {
                //synth.SetOutputToWaveFile(@"C:\Users\ssf\Desktop\Wav\1.wav");
                synth.SetOutputToDefaultAudioDevice();
                synth.Rate = 2;

                Console.WriteLine(str);
                synth.Speak(str);
            }
        }
    }
}
