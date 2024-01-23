using ClienteAPI.Models;

namespace ClienteAPI.Repositories
{
    public interface IEnderecoRepository
    {
        List<EnderecoModel> GetAllByClienteId(int clienteId);
        EnderecoModel GetById(int clienteId, int enderecoId);
        void AddEndereco(EnderecoModel endereco);
        void UpdateEndereco(EnderecoModel endereco);
        void RemoveEndereco(int clienteId, int enderecoId);
        EnderecoModel GetEnderecoById(int clienteId, int enderecoId);
    }

    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly List<EnderecoModel> _enderecoData;

        public EnderecoRepository()
        {
            _enderecoData = new List<EnderecoModel>();
        }

        public List<EnderecoModel> GetAllByClienteId(int clienteId)
        {
            return _enderecoData.Where(e => e.Cliente.Id == clienteId).ToList();
        }

        public EnderecoModel GetById(int clienteId, int enderecoId)
        {
            return _enderecoData.FirstOrDefault(e => e.Cliente.Id == clienteId && e.Id == enderecoId);
        }

        public void AddEndereco(EnderecoModel endereco) 
        {
            // Lógica para adicionar ao seu repositório de dados
            _enderecoData.Add(endereco);
        }

        public void UpdateEndereco(EnderecoModel endereco)
        {
            var existingEndereco = _enderecoData.FirstOrDefault(e => e.Cliente.Id == endereco.Cliente.Id && e.Id == endereco.Id);
            if (existingEndereco != null)
            {
                existingEndereco.Logradouro = endereco.Logradouro;
                existingEndereco.Tipo = endereco.Tipo;
                existingEndereco.CEP = endereco.CEP;
                existingEndereco.Numero = endereco.Numero;
                existingEndereco.Bairro = endereco.Bairro;
                existingEndereco.Complemento = endereco.Complemento;
                existingEndereco.Cidade = endereco.Cidade;
                existingEndereco.Estado = endereco.Estado;
                existingEndereco.Referencia = endereco.Referencia;
            }
        }

        public void RemoveEndereco(int clienteId, int enderecoId)
        {
            var enderecoToRemove = _enderecoData.FirstOrDefault(e => e.Cliente.Id == clienteId && e.Id == enderecoId);
            if (enderecoToRemove != null)
            {
                _enderecoData.Remove(enderecoToRemove);
            }
        }

        public EnderecoModel GetEnderecoById(int clienteId, int enderecoId)
        {
            return _enderecoData.FirstOrDefault(e => e.Cliente.Id == clienteId && e.Id == enderecoId);
        }
    }
}
