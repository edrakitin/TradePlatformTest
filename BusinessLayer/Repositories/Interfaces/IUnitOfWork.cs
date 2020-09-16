using DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        TestDbContext Context { get; }
        void Commit();
    }
}
