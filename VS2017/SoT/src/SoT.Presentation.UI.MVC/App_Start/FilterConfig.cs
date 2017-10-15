using SoT.Infra.CrossCutting.Filters;
using System.Web.Mvc;

namespace SoT.Presentation.UI.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new SoTErrorHandler());
        }
    }
}
