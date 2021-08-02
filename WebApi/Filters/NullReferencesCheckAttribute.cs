using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    public class NullReferencesCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.ModelState.AddModelError(string.Empty, "This is just for test");
            context.Result = new UnprocessableEntityObjectResult(context.ModelState);
        }
    }
}
