using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Product
    {
        public ulong Id { get; set; }
        public string Title { get; set; }
        public int ItemsInbox { get; set; }
        public double Weight { get; set; }
        public decimal Price { get; set; }
        public string ImageSource { get; set; }
        public List<Order> Orders { get; set; }
    }
}
