using System;
using System.Collections.Generic;
using System.Linq;

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
        public static TItem MaxBy<TItem, TKey>(this IEnumerable<TItem> items,Func<TItem, TKey> keySelector) where TKey : IComparable<TKey>
        {
            return items.Aggregate(
                (a, b) => keySelector(a).CompareTo(keySelector(b)) > 0
                    ? a : b);
        }

        public static TItem MinBy<TItem, TKey>(this IEnumerable<TItem> items,Func<TItem, TKey> keySelector) where TKey : IComparable<TKey>
        {
            return items.Aggregate(
                (a, b) => keySelector(a).CompareTo(keySelector(b)) < 0
                    ? a : b);
        }
        public static TItem Random<TItem>(this IEnumerable<TItem> items)
        {
            var random = new Random();
            return items.ElementAt(random.Next(items.Count()));
        }
    }
}
