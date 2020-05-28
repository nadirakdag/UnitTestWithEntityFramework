using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace Application.Tests
{
    public class ThirdStageTestBase : IDisposable
    {
        protected readonly CustomerDataContext customerDataContext;

        public ThirdStageTestBase()
        {
            var options = new DbContextOptionsBuilder<CustomerDataContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString())
               .Options;

            customerDataContext = new CustomerDataContext(options);
            customerDataContext.Database.EnsureCreated();

            Seed(customerDataContext);
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

        public void Dispose()
        {
            customerDataContext.Database.EnsureDeleted();
            customerDataContext.Dispose();
        }
    }

    public class ThirdStage : ThirdStageTestBase
    {
        [Fact]
        public void GetAllCustomer()
        {
            var query = new CustomerQuery(customerDataContext);
            var result = query.Execute();

            Assert.Equal(10, result.Count);
        }
    }

    public class ThirdStageAnotherTest : ThirdStageTestBase
    {

        [Fact]
        public void GetAllCustomerWihtOrder()
        {
            var query = new CustomerQuery(customerDataContext);
            var result = query.Execute();

            Assert.Equal("Aimil Gilliatt", result.First().Name);
        }
    }
}
