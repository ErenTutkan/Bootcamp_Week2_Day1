using Bootcamp_Week2_Day1.Controllers;
using Bootcamp_Week2_Day1.DTOs;
using Bootcamp_Week2_Day1.Model;
using Bootcamp_Week2_Day1.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp_Week2_Day1.Manager
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public ResponseDto<List<ProductDto>> GetAll()
        {
            var products = _productRepository.GetAll();
            var productsDto = from p in products select new ProductDto { Name = p.Name, Price = p.Price,Stock=p.Stock };
           return ResponseDto<List<ProductDto>>.Success(new List<ProductDto>(productsDto),200 );
        }
        public ResponseDto<ProductDto> GetById(int id)
        {
            var hasproduct = _productRepository.GetById(id);
            return ResponseDto<ProductDto>.Success(new ProductDto(hasproduct));
        }
        public IActionResult Save(Product newProduct)
        {
            _productRepository.Save(newProduct);
            return new CreatedAtActionResult(nameof(ProductsController.GetProduct),"Products", new { id = newProduct.Id }, newProduct);
        }
        public ResponseDto<NoContentDto> Update(Product updateProduct)
        {
            var hasProduct=_productRepository.GetById(updateProduct.Id);
            _productRepository.Update(updateProduct);
            return ResponseDto<NoContentDto>.Success(204);
        }
        public ResponseDto<NoContentDto> Delete(int id)
        {
            _productRepository.Delete(id);
            return ResponseDto<NoContentDto>.Success(204);
        }
        
    }
}
