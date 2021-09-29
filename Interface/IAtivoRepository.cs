using CadastroEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroEstoque.Interface
{
    public interface IAtivoRepository
    {
        Task<IEnumerable<Ativo>> ObterTodos();

        Task Adicionar(Ativo entidade);

        Task<Ativo> Editar(Guid Id);

        Task<Ativo> Update(Ativo ativo);

        Task<bool> Delete(Guid Id);

        //IQueryable<Ativo> QueryablePorId(Guid Id);
    }
}
