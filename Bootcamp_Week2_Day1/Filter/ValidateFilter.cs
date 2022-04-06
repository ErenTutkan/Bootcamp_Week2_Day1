using Bootcamp_Week2_Day1.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bootcamp_Week2_Day1.Filter
{
    public class ValidateFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid ==false) 
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                context.Result=new BadRequestObjectResult(ResponseDto<NoContentResult>.Fail(errors));
            }
        }
    }
}
