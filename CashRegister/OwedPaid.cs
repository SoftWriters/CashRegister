using System;

namespace CashRegister
{
    public class OwedPaid
    {
        private double _owed;
        private double _paid;
        private double _change;
        private bool _shouldMakeCreative;

        public OwedPaid(double owed, double paid)
        {
            _owed = owed;
            _paid = paid;
            _change = Math.Round(paid - owed, 2);
            _shouldMakeCreative = (_owed * 100) % 3 == 0;
        }

        public double Owed { get { return _owed; } }
        public double Paid { get { return _paid; } }
        public double Change { get { return _change; } }
        public bool ShouldMakeCreative { get { return _shouldMakeCreative; } }
    }
}
