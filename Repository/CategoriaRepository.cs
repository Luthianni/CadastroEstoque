 using CadastroEstoque.Context;
using CadastroEstoque.Interface;
using CadastroEstoque.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroEstoque.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> ObterTodos()
        {
            return await _context.Categorias.ToListAsync();
        }
        public async Task Adicionar(Categoria entidade)
        {
            await _context.Categorias.AddAsync(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Deletar(Guid id)
        {
            var del = await _context.Categorias.SingleOrDefaultAsync(d => d.Id.Equals(id));
            if (del == null)
                return false;
            _context.Remove(del);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Categoria> Editar(Guid id)
        {
            return await _context.Categorias.SingleOrDefaultAsync(e => e.Id.Equals(id));
        }        
            
        public async Task<Categoria> Update(Categoria categoria)
        {
            var up = await _context.Categorias.SingleOrDefaultAsync(u => u.Id.Equals(categoria.Id));
            if (up == null)

                return null;
            _context.Entry(up).CurrentValues.SetValues(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }
    }
}
