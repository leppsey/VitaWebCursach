using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
        public MyContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
