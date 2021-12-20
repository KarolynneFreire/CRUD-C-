using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgenciaTurismo.Models
{
    public class Destino
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Atenção! esse campo é de preenchimento obrigatório")]
        public string Nome { get; set; }
        [Required (ErrorMessage = "Atenção! esse campo é de preenchimento obrigatório")]
        public string Valor { get; set; }
        [Required(ErrorMessage = "Atenção! esse campo é de preenchimento obrigatório")]

        public DateTime DataInicio { get; set; }
        [Required(ErrorMessage = "Atenção! esse campo é de preenchimento obrigatório")]

        public DateTime DataFinal { get; set; }
        [Required(ErrorMessage = "Atenção! esse campo é de preenchimento obrigatório")]

        public string Descricao { get; set; }

        public Promocao Promocao { get; set; }
        public List <ClientDestino> ClientsDestinos { get; set; }
}
}
