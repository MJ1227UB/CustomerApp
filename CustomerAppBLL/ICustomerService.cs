using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppEntity;

namespace CustomerAppBLL
{
    public interface ICustomerService
    {
        //Create
        Customer Create(Customer customer);

        //Read
        List<Customer> GetAll();
        Customer Get(int Id);

        //Update
        Customer Update(Customer customer);

        //Delete
        Customer Delete(int Id);
    }
}
