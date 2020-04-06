using System.Web;
using System.Web.Mvc;

namespace CSharp_Net_module3_1_1_lab
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
