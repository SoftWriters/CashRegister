using System;

namespace CashRegister.BL {
    public static class Extensions {

        ///<Summary>
        /// Returns Cardinality of value.!-- Combined should be Singular:Plural
        ///</Summary>
        public static string CardinalityLabel(this int count, string combined)
        {
            var parts = combined.Split(':');
            return count == 1 ? parts[0].Trim() : parts[1].Trim();
        }

        public static T GetField<T>(this string[] data, int index)
        {
            if (data.Length <= index)
                return default(T);
            else
            {
                var value = data[index].Trim();
                Type t = typeof(T);
                return (T)Convert.ChangeType(value, Nullable.GetUnderlyingType(t) ?? t);
            }
        }
    }
}
