using CadastroEstoque.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroEstoque.Service
{
    public interface IAtivoService
    {
        Task AddAsync(AtivoDTO ativoDTO);

        Task<IEnumerable<AtivoDTO>> GetAllAsync();

        Task<AtivoDTO> GetByIdAsync(Guid Id);

        Task<AtivoDTO> UpdateAsync(AtivoDTO ativo);

        Task<bool> Delete(Guid Id);
       
    }
}
