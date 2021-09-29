using CadastroEstoque.Identity;

namespace CadastroEstoque.Models
{
    public class Categoria : BaseIdentity
    {
        public string CategoriaNome { get; set; }

        public decimal Taxa { get; set; }

        

    }
}
