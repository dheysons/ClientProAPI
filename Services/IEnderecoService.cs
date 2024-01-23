using ClienteAPI.Models;
using ClienteAPI.Repositories;

namespace ClienteAPI.Services
{
    public interface IEnderecoService
    {
        List<EnderecoModel> GetAllEnderecos(int clienteId);
        EnderecoModel GetEnderecoById(int clienteId, int enderecoId);
        void AddEndereco(int clienteId, EnderecoModel endereco);
        void UpdateEndereco(int clienteId, EnderecoModel endereco);
        void RemoveEndereco(int clienteId, int enderecoId);
    }

    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public List<EnderecoModel> GetAllEnderecos(int clienteId)
        {
            return _enderecoRepository.GetAllByClienteId(clienteId);
        }

        public EnderecoModel GetEnderecoById(int clienteId, int enderecoId)
        {
            return _enderecoRepository.GetEnderecoById(clienteId, enderecoId);
        }

        public void AddEndereco(int clienteId, EnderecoModel endereco)
        {   
            _enderecoRepository.AddEndereco(endereco);
        }

        public void UpdateEndereco(int clienteId, EnderecoModel endereco)
        {
            _enderecoRepository.UpdateEndereco(endereco);
        }

        public void RemoveEndereco(int clienteId, int enderecoId)
        {
            _enderecoRepository.RemoveEndereco(clienteId, enderecoId);
        }
    }
}
