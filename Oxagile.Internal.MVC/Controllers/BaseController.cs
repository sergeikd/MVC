using System;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace Oxagile.Internal.MVC.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            Log("OnAuthorization call", filterContext.RouteData);
        }

        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            Log("OnAuthentication call", filterContext.RouteData);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log("OnActionExecuting call", filterContext.RouteData);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("OnActionExecuted call", filterContext.RouteData);
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log("OnResultExecuting call", filterContext.RouteData);
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //Log("OnResultExecuted call", filterContext.RouteData);
            filterContext.HttpContext.Response.Write(DateTime.Now.ToLongTimeString() + " OnResultExecuted call" + 
                " controller: " + filterContext.RouteData.Values["controller"] + " action: " + filterContext.RouteData.Values["action"]);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            Log("Error", filterContext.RouteData);
        }

        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = $" {methodName} controller:{controllerName} action:{actionName}";
            string log = ViewBag.Log;
            ViewBag.Log = log + Environment.NewLine + DateTime.Now.ToLongTimeString() + message;
        }
    }
}
