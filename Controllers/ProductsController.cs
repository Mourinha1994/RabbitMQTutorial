using Microsoft.AspNetCore.Mvc;
using RabbitMQTutorial.MessageBroker;
using RabbitMQTutorial.Models;
using RabbitMQTutorial.Models.Interfaces;

namespace RabbitMQTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IRabbitMQProducer _rabbitMQProducer;
        public ProductsController(IProductService productService, IRabbitMQProducer rabbitMQProducer)
        {
            _productService = productService;
            _rabbitMQProducer = rabbitMQProducer;
        }

        [HttpGet("productList")]
        public IEnumerable<Product> GetAllProducts()
            => _productService.GetProductList();

        [HttpGet("getProductById")]
        public Product GetProductById(int id)
            => _productService.GetProductById(id);
        
        [HttpPost("addproduct")]
        public Product AddProduct(Product product)
        {
            var productData = _productService.AddProduct(product);
            _rabbitMQProducer.SendMessage(productData);
            return productData;
        }

        [HttpPut("updateProduct")]
        public Product UpdateProduct(Product product)
            => _productService.UpdateProduct(product);

        [HttpDelete("deleteProduct")]
        public bool DeleteProduct(int id)
            => _productService.DeleteProduct(id);
    }
}
