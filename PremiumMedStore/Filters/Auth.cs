using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using PremiumMedStore.Data;
using System.Linq;

namespace PremiumMedStore.Filters
{
    public class Auth : ActionFilterAttribute
    {
        private readonly PremiumDbContext _context;

        public Auth(PremiumDbContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            bool hasToken = context.HttpContext.Request.Cookies.TryGetValue("token", out string token);

            if (!hasToken)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "login", controller = "user" }));
            }

            var user = _context.Users.FirstOrDefault(u => u.Token == token);

            if (user == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "login", controller = "user" }));
            }

            context.RouteData.Values["User"] = user;

            base.OnActionExecuting(context);
        }
    }
}
