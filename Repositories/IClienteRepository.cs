using ClienteAPI.Models;

namespace ClienteAPI.Repositories
{
    public interface IClienteRepository
    {
        List<ClienteModel> GetAll();
        ClienteModel GetById(int id);
        void Add(ClienteModel cliente);
        void Update(ClienteModel cliente);
        void Remove(int id);
    }

    public class ClienteRepository : IClienteRepository
    {
        private List<ClienteModel> _clientes;

        public ClienteRepository()
        {
            // Inicialização da lista (simulando um repositório em memória)
            _clientes = new List<ClienteModel>();
        }

        public List<ClienteModel> GetAll()
        {
            return _clientes;
        }

        public ClienteModel GetById(int id)
        {
            return _clientes.FirstOrDefault(c => c.Id == id);
        }

        public void Add(ClienteModel cliente)
        {
            // Lógica para adicionar um cliente
            cliente.Id = _clientes.Count + 1;
            _clientes.Add(cliente);
        }

        public void Update(ClienteModel cliente)
        {
            // Lógica para atualizar um cliente
            var existingCliente = _clientes.FirstOrDefault(c => c.Id == cliente.Id);
            if (existingCliente != null)
            {
                // Atualiza as propriedades do cliente existente
                existingCliente.Nome = cliente.Nome;
                existingCliente.Email = cliente.Email;
                existingCliente.Cpf = cliente.Cpf;
                existingCliente.RG = cliente.RG;
                existingCliente.Contatos = cliente.Contatos;
                existingCliente.Enderecos = cliente.Enderecos;
            }
        }

        public void Remove(int id)
        {
            // Lógica para remover um cliente
            var clienteToRemove = _clientes.FirstOrDefault(c => c.Id == id);
            if (clienteToRemove != null)
            {
                _clientes.Remove(clienteToRemove);
            }
        }
    }
}
