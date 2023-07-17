using AutoMapper;
using Delosi.Application.DTO;
using Delosi.Application.Interface;
using Delosi.Application.Validator;
using Delosi.Domain.Interface;
using Delosi.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delosi.Application.Main
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserDomain _userDomain;
        private readonly IMapper _mapper;
        private readonly UserDtoValidator _usersDtoValidator;

        public UserApplication(IMapper mapper, UserDtoValidator usersDtoValidator, IUserDomain userDomain)
        {
            _mapper = mapper;
            _usersDtoValidator = usersDtoValidator;
            _userDomain = userDomain;
        }

        public Response<UserDTO> Authenticate(string username, string password)
        {
            var response = new Response<UserDTO>();
            var validation = _usersDtoValidator.Validate(new UserDTO() { UserName = username, Password = password });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                return response;
            }
            try
            {
                var user = _userDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UserDTO>(user);
                response.IsSuccess = true;
                response.Message = "Autenticación Exitosa!!!";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
