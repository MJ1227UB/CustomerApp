using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppBLL.BusinessObjects;

namespace CustomerAppBLL
{
    public interface ICustomerService
    {
        //Create
        CustomerBO Create(CustomerBO customer);

        //Read
        List<CustomerBO> GetAll();
        CustomerBO Get(int Id);

        //Update
        CustomerBO Update(CustomerBO customer);

        //Delete
        CustomerBO Delete(int Id);
    }
}
