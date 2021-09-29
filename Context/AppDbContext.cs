using CadastroEstoque.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroEstoque.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Categoria> Categorias { get; set; }              

        public DbSet<Ativo> Ativos { get; set; }
       
    }
}
