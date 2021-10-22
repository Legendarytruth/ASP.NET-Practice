using HPlus.Ecommerce.Filters;
using System.Web.Mvc;

namespace HPlus.Ecommerce
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomExceptionHandler());
            filters.Add(new LogRequestFilter());
        }
    }
}
