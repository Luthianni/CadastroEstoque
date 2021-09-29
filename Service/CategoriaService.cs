using AutoMapper;
using CadastroEstoque.DTOs;
using CadastroEstoque.Interface;
using CadastroEstoque.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroEstoque.Service
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IMapper mapper;
        private readonly ICategoriaRepository repository;

        public CategoriaService(IMapper mapper, ICategoriaRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task AddAsync(CategoriaDTO categoriaDTO)
        {
            var entidade = mapper.Map<Categoria>(categoriaDTO);            
            await repository.Adicionar(entidade);
        }

        public async Task<IEnumerable<CategoriaDTO>> GetAllAsync()
        {
            var categorias = await repository.ObterTodos();
            var categoriasVM = mapper.Map<IEnumerable<CategoriaDTO>>(categorias);

            return categoriasVM;
        }

        public async Task<CategoriaDTO> GetByIdAsync(Guid Id)
        {
            var categoria = await repository.Editar(Id);
            var entidade = mapper.Map<CategoriaDTO>(categoria);

            return entidade;
        }

        public async Task<CategoriaDTO> UpdateAsync(CategoriaDTO categoria)
        {
            var UpdateCat = mapper.Map<Categoria>(categoria);
            await repository.Update(UpdateCat);
            var CatUpdate = mapper.Map<CategoriaDTO>(UpdateCat);

            return CatUpdate;
        }

        public async Task<bool> Delete(Guid Id)
        {
            return await repository.Deletar(Id);
        }

    }

}
