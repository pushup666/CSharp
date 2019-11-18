using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenWild
{
    public partial class OpenWildForm : Form
    {
        private Player p;

        public OpenWildForm()
        {
            InitializeComponent();
        }

        private void ButtonNewPlayer_Click(object sender, EventArgs e)
        {
            p = new Player();

            timerPlayerInfoUpdate.Interval = 1000;
            timerPlayerInfoUpdate.Enabled = true;
        }

        private void ButtonStartStop_Click(object sender, EventArgs e)
        {
            if (buttonStartStop.Text == "Start")
            {
                buttonStartStop.Text = "Stop";
            }
            else
            {
                buttonStartStop.Text = "Start";
            }
        }

        private void timerPlayerInfoUpdate_Tick(object sender, EventArgs e)
        {

        }
    }
}
