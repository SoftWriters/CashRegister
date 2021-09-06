using CashDrawer.Core;

namespace CashDrawer.App.FileWriters
{
    public interface IHumanizer
    {
        string Humanize(Change change);
    }
}