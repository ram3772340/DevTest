using System.Linq;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;

namespace DeveloperTest.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext context;

        public CustomerService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public CustomerModel[] GetCustomers()
        {
            return context.Customers.Select(x => new CustomerModel
            {
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName,
                CustomerType = x.CustomerType
            }).ToArray();
        }

        public CustomerModel GetCustomer(int customerId)
        {
            return context.Customers.Where(x => x.CustomerId == customerId).Select(x => new CustomerModel
            {
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName,
                CustomerType = x.CustomerType
            }).SingleOrDefault();
        }

        public CustomerModel CreateCustomer(BaseCustomerModel model)
        {
            var addedCustomer = context.Customers.Add(new Customer
            {
                CustomerName = model.CustomerName,
                CustomerType = model.CustomerType
            });

            context.SaveChanges();

            return new CustomerModel
            {
                CustomerId = addedCustomer.Entity.CustomerId,
                CustomerName = addedCustomer.Entity.CustomerName,
                CustomerType = addedCustomer.Entity.CustomerType
            };
        }
    }
}
