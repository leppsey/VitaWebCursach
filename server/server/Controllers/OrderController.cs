using DAL;
using Microsoft.AspNetCore.Mvc;
using server.DTO;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        public OrderController(MyContext context)
        {
            _context = context;
        }

        private MyContext _context { get; }

        [HttpPost]
        public async Task<ActionResult<ulong>> Create([FromBody] AddOrderDTO addOrderDTO)
        {
            var productsCount = addOrderDTO.ProductCount.Select(product => new ProductInCart()
                                           {
                                               Product = _context.Products.Find(product.Id),
                                               ProductCount = product.Count,
                                           })
                                           .ToList();
            var order = new Order()
            {
                ProductsCount = productsCount,
                PhoneNumber = addOrderDTO.PhoneNumber,
            };
            _context.Orders.Add(order);
            _context.SaveChanges();

            return Ok(order.Id);
        }
    }
}
