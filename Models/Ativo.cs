using CadastroEstoque.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroEstoque.Models
{
    public class Ativo : BaseIdentity
    {
        [Required]
        [Display(Name = "Setor")]
        public string Setor { get; set; }

        [Required(ErrorMessage = "O nome do responsavel é obrigatório")]
        [Display(Name = "Nome do Resposável")]
        public string Responsavel { get; set; }
        [Required]
        [Display(Name = "Plaqueta")]
        public string Plaqueta { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCompra { get; set; }
        [Required]
        [Display(Name = "Valor do Produto")]
        public decimal ValorProduto { get; set; }
        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public Guid CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

       
    }
}
