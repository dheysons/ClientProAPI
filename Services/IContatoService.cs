using ClienteAPI.Models;
using ClienteAPI.Repositories;

namespace ClienteAPI.Services
{
    public interface IContatoService
    {
        List<ContatoModel> GetContatosByClienteId(int clienteId);
        ContatoModel GetContatoById(int contatoId);
        void AddContato(int clienteId, ContatoModel contato);
        void UpdateContato(ContatoModel contato);
        void RemoveContato(int contatoId);

    }

    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IClienteRepository _clienteRepository;

        public ContatoService(IContatoRepository contatoRepository, IClienteRepository clienteRepository)
        {
            _contatoRepository = contatoRepository;
            _clienteRepository = clienteRepository;
        }

        public List<ContatoModel> GetContatosByClienteId(int clienteId)
        {
            var clienteExists = _clienteRepository.GetById(clienteId) != null;

            if (!clienteExists)
            {
                throw new InvalidOperationException("Cliente não encontrado.");
            }

            return _contatoRepository.GetContatosByClienteId(clienteId);
        }

        public ContatoModel GetContatoById(int contatoId)
        {
            var contato = _contatoRepository.GetContatoById(contatoId);

            if (contato == null)
            {
                throw new InvalidOperationException("Contato não encontrado.");
            }

            return contato;
        }

        public void AddContato(int clienteId, ContatoModel contato)
        {
            var cliente = _clienteRepository.GetById(clienteId);

            if (cliente == null)
            {
                throw new InvalidOperationException("Cliente não encontrado.");
            }

            cliente.Contatos.Add(contato);
            _clienteRepository.Update(cliente);
        }

        public void UpdateContato(ContatoModel contato)
        {
            _contatoRepository.UpdateContato(contato);
        }

        public void RemoveContato(int contatoId)
        {
            _contatoRepository.RemoveContato(contatoId);
        }
    }

}
