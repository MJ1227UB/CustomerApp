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
        private DALFacade facade;

        public CustomerService(DALFacade facade)
        {
            this.facade = facade;
        }

        public Customer Create(Customer customer)
        {
            using(var uow = facade.UnitOfWork)
            {
                var newCustomer = uow.CustomerRepository.Create(customer);
                uow.Complete();
                return newCustomer;
            }
        }

        public List<Customer> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.CustomerRepository.GetAll();
            }
        }

        public Customer Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.CustomerRepository.Get(Id);
            }
        }

        public Customer Update(Customer customer)
        {
            using (var uow = facade.UnitOfWork)
            {
                var customerFromDB = uow.CustomerRepository.Get(customer.Id);
                if (customerFromDB == null)
                {
                    throw new InvalidOperationException("Customer not found");
                }
                customerFromDB.FirstName = customer.FirstName;
                customerFromDB.LastName = customer.LastName;
                customerFromDB.Adress = customer.Adress;
                uow.Complete();
                return customerFromDB;
            }
        }

        public Customer Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newCustomer = uow.CustomerRepository.Delete(Id);
                uow.Complete();
                return newCustomer;
            }
        }
    }
}
