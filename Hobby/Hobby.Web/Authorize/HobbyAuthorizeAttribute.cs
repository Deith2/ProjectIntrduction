using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hobby.Web.Authorize
{
    public class HobbyAuthorizeAttribute : AuthorizeAttribute
    {
        protected virtual CustomPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as CustomPrincipal; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                if (!String.IsNullOrEmpty(Roles))
                {
                    if (!CurrentUser.IsInRole(Roles))
                    {
                        filterContext.Result = new RedirectToRouteResult(new
                     RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));
                    }
                }

                if (!String.IsNullOrEmpty(Users))
                {
                    //if (!Users.Contains(CurrentUser.UserId.ToString())) Do przemyślenie czy patrzeć po Id!!!!

                    if (!Users.Contains(CurrentUser.Email.ToString()))
                    {
                        filterContext.Result = new RedirectToRouteResult(new
                     RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));
                    }
                }
            }
        }
    }
}