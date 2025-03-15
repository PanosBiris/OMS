using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace PB.OMS.CustomerService.Data
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }
    }
}
