using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class Extensions
    {
        /// <summary>
        /// Convert string to decimal.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string source) => Convert.ToDecimal(source);

        /// <summary>
        /// Add string to the referenced  List
        /// </summary>
        /// <param name="source">Source string to add</param>
        /// <param name="list">Target List</param>
        public static void AddToList<T>(this T source, ref List<T> list) => list?.Add(source);

        /// <summary>
        /// Convert to an integer, with rounding down.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int ToInt(this decimal source) => Decimal.ToInt32(source);
        /// <summary>
        /// Append the source string to the target stringbuilder.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="stringBuilder">Target stringbuilder</param>
        public static void Append(this string source, StringBuilder stringBuilder) => stringBuilder.Append(source);

        /// <summary>
        /// Return a randomized integer with the source as the top limit.
        /// </summary>
        /// <param name="source">Maximum integer that can be returned.</param>
        /// <returns></returns>
        public static int RandomizeIntTo(this int source) => new Random(Guid.NewGuid().GetHashCode()).Next(0, source + 1);

    }
}
