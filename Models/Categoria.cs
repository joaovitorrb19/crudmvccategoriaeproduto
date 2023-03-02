using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Models {
    public class Categoria {
        [Key]
        public int id{get;set;}
        [Required(ErrorMessage ="Nome da categoria requerida...")]
        public string? nome{get;set;}
    }
}