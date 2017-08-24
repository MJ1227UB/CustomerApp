using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerAppEntity;

namespace CustomerAppDAL.Repositories
{
    public class CustomerRepositoryFakeDB : ICustomerRepository
    {
        #region Fake DB
        private static int Id = 1;
        private static List<Customer> Customers = new List<Customer>();
        #endregion

        public Customer Create(Customer customer)
        {
            Customer newCustomer;
            Customers.Add(newCustomer = new Customer()
            {
                Id = Id++,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Adress = customer.Adress
            });
            return newCustomer;
        }

        public List<Customer> GetAll()
        {
            return new List<Customer>(Customers);
        }

        public Customer Get(int Id)
        {
            return Customers.FirstOrDefault(x => x.Id == Id);
        }


        public Customer Delete(int Id)
        {
            var customer = Get(Id);
            Customers.Remove(customer);
            return customer;
        }
    }
}
