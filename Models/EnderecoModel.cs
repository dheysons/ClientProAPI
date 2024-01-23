using System.ComponentModel.DataAnnotations;

namespace ClienteAPI.Models
{
    public class EnderecoModel
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O campo CEP não possui um formato válido.")]
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Referencia { get; set; }

        // Propriedade para associar o endereço a um cliente específico
        public ClienteModel Cliente { get; set; }
    }
}
