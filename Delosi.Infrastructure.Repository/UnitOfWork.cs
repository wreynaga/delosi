using Delosi.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delosi.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository Users { get; }

        public UnitOfWork(IUserRepository users)
        {
            Users = users;
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
