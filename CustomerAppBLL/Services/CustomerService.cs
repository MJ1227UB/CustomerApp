using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerAppDAL;
using CustomerAppEntity;

namespace CustomerAppBLL.Services
{
    class CustomerService : ICustomerService
    {
        ICustomerRepository repo;

        public CustomerService(ICustomerRepository repo)
        {
            this.repo = repo;
        }

        public Customer Create(Customer customer)
        {
            return repo.Create(customer);
        }

        public List<Customer> GetAll()
        {
            return repo.GetAll();
        }

        public Customer get(int Id)
        {
            return repo.get(Id);
        }

        public Customer Update(Customer customer)
        {
            var customerFromDB = get(customer.Id);
            if (customerFromDB == null)
            {
                throw new InvalidOperationException("Customer not found");
            }
            customerFromDB.FirstName = customer.FirstName;
            customerFromDB.LastName = customer.LastName;
            customerFromDB.Adress = customer.Adress;
            return customerFromDB;
        }

        public Customer Delete(int Id)
        {
            return repo.Delete(Id);
        }
    }
}
