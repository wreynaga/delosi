using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delosi.Infrastructure.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
    }
}
