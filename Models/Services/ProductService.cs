using RabbitMQTutorial.Data;
using RabbitMQTutorial.Models.Interfaces;

namespace RabbitMQTutorial.Models.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductsDbContext _dbContext;
        public ProductService(ProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Product AddProduct(Product product)
        {
            var result = _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public bool DeleteProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Id == id); 
            var result = _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetProductList()
        {
            return _dbContext.Products.ToList();
        }

        public Product UpdateProduct(Product product)
        {
            var result = _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
