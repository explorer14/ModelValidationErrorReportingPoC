using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace ASPNETCore2_0
{
    public class ModelBindingFailureFilterSimple : IActionFilter
    {
        private readonly ILogger _logger;

        public ModelBindingFailureFilterSimple(ILogger logger)
        {
            _logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var modelErrors = context
                    .ModelState
                    .ToDictionary(
                        x => x.Key,
                        y => y.Value.Errors.Select(
                            z => z.Exception.Message).ToList());

                _logger.Error(
                    "Model validation failed with following errors {@errors}",
                    modelErrors);

                context.Result = new BadRequestObjectResult(modelErrors);
            }
        }
    }
}
