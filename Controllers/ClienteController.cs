using ClienteAPI.Models;
using ClienteAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClienteAPI.Controllers
{
    // ClienteController.cs
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("listar")]
        public ActionResult<List<ClienteModel>> GetAll()
        {
            try
            {
                var clientes = _clienteService.GetAll();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("listarPorFiltro")]
        public ActionResult<List<ClienteModel>> GetByFilter([FromQuery] string nome = null, [FromQuery] string email = null, [FromQuery] string cpf = null)
        {
            try
            {
                var clientes = _clienteService.GetByFilter(nome, email, cpf);
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPost("criar")]
        public ActionResult Add([FromBody] ClienteModel cliente)
        {
            try
            {
                _clienteService.Add(cliente);
                return Ok("Cliente criado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPut("atualizar/{id}")]
        public ActionResult Update(int id, [FromBody] ClienteModel cliente)
        {
            try
            {
                var existingCliente = _clienteService.GetById(id);

                if (existingCliente == null)
                    return NotFound("Cliente não encontrado.");

                _clienteService.Update(id, cliente);
                return Ok("Cliente atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpDelete("remover/{id}")]
        public ActionResult Remove(int id)
        {
            try
            {
                var existingCliente = _clienteService.GetById(id);

                if (existingCliente == null)
                    return NotFound("Cliente não encontrado.");

                _clienteService.Remove(id);
                return Ok("Cliente removido com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }

}
