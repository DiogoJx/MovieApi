using AutoMapper;
using WebApplication1.Data.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Profiles
{
    public class EnderecoProfile : Profile
    {

        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<UpdateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();
        }
    }
}
