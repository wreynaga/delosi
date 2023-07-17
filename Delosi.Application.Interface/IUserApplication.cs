using Delosi.Application.DTO;
using Delosi.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delosi.Application.Interface
{
    public interface IUserApplication
    {
        Response<UserDTO> Authenticate(string username, string password);
    }
}
