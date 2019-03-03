using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ASPNETCore2_0
{
    public class ModelBindingFailureFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context
                    .HttpContext
                    .Response
                    .ContentType = "application/problem+json";

                var validationProblems = new ValidationProblemDetails(
                    context.ModelState)
                {
                    Title = "One or more validation errors occurred",
                    Status = (int)HttpStatusCode.BadRequest,
                    Instance = context.HttpContext.TraceIdentifier
                };

                context.Result = new BadRequestObjectResult(validationProblems);
            }
        }
    }
}