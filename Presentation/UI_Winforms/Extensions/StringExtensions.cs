using System;
using System.Collections.Generic;

namespace WinForms_Desktop.Extensions
{
    public static class StringExtensions
    {
        public static string ListToString(this List<string> valueList)
        {
            string all = "";
            foreach (string s in valueList)
            {
                all += s + Environment.NewLine;
            }
            return all;
        }

        public static string AddTrailingSlash(this string path)
        {
            if (!path.EndsWith("\\"))
            {
                return path + "\\";
            }
            else
            {
                return path;
            }
        }
    }
}