using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppDAL.Entities;

namespace CustomerAppDAL
{
    public interface ICustomerRepository
    {
        //Create
        Customer Create(Customer customer);

        //Read
        List<Customer> GetAll();
        Customer Get(int Id);

        //Delete
        Customer Delete(int Id);
    }
}
