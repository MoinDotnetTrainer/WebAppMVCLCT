using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAppMVCLCT.Models
{
    public class SetSessionGlobally : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // get the session value , and if the values is null , goto login
            var res = context.HttpContext.Session.GetString("LoginName");
            if (res == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary {
                    { "Controller","Users"},
                    { "Action","Login"}
                });
            }
        }
    }
}
