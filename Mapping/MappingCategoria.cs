using AutoMapper;
using CadastroEstoque.DTOs;
using CadastroEstoque.Models;

namespace CadastroEstoque.Mapping
{
    public class MappingCategoria : Profile
    {

        public MappingCategoria()
        {

            CreateMap<Categoria, CategoriaDTO>()
                .ForMember(dest => dest.CategoriaNome,
                map => map.MapFrom(src => $"{ src.CategoriaNome}"))
                .ReverseMap();
           
                
        }

    }
}
