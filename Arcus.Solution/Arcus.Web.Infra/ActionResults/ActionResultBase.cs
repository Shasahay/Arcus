using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Arcus.Web.Infra.ActionResults
{
    public abstract class MyActionResult : ActionResult
    {

    }

    public abstract class ActionResultBase<TController> : MyActionResult where TController : Controller
    {
        protected readonly Expression<Func<TController, ActionResult>> ViewNameExpression;

        public ActionResultBase(Expression<Func<TController, ActionResult>> expression)
        {
            this.ViewNameExpression = expression;
        }

        protected ViewResult GetViewResult<TViewModel>(TViewModel viewModel)
        {
            var v = (MethodCallExpression)this.ViewNameExpression.Body;
            if (v.Method.ReturnType != typeof(ActionResult))
            {
                throw new ArgumentException("Action Method" + v.Method.Name + "does not return Action Result");

            }
            var result = new ViewResult { ViewName = v.Method.Name };
            result.ViewData.Model = viewModel;
            return result;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            throw new NotImplementedException();
        }
    }
}
