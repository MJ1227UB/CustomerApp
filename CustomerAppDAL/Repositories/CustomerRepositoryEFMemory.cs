using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerAppDAL.Context;
using CustomerAppDAL.Entities;

namespace CustomerAppDAL.Repositories
{
    class CustomerRepositoryEFMemory : ICustomerRepository
    {
        private InMemoryContext _context;

        public CustomerRepositoryEFMemory(InMemoryContext context)
        {
            this._context = context;
        }
        public Customer Create(Customer customer)
        {
            _context.Customers.Add(customer);
            return customer;
        }

        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer Get(int Id)
        {
            return _context.Customers.FirstOrDefault(x => x.Id == Id);
        }

        public Customer Delete(int Id)
        {
            var customer = Get(Id);
            _context.Customers.Remove(customer);
            return customer;
        }
    }
}
