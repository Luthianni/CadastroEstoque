using CadastroEstoque.Context;
using CadastroEstoque.Interface;
using CadastroEstoque.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroEstoque.Repository
{
    public class AtivoRepository : IAtivoRepository
    {
        private readonly AppDbContext _context;

        public AtivoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ativo>> ObterTodos()
        {
            return await _context.Ativos.ToListAsync();
        }

        public async Task Adicionar(Ativo entidade)
        {
            await _context.Ativos.AddAsync(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Deletar(Guid Id)
        {
            var del = await _context.Ativos.SingleOrDefaultAsync(d => d.Id.Equals(Id));
            if (del == null)
                return false;
            _context.Remove(del);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Ativo> Editar(Guid Id)
        {
            return await _context.Ativos.Include(i => i.Categoria).SingleOrDefaultAsync(e => e.Id.Equals(Id));

        }

        public async Task<Ativo> Update(Ativo ativo)
        {
            var upt = await _context.Ativos.SingleOrDefaultAsync(a => a.Id.Equals(ativo.Id));
            if (upt == null)

                return null;
            _context.Entry(upt).CurrentValues.SetValues(ativo);
            await _context.SaveChangesAsync();

            return ativo;
        }

        public async Task<bool> Delete(Guid Id)
        {
            var del = await _context.Ativos.SingleOrDefaultAsync(d => d.Id.Equals(Id));
            if (del == null)
                return false;
            _context.Remove(del);
            await _context.SaveChangesAsync();

            return true;
        }
                
    }
}
