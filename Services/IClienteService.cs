using ClienteAPI.Models;
using ClienteAPI.Repositories;
using Microsoft.Extensions.Options;

namespace ClienteAPI.Services
{
    public interface IClienteService
    {
        List<ClienteModel> GetAll();
        List<ClienteModel> GetByFilter(string nome, string email, string cpf);
        ClienteModel GetById(int id);
        void Add(ClienteModel cliente);
        void Update(int id, ClienteModel cliente);
        void Remove(int id);
    }

    // ClienteService.cs
    public class ClienteService : IClienteService
    {
        private readonly BancoDadosConfig _bancoDadosConfig;

        public ClienteService(IOptions<BancoDadosConfig> bancoDadosConfig)
        {
            _bancoDadosConfig = bancoDadosConfig.Value;
        }

        public List<ClienteModel> GetAllCliente()
        {
            return _bancoDadosConfig.Cliente;
        }


        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public List<ClienteModel> GetAll()
        {
            return _clienteRepository.GetAll();
        }

        public List<ClienteModel> GetByFilter(string nome, string email, string cpf)
        {
            var clientes = _clienteRepository.GetAll();

            if (!string.IsNullOrEmpty(nome))
            {
                clientes = clientes.Where(c => c.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(email))
            {
                clientes = clientes.Where(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(cpf))
            {
                clientes = clientes.Where(c => c.Cpf.Equals(cpf, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return clientes;
        }

        public ClienteModel GetById(int id)
        {
            return _clienteRepository.GetById(id);
        }

        public void Add(ClienteModel cliente)
        {
            if (ClienteEmailExists(cliente.Email))
            {
                throw new ArgumentException("E-mail já cadastrado.");
            }

            if (ClienteCpfExists(cliente.Cpf))
            {
                throw new ArgumentException("CPF já cadastrado.");
            }

            _clienteRepository.Add(cliente);
        }

        public void Update(int id, ClienteModel cliente)
        {
            var existingCliente = _clienteRepository.GetById(id);

            if (existingCliente == null)
            {
                return;
            }

            if (ClienteEmailExists(cliente.Email) && cliente.Email != existingCliente.Email)
            {
                throw new ArgumentException("E-mail já cadastrado.");
            }

            if (ClienteCpfExists(cliente.Cpf) && cliente.Cpf != existingCliente.Cpf)
            {
                throw new ArgumentException("CPF já cadastrado.");
            }

            existingCliente.Nome = cliente.Nome;
            existingCliente.Email = cliente.Email;
            existingCliente.Cpf = cliente.Cpf;

            _clienteRepository.Update(existingCliente);
        }

        public void Remove(int id)
        {
            var existingCliente = _clienteRepository.GetById(id);

            if (existingCliente == null)
            {
                return;
            }

            _clienteRepository.Remove(id);
        }

        private bool ClienteEmailExists(string email)
        {
            return _clienteRepository.GetAll().Any(c => c.Email == email);
        }

        private bool ClienteCpfExists(string cpf)
        {
            return _clienteRepository.GetAll().Any(c => c.Cpf == cpf);
        }
    }

}
