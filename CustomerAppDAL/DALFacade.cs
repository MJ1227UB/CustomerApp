using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using CustomerAppDAL.Repositories;

namespace CustomerAppDAL
{
    public class DALFacade
    {
        public ICustomerRepository CustomerRepository
        {
            //Old FakeDB
            //get { return new CustomerRepositoryFakeDB();}
            get { return new CustomerRepositoryEFMemory(new Context.InMemoryContext()); }
        }
    }
}
