using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //var action = context.RouteData.Values["action"];
            //var controller = context.RouteData.Values["controller"];

            ////var param = context.ActionArguments
            ////    // ReSharper disable once PossibleNullReferenceException
            ////    .SingleOrDefault(x => x.Value.ToString().Contains("Dto")).Value;

            ////if (param == null)
            ////{
            ////    context.Result = new BadRequestObjectResult($"Object is null. Controller : {controller},Action:{action}");
            ////    return;
            ////}

            //if (!context.ModelState.IsValid)
            //{
            //    context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            //}

            context.ModelState.AddModelError("Test", "This is test from validation filter ");
            context.Result = new UnprocessableEntityObjectResult(context.ModelState);

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
