using Microsoft.EntityFrameworkCore;

namespace Application
{
    public class CustomerDataContext : DbContext
    {
        public CustomerDataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
