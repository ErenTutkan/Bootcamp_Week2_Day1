using Bootcamp_Week2_Day1.Model;

namespace Bootcamp_Week2_Day1.Repository
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> _products=new List<Product>()
        {
            new Product(){Id = 1, Name ="Kalem 1",Price=10,Stock=100},
            new Product(){Id = 2, Name ="Kalem 2",Price=10,Stock=100},
            new Product(){Id = 3, Name ="Kalem 3",Price=10,Stock=100},
        };
        public void Delete(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);
            _products.Remove(product);
        }

        public List<Product> GetAll() => _products;

        public Product GetById(int id)=>_products.FirstOrDefault(x=>x.Id==id);

        public void Save(Product newProduct)=>_products.Add(newProduct);

        public void Update(Product updateProduct)
        {
            var productindex = _products.FindIndex(x=>x.Id==updateProduct.Id);
            _products[productindex]=updateProduct;
        }
    }
}
