using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using CustomerAppDAL.Repositories;
using CustomerAppDAL.UOW;

namespace CustomerAppDAL
{
    public class DALFacade
    {
        public ICustomerRepository CustomerRepository
        {
            //Old FakeDB
            //Get { return new CustomerRepositoryFakeDB();}
            get { return new CustomerRepositoryEFMemory(new Context.InMemoryContext()); }
        }

        public IUnitOfWork UnitOfWork
        {
            get { return new UnitOfWorkMem(); }
        }
    }
    
}
