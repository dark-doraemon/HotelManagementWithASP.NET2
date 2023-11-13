using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HotelManagement.Models.Authentication
{
    public class Authentication : ActionFilterAttribute
    {
        //OnActionExecuting sẽ gọi trước khi hàm action mà nó được kèm theo
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("UserName") == null && context.HttpContext.Session.GetString("admin") == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "Controller","Login" },
                    {"Acton","Index" }
                });
            }
        }
    }
}
