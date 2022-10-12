using Microsoft.AspNetCore.Mvc.Filters;

namespace Aniventi.Api.Models.Filters
{
    public class ResponseHeaderFilter : ActionFilterAttribute
    {
        private readonly string _name;
        private readonly string _value;

        public ResponseHeaderFilter(string name, string value)
        {
            _name = name;
            _value = value;
        }
        

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add(_name, _value);
            context.HttpContext.Response.Headers.Add("Roles", "1,3,4,5,9");
           

            base.OnResultExecuting(context);
        }
    }
}
