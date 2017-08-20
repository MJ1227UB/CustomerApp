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
        public Customer Create(Customer customer)
        {
            Customer newCustomer;
            FakeDB.Customers.Add(newCustomer = new Customer()
            {
                ID = FakeDB.Id++,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Adress = customer.Adress
            });
            return newCustomer;
        }

        public List<Customer> GetAll()
        {
            return new List<Customer>(FakeDB.Customers);
        }

        public Customer get(int Id)
        {
            return FakeDB.Customers.FirstOrDefault(x => x.ID == Id);
        }

        public Customer Update(Customer customer)
        {
            var customerFromDB = get(customer.ID);
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
            var customer = get(Id);
            FakeDB.Customers.Remove(customer);
            return customer;
        }
    }
}
