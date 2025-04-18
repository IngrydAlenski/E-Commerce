using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;
using EcommerceAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository ClienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            ClienteRepository = clienteRepository;
        }
        [HttpGet]

        public IActionResult ListarTodos()
        {
            return Ok(ClienteRepository.ListarTodos());

        }

        [HttpPost]
        public IActionResult CadastrarProduto(Cliente cliente)
        {
         ClienteRepository.Cadastrar(cliente);

            return Created();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarProdutoPorId(int id)
        {
            var produto = ClienteRepository.BuscarPorId(id);

            if (produto == null)
                return NotFound(); // Retorna 404 se não encontrar o produto

            return Ok(produto); // Retorna 200 com os dados do produto
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarProduto(int id)
        {
            var produtoBuscado = ClienteRepository.BuscarPorId(id);

            if (produtoBuscado == null)
                return NotFound(); // 404 se não existir

            ClienteRepository.Deletar(id);

            return NoContent(); // 204 - Sucesso na exclusão
        }
        [HttpPut("{id}")]
        public IActionResult AtualizarProduto(int id, Cliente cliente)
        {
            var clienteBuscado = ClienteRepository.BuscarPorId(id);

            if (clienteBuscado == null)
                return NotFound(); // 404 se não existir

            ClienteRepository.Atualizar(id, cliente);

            return NoContent(); // 204 - Sucesso, sem conteúdo de retorno
        }

    }
}
