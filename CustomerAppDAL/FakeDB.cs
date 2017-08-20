using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppEntity;

namespace CustomerAppDAL
{
    public class FakeDB
    {
        #region Fake DB
        public static int Id = 1;
        public static List<Customer> Customers = new List<Customer>();
        #endregion
    }
}
