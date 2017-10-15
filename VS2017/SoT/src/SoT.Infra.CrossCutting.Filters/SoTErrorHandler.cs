using System.Web.Mvc;

namespace SoT.Infra.CrossCutting.Filters
{
    public class SoTErrorHandler : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            // TODO: log error here

            if(filterContext.Exception != null)
            {
                filterContext.Controller.TempData["ErrorMessage"] =
                    "An error occurred while processing your request. Please contact your system Administrator.";
            }
        }
    }
}
