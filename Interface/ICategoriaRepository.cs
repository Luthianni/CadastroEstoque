using CadastroEstoque.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroEstoque.Interface
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> ObterTodos();

        Task Adicionar(Categoria entidade);

        Task<Categoria> Editar(Guid id);

        Task<Categoria> Update(Categoria categoria);

        Task<bool> Deletar(Guid id);

    }
}
