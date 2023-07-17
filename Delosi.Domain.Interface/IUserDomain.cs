using Delosi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delosi.Domain.Interface
{
    public interface IUserDomain
    {
        User Authenticate(string username, string password);
    }
}
