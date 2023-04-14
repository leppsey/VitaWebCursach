using DAL;
using Microsoft.AspNetCore.Mvc;
using server.DTO;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public ProductController(MyContext context) {
            _context = context;
        }

        private MyContext _context { get; }

        [HttpGet]
        public IEnumerable<ProductDTO> GetAll()
        {
            var products = _context.Products.ToList();
            var productDtos = new List<ProductDTO>();    
            foreach (var product in products)
            {
                var dto = new ProductDTO();
                dto.Title = product.Title;
                dto.Id = product.Id;
                dto.ItemsInbox = product.ItemsInbox;
                dto.Price= product.Price;
                dto.Weight= product.Weight;
                dto.Image = System.IO.File.ReadAllBytes("images/" + product.ImageSource);
                productDtos.Add(dto);
            }
            return productDtos;
        }
    }
}
