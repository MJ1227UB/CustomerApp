using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppDAL.Context;
using CustomerAppDAL.Repositories;

namespace CustomerAppDAL.UOW
{
    public class UnitOfWorkMem : IUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; internal set; }
        private InMemoryContext context;

        public UnitOfWorkMem()
        {
            context = new InMemoryContext();
            CustomerRepository = new CustomerRepositoryEFMemory(context);
        }
        
        public void Dispose()
        {
            context.Dispose();
        }

        public int Complete()
        {
            //The number of objects written to the underlying database
            return context.SaveChanges();
        }
    }
}
