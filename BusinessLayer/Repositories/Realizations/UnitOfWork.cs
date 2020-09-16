using BusinessLayer.Repositories.Interfaces;
using DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Repositories.Realizations
{
    public class UnitOfWork : IUnitOfWork
    {
        public TestDbContext Context { get; }

        public UnitOfWork(TestDbContext context)
        {
            Context = context;
        }
        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();

        }
    }
}
