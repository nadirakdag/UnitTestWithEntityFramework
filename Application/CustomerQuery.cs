using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class CustomerQuery
    {
        private readonly CustomerDataContext _customerDataContext;
        public CustomerQuery(CustomerDataContext customerDataContext)
        {
            _customerDataContext = customerDataContext;
        }

        public List<Customer> Execute()
        {
            return _customerDataContext.Customers.OrderBy(x => x.Name).ToList();
        }
    }
}
