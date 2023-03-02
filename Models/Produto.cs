using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleEstoque.Models {
    public class Produto {
        [Key]
       public int id {get;set;}
        [Required(ErrorMessage ="nome do produto requerido...")]
        public string? nome {get;set;}
        [Required(ErrorMessage ="id categoria requerido")]
        public int? CategoriaId {get;set;}
        [Required(ErrorMessage ="quantidade disponivel no estoque requerido...")]
        public int estoque{get;set;}
        [Required(ErrorMessage ="preço do produto requerido...")]
        public double preco{get;set;}
    }
}