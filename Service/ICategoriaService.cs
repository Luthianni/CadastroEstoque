using CadastroEstoque.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroEstoque.Service
{
    public interface ICategoriaService
    {
        Task AddAsync(CategoriaDTO categoriaDTO);

        Task<IEnumerable<CategoriaDTO>> GetAllAsync();

        Task<CategoriaDTO> GetByIdAsync(Guid Id);

        Task<CategoriaDTO> UpdateAsync(CategoriaDTO categoria);

        Task<bool> Delete(Guid Id);
    }
}
