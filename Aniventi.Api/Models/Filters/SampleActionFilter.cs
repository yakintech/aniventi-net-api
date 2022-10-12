using Microsoft.AspNetCore.Mvc.Filters;

namespace Aniventi.Api.Models.Filters
{
    public class SampleActionFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
           
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
           
        }
    }
}
