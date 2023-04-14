using DAL;
using Microsoft.AspNetCore.Mvc;
using server.DTO;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController
    {
        public OrderController(MyContext context)
        {
            _context = context;
        }

        private MyContext _context { get; }

        [HttpPost]
        public void Create([FromBody] AddOrderDTO addOrderDTO)
        {
            var products = _context.Products.Where(p=>addOrderDTO.ProductIds.Contains(p.Id)).ToList();
            var order = new Order()
            {
                Products = products,
                PhoneNumber = addOrderDTO.PhoneNumber
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
