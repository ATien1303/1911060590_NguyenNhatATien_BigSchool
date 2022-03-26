using System.Web;
using System.Web.Mvc;

namespace _1911060590_NguyenNhatATien_BigSchool
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
