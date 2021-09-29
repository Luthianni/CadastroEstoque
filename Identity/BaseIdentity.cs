using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroEstoque.Identity
{
    public class BaseIdentity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [DataType(DataType.Date)]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

    }
}
