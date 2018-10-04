using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cash;

namespace Cash
{
    public class Change: Denomination
    {
        public int count { get; set; }

        public Change(double v, String n, String p)
        {
            count  = 0;
            value  = v;
            name   = n;
            plural = p;
        }

        public Change(double v, String n, String p, int c)
        {
            count = c;
            value = v;
            name = n;
            plural = p;
        }
    }
}
