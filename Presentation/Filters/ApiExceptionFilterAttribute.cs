using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GADistribuidora.Presentation.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is Exception exception)
            {
                context.Result = new ObjectResult(new { message = exception.Message })
                {
                    StatusCode = 500 
                };
            }
        }
    }

}
