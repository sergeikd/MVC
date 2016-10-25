using Castle.MicroKernel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Mvc.Async;

namespace Oxagile.Internal.MVC.WindsorResolver
{
    public class WindsorActionInvoker : AsyncControllerActionInvoker
    {
        private readonly DbContext _dbContext;

        public WindsorActionInvoker(IKernel kernel)
        {
            _dbContext = kernel.Resolve<DbContext>();
        }

        protected override ActionResult InvokeActionMethod(ControllerContext controllerContext,
            ActionDescriptor actionDescriptor,
            IDictionary<string, object> parameters)
        {
            var actionResult = base.InvokeActionMethod(controllerContext, actionDescriptor, parameters);
            _dbContext.SaveChanges();
            return actionResult;
        }
    }
}