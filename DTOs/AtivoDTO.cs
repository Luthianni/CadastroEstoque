using CadastroEstoque.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CadastroEstoque.DTOs
{
    public class AtivoDTO 
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome do setor é obrigatório")]
        [Display(Name = "Setor")]
        public string Setor { get; set; }

        [Required(ErrorMessage = "O nome do responsavel é obrigatório")]
        [Display(Name = "Nome do Resposável")]
        public string Responsavel { get; set; }

        [Required(ErrorMessage = "O numero da plaqueta é obrigatório")]
        [Display(Name = "Plaqueta")]
        public string Plaqueta { get; set; }

        [Required(ErrorMessage = "Obrigatório colocar a data da compra!!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]        
        public DateTime DataCompra { get; set; }

        [Required(ErrorMessage = "Obrigatório colocar o valor do produto!!")]
        [Display(Name = "Valor do Produto")]
        public decimal ValorProduto { get; set; } 
        
        [Required(ErrorMessage = "Obrigatório descrever os itens do equipamento!!")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
         
        public Guid CategoriaId { get; set; }
        public CategoriaDTO Categoria { get; set; }
        public ICollection<CategoriaDTO> Categorias { get; set; }
        public decimal Depreciacao { get; internal set; }
        
    }



}
