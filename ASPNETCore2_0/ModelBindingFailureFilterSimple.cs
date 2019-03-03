using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace ASPNETCore2_0
{
    public class ModelBindingFailureFilterSimple : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(
                    context
                    .ModelState
                    .ToDictionary(
                        x=>x.Key, 
                        y=>y.Value.Errors.Select(
                            z=>z.Exception.Message).ToList()));
            }
        }
    }
}