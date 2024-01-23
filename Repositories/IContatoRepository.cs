using ClienteAPI.Models;

namespace ClienteAPI.Repositories
{
    public interface IContatoRepository
    {
        List<ContatoModel> GetContatosByClienteId(int clienteId);
        ContatoModel GetContatoById(int contatoId);
        void AddContato(int clienteId, ContatoModel contato);
        void UpdateContato(ContatoModel contato);
        void RemoveContato(int contatoId);
    }

    public class ContatoRepository : IContatoRepository
    {
        private readonly List<ContatoModel> _contatos = new List<ContatoModel>();

        public List<ContatoModel> GetContatosByClienteId(int clienteId)
        {
            return _contatos.Where(c => c.ClienteId == clienteId).ToList();
        }

        public ContatoModel GetContatoById(int contatoId)
        {
            return _contatos.FirstOrDefault(c => c.Id == contatoId);
        }

        public void AddContato(int clienteId, ContatoModel contato)
        {
            contato.ClienteId = clienteId;
            _contatos.Add(contato);
        }

        public void UpdateContato(ContatoModel contato)
        {
            var existingContato = _contatos.FirstOrDefault(c => c.Id == contato.Id);

            if (existingContato != null)
            {
                // Atualizar as propriedades do contato existente
                existingContato.Tipo = contato.Tipo;
                existingContato.DDD = contato.DDD;
                existingContato.Telefone = contato.Telefone;
            }
        }

        public void RemoveContato(int contatoId)
        {
            var contatoToRemove = _contatos.FirstOrDefault(c => c.Id == contatoId);
            if (contatoToRemove != null)
            {
                _contatos.Remove(contatoToRemove);
            }
        }
    }


}
