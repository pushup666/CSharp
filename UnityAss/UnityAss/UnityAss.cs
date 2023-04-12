using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UnityAss
{
    public partial class UnityAss : Form
    {
        private readonly AssSubtitle _ass = new AssSubtitle();
        private string _fileName;

        public UnityAss()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        _fileName = openFileDialog.FileName;
                    }
                }
                _ass.Load(_fileName);
                richTextBoxAss.Text = _ass.Stringify();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var saveFileName = string.Format($"{Path.GetDirectoryName(_fileName)}\\{Path.GetFileNameWithoutExtension(_fileName)}.Unity{Path.GetExtension(_fileName)}");

                File.WriteAllText(saveFileName, richTextBoxAss.Text, Encoding.UTF8);
                MessageBox.Show($"{saveFileName}\nSaved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonUnity_Click(object sender, EventArgs e)
        {
            _ass.ScriptInfo.Clear();
            _ass.ScriptInfo.Add("ScriptType", new Tuple<string, string>("key-value", "v4.00+"));
            _ass.ScriptInfo.Add("Collisions", new Tuple<string, string>("key-value", "Normal"));
            _ass.ScriptInfo.Add("PlayResX", new Tuple<string, string>("key-value", "384"));
            _ass.ScriptInfo.Add("PlayResY", new Tuple<string, string>("key-value", "288"));
            _ass.ScriptInfo.Add("Timer", new Tuple<string, string>("key-value", "100"));

            _ass.V4pStyles.Clear();
            var style = new AssStyle
            {
                Name = "Default",

                Fontname = "微软雅黑",
                Fontsize = Convert.ToDouble(18),

                PrimaryColour = "&H00FFFFFF",               //AABBGGRR
                SecondaryColour = "&H00000000",
                OutlineColour = "&H00000000",               //边框颜色，Outline > 0
                BackColour = "&H00000000",                  //阴影颜色，Shadow > 0

                Bold = Convert.ToInt16("0") == -1,          //粗体
                Italic = Convert.ToInt16("0") == -1,        //斜体
                Underline = Convert.ToInt16("0") == -1,     //下划线
                StrikeOut = Convert.ToInt16(("0")) == -1,   //中划线

                ScaleX = Convert.ToDouble("100"),
                ScaleY = Convert.ToDouble("100"),
                Spacing = Convert.ToInt32("0"),             //字符间像素数
                Angle = Convert.ToDouble("0"),              //旋转角度

                BorderStyle = (V4pStyleBorderStyle) Convert.ToInt16("1"),   //BorderAndShadow = 1, ColorBackground = 3
                Outline = Convert.ToInt32("2"),
                Shadow = Convert.ToInt32("0"),

                Alignment = (V4pStyleAlignment) Convert.ToInt16("2"),       //小键盘布局
                MarginL = Convert.ToInt32("5"),
                MarginR = Convert.ToInt32("5"),
                MarginV = Convert.ToInt32("5"),

                Encoding = Convert.ToInt32("134")
            };

            _ass.V4pStyles[style.Name] = style;


            foreach (var evt in _ass.Events)
            {
                try
                {
                    evt.Style = "Default";
                    evt.Text = Regex.Replace(evt.Text, "{.*}", "");

                    var texts = evt.Text.Split(new[] { "\\N" }, StringSplitOptions.RemoveEmptyEntries);

                    switch (texts.Length)
                    {
                        case 1:
                            evt.Text = texts[0].Trim();
                            continue;
                        case 2:
                            evt.Text = texts[0].Trim() + "\\N{\\fs10}" + texts[1].Trim();
                            continue;
                        default:
                            MessageBox.Show("Error: " + evt.Text);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            richTextBoxAss.Text = _ass.Stringify();
        }
    }
}
