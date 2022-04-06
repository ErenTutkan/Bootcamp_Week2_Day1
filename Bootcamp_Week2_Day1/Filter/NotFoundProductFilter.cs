using Bootcamp_Week2_Day1.DTOs;
using Bootcamp_Week2_Day1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bootcamp_Week2_Day1.Filter
{
    public class NotFoundProductFilter:ActionFilterAttribute
    {
        private readonly IProductRepository _productRepository;

        public NotFoundProductFilter(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue=context.HttpContext.Request.RouteValues["id"];
            var id = int.Parse(idValue.ToString());
            var hasProduct=_productRepository.GetById(id);
            if (hasProduct!=null)
            {
                await next.Invoke();
                return;
            }
            context.Result = new NotFoundObjectResult(ResponseDto<NoContentDto>.Fail($"{id}'li Ürün Bulananamıştır.",404));

            
        }
    }
}
