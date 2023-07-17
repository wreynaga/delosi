using Delosi.Domain.Entity;
using Delosi.Domain.Interface;
using Delosi.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delosi.Domain.Core
{
    public class UserDomain : IUserDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User Authenticate(string username, string password)
        {
            return _unitOfWork.Users.Authenticate(username, password);
        }
    }
}
