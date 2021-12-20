using System.ComponentModel.DataAnnotations;

namespace AgenciaTurismo.Models
{
    public class Promocao
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Atenção! esse campo é de preenchimento obrigatório")]
        public int Desconto { get; set; }
        [Required(ErrorMessage = "Atenção! esse campo é de preenchimento obrigatório")]
        public int DestinoId { get; set; }
        public Destino Destino { get; set; }
    }
}
