namespace ClienteAPI.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Tipo { get; set; }
        public int DDD { get; set; }
        public decimal Telefone { get; set; }

    }
}
