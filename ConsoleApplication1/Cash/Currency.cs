using System;
using Cash;

namespace Cash {
    public interface Currency {
        Denomination get_closest_denomination(double value);
        Denomination get_denomination( int index );
        int get_count();
    }
}