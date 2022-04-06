using Bootcamp_Week2_Day1.DTOs;
using Bootcamp_Week2_Day1.Filter;
using Bootcamp_Week2_Day1.Manager;
using Bootcamp_Week2_Day1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp_Week2_Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProduct(int id)
        {
            return new OkObjectResult(_productService.GetById(id));
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            return new OkObjectResult(_productService.GetAll());
        }
        [HttpPost]
        public IActionResult Save(SaveProductRequestDto newProduct)
        {
            return _productService.Save(new Product() {
                Id=newProduct.Id,Name=newProduct.Name,Price=newProduct.Price,Stock=newProduct.Stock});
        }
        [ServiceFilter(typeof(NotFoundProductFilter))]
        [HttpPut("{id:int}")]
        public IActionResult Update(int id,UpdateProductRequestDto updateProduct)
        {
            var product=new Product() { Id=id,Name=updateProduct.Name,Price=updateProduct.Price,Stock=updateProduct.Stock};
            var result = _productService.Update(product);
            if (result.StatusCode==204)
            {
                return new ObjectResult(null) { StatusCode=result.StatusCode };
            }
            return new ObjectResult(null) { StatusCode = result.StatusCode };
        }
        [ServiceFilter(typeof(NotFoundProductFilter))]
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return new ObjectResult(null) { StatusCode=204};
        }
    }
}
