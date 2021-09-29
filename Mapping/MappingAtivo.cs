using AutoMapper;
using CadastroEstoque.DTOs;
using CadastroEstoque.Models;

namespace CadastroEstoque.Mapping
{
    public class MappingAtivo : Profile
    {
        public MappingAtivo()
        {
            CreateMap<Ativo, AtivoDTO>()
                .ForMember(dest => dest.Setor,
                map => map.MapFrom(src => $"{src.Setor}"))
                .ReverseMap();
            
        }
        
    }
}
