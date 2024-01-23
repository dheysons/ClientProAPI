using System.ComponentModel.DataAnnotations;

namespace ClienteAPI.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [EmailAddress(ErrorMessage = "O campo E-mail não possui um formato válido.")]
        public string Email { get; set; }
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O campo CPF não possui um formato válido.")]
        public string Cpf { get; set; }
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}-\d{1,2}$", ErrorMessage = "O campo RG não possui um formato válido.")]
        public string RG { get; set; }
        public List<ContatoModel> Contatos { get; set; }
        public List<EnderecoModel> Enderecos { get; set; }

    }
}
