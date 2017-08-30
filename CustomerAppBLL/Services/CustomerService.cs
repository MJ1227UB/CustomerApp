using System;
using System.Collections.Generic;
using CustomerAppBLL.BusinessObjects;
using CustomerAppDAL;
using CustomerAppDAL.Entities;
using System.Linq;
using CustomerAppBLL.Converters;

namespace CustomerAppBLL.Services
{
    class CustomerService : ICustomerService
    {
        CustomerConverter converter = new CustomerConverter();
        private DALFacade facade;

        public CustomerService(DALFacade facade)
        {
            this.facade = facade;
        }

        public CustomerBO Create(CustomerBO customer)
        {
            using(var uow = facade.UnitOfWork)
            {
                var newCustomer = uow.CustomerRepository.Create(converter.Convert(customer));
                uow.Complete();
                return converter.Convert(newCustomer);
            }
        }

        public List<CustomerBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                //Customer -> CustomerBO
                //return uow.CustomerRepository.GetAll();
                return uow.CustomerRepository.GetAll().Select(converter.Convert).ToList();
            }
        }

        public CustomerBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return converter.Convert(uow.CustomerRepository.Get(Id));
            }
        }

        public CustomerBO Update(CustomerBO customer)
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
                return converter.Convert(customerFromDB);
            }
        }

        public CustomerBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newCustomer = uow.CustomerRepository.Delete(Id);
                uow.Complete();
                return converter.Convert(newCustomer);
            }
        }
    }
}
