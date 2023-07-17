using Delosi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delosi.Infrastructure.Interface
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User Authenticate(string username, string password);
    }
}
