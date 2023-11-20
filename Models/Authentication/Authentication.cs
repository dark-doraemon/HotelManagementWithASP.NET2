using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HotelManagement.Models.Authentication
{
    public class Authentication : ActionFilterAttribute
    {
        //OnActionExecuting sẽ gọi trước khi hàm action mà nó được kèm theo
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //nếu tài khoản user và admin đều null thì đăng nhập
            if (context.HttpContext.Session.GetString("UserName") == null && context.HttpContext.Session.GetString("admin") == null && context.HttpContext.Session.GetString("nhanvien") != null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller","Login" },
                    { "action","Index" }
                });
            }
        }
    }
}
