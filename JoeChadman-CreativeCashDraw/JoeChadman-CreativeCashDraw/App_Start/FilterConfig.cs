using System.Web;
using System.Web.Mvc;

namespace JoeChadman_CreativeCashDraw
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}