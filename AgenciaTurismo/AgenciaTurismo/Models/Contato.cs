using System.ComponentModel.DataAnnotations;

namespace AgenciaTurismo.Models
{
    public class Contato
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Atenção! esse campo é de preenchimento obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Atenção! esse campo é de preenchimento obrigatório")]
        public string Email { get; set; }
    } 
}