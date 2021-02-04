using System.ComponentModel.DataAnnotations;

namespace testeAlter.Models
{
    ///Classe que define o produto e seus campos.
    public class Produto
    {
        ///Definição de tamanho máximo dos campos, no caso, a quantidade de caracteres.
        private const int qtde_max_name = 60, qtde_min_name = 3,
                          qtde_max_desc = 120, qtde_min_desc = 15,
                          qtde_max_bran = 100, qtde_min_bran = 4;
        [Key]
        public int Id { get; set;}

        [Required(ErrorMessage =  "Este campo é obrigatório.")]
        [MaxLength(qtde_max_name, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres.")]
        [MinLength(qtde_min_name, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres.")]
        public string Name { get; set;}

        [Required(ErrorMessage =  "Este campo é obrigatório.")]
        [MaxLength(qtde_max_desc, ErrorMessage = "Este campo deve conter entre 15 e 120 caracteres.")]
        [MinLength(qtde_min_desc, ErrorMessage = "Este campo deve conter entre 15 e 120 caracteres.")]
        public string Description { get; set;}

        [Required(ErrorMessage =  "Este campo é obrigatório.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public double Value { get; set;}
        
        [Required(ErrorMessage =  "Este campo é obrigatório.")]
        [MaxLength(qtde_max_bran, ErrorMessage = "Este campo deve conter entre 4 e 100 caracteres.")]
        [MinLength(qtde_min_bran, ErrorMessage = "Este campo deve conter entre 4 e 100 caracteres.")]
        public string Brand { get; set;}

        [Required(ErrorMessage =  "Este campo é obrigatório.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public int Categoria_id { get; set;}
        public Categoria Categoria { get;set; } // Propriedade de Navegação. Adicionado para que seja possível acessar as propriedades da catergoria a partir do produto.
    }
}