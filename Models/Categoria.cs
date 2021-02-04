using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace testeAlter.Models
{
    public class Categoria
    {
        private const int qtde_max_name = 60, qtde_min_name = 6,
                          qtde_max_desc = 120, qtde_min_desc = 15;
        [Key]
        public int Id { get; set;}

        [Required(ErrorMessage =  "Este campo é obrigatório.")]
        [MaxLength(qtde_max_name, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres.")]
        [MinLength(qtde_min_name, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres.")]
        public string Name { get; set;}

        [Required(ErrorMessage =  "Este campo é obrigatório.")]
        [MaxLength(qtde_max_desc, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres.")]
        [MinLength(qtde_min_desc, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres.")]
        public string Description { get; set;}
    }

}