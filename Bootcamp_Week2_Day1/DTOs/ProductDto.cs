using Bootcamp_Week2_Day1.Model;

namespace Bootcamp_Week2_Day1.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public ProductDto()
        {

        }
        public ProductDto(Product product)
        {
            Name = product.Name;
            Price = product.Price;
            Stock = product.Stock;
        }
    }
}
