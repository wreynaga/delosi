using AutoMapper;
using Delosi.Application.DTO;
using Delosi.Application.Interface;
using Delosi.Application.Validator;
using Delosi.Domain.Entity;
using Delosi.Domain.Interface;
using Delosi.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delosi.Application.Main
{
    public class LogicApplication : ILogicApplication
    {
        private readonly ILogicDomain _logicDomain;
        private readonly IMapper _mapper;
        private readonly UserDtoValidator _usersDtoValidator;
        public LogicApplication(ILogicDomain logicDomain, IMapper mapper, UserDtoValidator usersDtoValidator)
        {
            _logicDomain = logicDomain;
            _mapper = mapper;
            _usersDtoValidator = usersDtoValidator;
        }
        public Response<MatrixDTO> Rotate(MatrixDTO request)
        {
            var response = new Response<MatrixDTO>();
            try
            {
               var requestEntity = _mapper.Map<Matrix>(request);
                var rotateResult = _logicDomain.Rotate(requestEntity);
                response.Data = _mapper.Map<MatrixDTO>(rotateResult);
                response.IsSuccess = true;
                response.Message = "Rotación Exitosa!!!";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Error en la rotación";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
