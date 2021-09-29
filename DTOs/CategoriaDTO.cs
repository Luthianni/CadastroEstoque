using CadastroEstoque.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroEstoque.DTOs
{
    public class CategoriaDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome da Categoria é obrigatório.")]
        public string CategoriaNome { get; set; }

        [Required]
        public decimal Taxa { get; set; }

        
    }
}
