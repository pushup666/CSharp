using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace OpenWild
{
    class Creature
    {
        private const double hpt_init = 100;
        private const double att_init = 10;
        private const double def_init = 10;
        private const double spd_init = 10;
        private const double exp_init = 10;

        public double hpt { get; }
        public double att { get; }
        public double def { get; }
        public double spd { get; }
        public double exp { get; }
        public double lvl { get; }

        readonly Random r = new Random();

        public Creature(int level)
        {
            lvl = level;
            hpt = hpt_init * GetModifyByLevel(level);
            att = att_init * GetModifyByLevel(level);
            def = def_init * GetModifyByLevel(level);
            spd = spd_init * GetModifyByLevel(level);
            exp = exp_init * GetModifyByLevel(level);
        }

        private double GetModifyByLevel(int level)
        {
            return Math.Sqrt(level) * (r.NextDouble() + 0.5);
        }
    }
}
