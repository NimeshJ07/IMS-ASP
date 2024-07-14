using IMSAppliaction.Model;
using Microsoft.EntityFrameworkCore;

namespace IMSApllication.Data
{
    public class IMSDbContext : DbContext
    {
        public IMSDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Users> users {  get; set; } 
        public DbSet<Products> products { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<OrderDetail> orderDetail { get; set; }

    }
}
