using AutoMapper;
using WebPlenoCliente.Application.DTO;
using WebPlenoCliente.Domain.Entidades;

namespace WebPlenoCliente.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
        }
    }
}
