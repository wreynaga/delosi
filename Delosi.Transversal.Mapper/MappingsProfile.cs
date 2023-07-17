using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Delosi.Application.DTO;
using Delosi.Domain.Entity;

namespace Delosi.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Matrix, MatrixDTO>().ReverseMap();
        }
    }
}
