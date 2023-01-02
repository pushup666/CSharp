using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace XiaoBaoJiaJia
{
    public partial class XiaoBaoJiaJia : Form
    {
        readonly Random _r = new Random();
        

        public XiaoBaoJiaJia()
        {
            InitializeComponent();
        }

        //1 + 1 = ?
        private void button1_Click(object sender, EventArgs e)
        {
            var limit = (int)numericUpDown1.Value;
            var all = new List<string>();


            //+
            for (var i = 1; i < limit; i++)
            {
                for (var j = 1; j < limit; j++)
                {
                    if (i + j < limit)
                    {
                        all.Add($"{i} + {j} = ");
                    }
                }
            }

            //-
            for (var i = 1; i < limit; i++)
            {
                for (var j = 1; j < limit; j++)
                {
                    if (i - j > 0)
                    {
                        all.Add($"{i} - {j} = ");
                    }
                }
            }

            richTextBox1.Text = string.Empty;
            var sb = new StringBuilder();

            for (var i = 0; i < 100; i++)
            {
                sb.AppendLine(all[_r.Next(all.Count)]);
            }
            richTextBox1.Text = sb.ToString();
        }

        //1 + 1 + 1 = ?
        private void button2_Click(object sender, EventArgs e)
        {
            var limit = (int)numericUpDown1.Value;
            var all = new List<string>();


            //++
            for (var i = 1; i < limit; i++)
            {
                for (var j = 1; j < limit; j++)
                {
                    if (i + j < limit)
                    {
                        for (var k = 1; k < limit; k++)
                        {
                            if (i + j + k > 0 && i + j + k < limit)
                            {
                                all.Add($"{i} + {j} + {k} = ");
                            }
                        }
                    }
                }
            }

            //+-
            for (var i = 1; i < limit; i++)
            {
                for (var j = 1; j < limit; j++)
                {
                    if (i + j < limit)
                    {
                        for (var k = 1; k < limit; k++)
                        {
                            if (i + j - k > 0 && i + j - k < limit)
                            {
                                all.Add($"{i} + {j} - {k} = ");
                            }
                        }
                    }
                }
            }

            //-+
            for (var i = 1; i < limit; i++)
            {
                for (var j = 1; j < limit; j++)
                {
                    if (i - j > 0)
                    {
                        for (var k = 1; k < limit; k++)
                        {
                            if (i - j + k > 0 && i - j + k < limit)
                            {
                                all.Add($"{i} - {j} + {k} = ");
                            }
                        }
                    }
                }
            }

            //--
            for (var i = 1; i < limit; i++)
            {
                for (var j = 1; j < limit; j++)
                {
                    if (i - j > 0)
                    {
                        for (var k = 1; k < limit; k++)
                        {
                            if (i - j - k > 0 && i - j - k < limit)
                            {
                                all.Add($"{i} - {j} - {k} = ");
                            }
                        }
                    }
                }
            }

            richTextBox1.Text = string.Empty;
            var sb = new StringBuilder();

            for (var i = 0; i < 100; i++)
            {
                sb.AppendLine(all[_r.Next(all.Count)]);
            }
            richTextBox1.Text = sb.ToString();
        }

        //1 + ? =
        private void button3_Click(object sender, EventArgs e)
        {
            var limit = (int)numericUpDown1.Value;
            var all = new List<string>();


            //1 + 1 = ?
            for (var i = 1; i < limit; i++)
            {
                for (var j = 1; j < limit; j++)
                {
                    if (i + j > limit && i + j < limit * 2)
                    {
                        all.Add($"{i} + {j} = (   )");
                    }
                }
            }

            //1 + ? = 1
            for (var i = 1; i < limit; i++)
            {
                for (var j = 1; j < limit; j++)
                {
                    if (i + j > limit && i + j < limit * 2)
                    {
                        all.Add($"{i} + (   ) = {i + j}");
                    }
                }
            }

            //? + 1  = 1
            for (var i = 1; i < limit; i++)
            {
                for (var j = 1; j < limit; j++)
                {
                    if (i + j > limit && i + j < limit * 2)
                    {
                        all.Add($"(   ) + {i} = {i + j}");
                    }
                }
            }

            richTextBox1.Text = string.Empty;
            var sb = new StringBuilder();

            for (var i = 0; i < 100; i++)
            {
                sb.AppendLine(all[_r.Next(all.Count)]);
            }
            richTextBox1.Text = sb.ToString();
        }
    }
}
