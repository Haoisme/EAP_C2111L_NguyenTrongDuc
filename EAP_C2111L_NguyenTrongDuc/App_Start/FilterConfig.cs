using System.Web;
using System.Web.Mvc;

namespace EAP_C2111L_NguyenTrongDuc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
