using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWild
{
    class Player
    {
        private const double hpt_init = 100;
        private const double att_init = 10;
        private const double def_init = 10;
        private const double spd_init = 10;

        public double hpt { get; private set; }
        public double att { get; private set; }
        public double def { get; private set; }
        public double spd { get; private set; }

        public double exp { get; private set; }
        public double lvl { get; private set; }

        readonly Random r = new Random();

        public Player()
        {
            hpt = hpt_init;
            att = att_init;
            def = def_init;
            spd = spd_init;

            exp = 0;
            lvl = 1;
        }
        public void GetExp(double e)
        {
            exp += e;
            TryUpgrade();
        }
        private void TryUpgrade()
        {
            if (exp > lvl * 100)
            {
                exp = 0;
                Upgrade();
            }
        }

        private void Upgrade()
        {
            lvl++;
            hpt += hpt * GetModifyWhenUpgrade();
            att += att * GetModifyWhenUpgrade();
            def += def * GetModifyWhenUpgrade();
            spd += spd * GetModifyWhenUpgrade();
        }

        private double GetModifyWhenUpgrade()
        {
            return 1 + r.NextDouble() / 10;
        }


    }
}
