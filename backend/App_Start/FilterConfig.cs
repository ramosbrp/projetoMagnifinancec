using MyUniversityAPI.App_Start;
using System.Web;
using System.Web.Mvc;

namespace MyUniversityAPI
{
    public class FilterConfig : ActionFilterAttribute
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AllowCors());
        }

    }
}
