using System;

namespace Cash
{
    public class Denomination
    {
        public double value { get; set; }
        public String name { get; set; }
        public String plural { get; set; }

        public Denomination(double v, String n, String p)
        {
            value = v;
            name = n;
            plural = p;
        }

        public Denomination() { }
    }
}