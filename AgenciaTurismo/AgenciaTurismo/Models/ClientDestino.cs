namespace AgenciaTurismo.Models
{
    public class ClientDestino
    {
        public int ClienteId { get; set; }
        public int DestinoId { get; set; }
        public Cliente Cliente { get; set; }
        public Destino Destino { get; set; }

    }
}
