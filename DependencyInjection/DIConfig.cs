using CadastroEstoque.Interface;
using CadastroEstoque.Repository;
using CadastroEstoque.Service;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroEstoque.DependencyInjection
{
    public class DIConfig
    {
        public static void Register(IServiceCollection service)
        {
            service.AddTransient<ICategoriaService, CategoriaService>();
            service.AddTransient<ICategoriaRepository, CategoriaRepository>();

            service.AddTransient<IAtivoService, AtivoService>();
            service.AddTransient<IAtivoRepository, AtivoRepository>();


        }
    }
}
