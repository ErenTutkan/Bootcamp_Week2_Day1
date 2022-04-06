using Bootcamp_Week2_Day1.DTOs;
using Microsoft.AspNetCore.Diagnostics;

namespace Bootcamp_Week2_Day1.Middleware
{
    public static class GlobalExceptionHandlerMiddleware
    {
        public static void UseGlobalExceptionMiddleware(this IApplicationBuilder app)
        {
            //Middleware Global Exception 
            app.UseExceptionHandler(options =>
            {
                options.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var exception = exceptionFeature.Error;
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsJsonAsync<ResponseDto<NoContentDto>>(ResponseDto<NoContentDto>.Fail(exception.Message));
                });

            });
        }
    }
}
