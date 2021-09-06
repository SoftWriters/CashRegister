using System.Text;
using CashDrawer.Core;

namespace CashDrawer.App.FileWriters
{
    public class Humanizer : IHumanizer
    {

        public string Humanize(Change change)
        {
            var s = new StringBuilder();
            AddPart(s, change.Dollars, "dollar", "dollars");
            AddPart(s, change.Quarters, "quarter", "quarters");
            AddPart(s, change.Dimes, "dime", "dimes");
            AddPart(s, change.Nickles, "nickle", "nickles");
            AddPart(s, change.Pennies, "penny", "pennies");

            if (s.Length == 0) return "no change due";
            return string.Join(", ", s);
        }


        private void AddPart(StringBuilder s, int count, string singular, string plural)
        {
            if (count == 0) return;
            var text = GetText(count, singular, plural);
            if (s.Length > 0) s.Append(", ");
            s.Append(text);
        }


        private string GetText(int count, string singular, string plural)
        {
            return count == 1 ?
                    $"{count} {singular}" :
                    $"{count} {plural}";
        }

    }
}
