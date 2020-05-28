using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace Application.Tests
{
    [Collection("FirstStage")]
    public class FirstStage
    {
        [Fact]
        public void GetAllCustomer()
        {
            var options = new DbContextOptionsBuilder<CustomerDataContext>()
                .UseInMemoryDatabase("GetAllCustomer")
                .Options;
            var customerDataContext = new CustomerDataContext(options);
            Seed(customerDataContext);

            var query = new CustomerQuery(customerDataContext);
            var result = query.Execute();

            Assert.Equal(10, result.Count); 
        }


        [Fact]
        public void GetAllCustomerWihtOrder()
        {
            var options = new DbContextOptionsBuilder<CustomerDataContext>()
                .UseInMemoryDatabase("GetAllCustomerWihtOrder")
                .Options;
            var customerDataContext = new CustomerDataContext(options);
            Seed(customerDataContext);

            var query = new CustomerQuery(customerDataContext);
            var result = query.Execute();

            Assert.Equal("Aimil Gilliatt", result.First().Name);
        }


        private void Seed(CustomerDataContext customerDataContext)
        {
            var customers = new[]
            {
                new Customer { Id = 1, Name = "Aubrey Kisar" },
                new Customer { Id = 2, Name = "Sloan Battey" },
                new Customer { Id = 3, Name = "Marwin Izakson" },
                new Customer { Id = 4, Name = "Fonzie Berrington" },
                new Customer { Id = 5, Name = "Irwinn Proger" },
                new Customer { Id = 6, Name = "Renaud Limeburn" },
                new Customer { Id = 7, Name = "Aimil Gilliatt" },
                new Customer { Id = 8, Name = "Bradford Corpe" },
                new Customer { Id = 9, Name = "Saunders Kapelhoff" },
                new Customer { Id = 10, Name = "Gertrud Kelloch" }
            };

            customerDataContext.Customers.AddRange(customers);
            customerDataContext.SaveChanges();
        }
    }
}
