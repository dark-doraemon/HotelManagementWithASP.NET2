using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HotelManagement.Models.Authentication
{
    public class AdminAuthentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("admin") == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "Controller","Login" },
                    {"action","Index" }
                });
            }
        }
    }
}
