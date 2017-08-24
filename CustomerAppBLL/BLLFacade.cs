using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppBLL.Services;
using CustomerAppDAL;

namespace CustomerAppBLL
{
    public class BLLFacade
    {
        public ICustomerService CustomerService
        {
            get { return new CustomerService(new DALFacade()); }
        }
    }
}
