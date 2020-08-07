using Microsoft.AspNetCore.Mvc.Filters;
using EPublico.Core.Helpers;

namespace EPublico.Core.Classes
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Validates Model automaticaly 
        /// </summary>
        /// <param name="context"></param>
        /// <inheritdoc />
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                // context.Result = new BadRequestObjectResult(context.ModelState);
                context.Result = OResult.BadRequestResult(context.ModelState);
            }
        }
    }
}