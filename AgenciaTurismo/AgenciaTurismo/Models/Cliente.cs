using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgenciaTurismo.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Atenção! esse campo é de preenchimento obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Atenção! esse campo é de preenchimento obrigatório")]

        public string Cpf { get; set; }
       


        public List <ClientDestino> ClientsDestinos { get; set; }
    }
}
