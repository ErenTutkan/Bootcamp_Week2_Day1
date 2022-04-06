using Bootcamp_Week2_Day1.Model;

namespace Bootcamp_Week2_Day1.Repository
{
    public interface IProductRepository
    {
        public List<Product> GetAll();
        public Product GetById(int id);
        public void Save(Product newProduct);
        public void Update(Product updateProduct);
        public void Delete(int id);
    }
}
