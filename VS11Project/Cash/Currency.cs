using System;
using Cash;

namespace Cash {
    public interface Currency {
        int          get_count();
        Denomination get_closest_denomination(double value);
        Denomination get_denomination( int index );
    }
}