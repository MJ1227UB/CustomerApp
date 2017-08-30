using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppBLL.BusinessObjects;
using CustomerAppDAL.Entities;

namespace CustomerAppBLL.Converters
{
    class CustomerConverter
    {
        internal Customer Convert(CustomerBO customer)
        {
            return new Customer()
            {
                Id = customer.Id,
                Adress = customer.Adress,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
        }

        internal CustomerBO Convert(Customer customer)
        {
            return new CustomerBO()
            {
                Id = customer.Id,
                Adress = customer.Adress,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
        }
    }
}
