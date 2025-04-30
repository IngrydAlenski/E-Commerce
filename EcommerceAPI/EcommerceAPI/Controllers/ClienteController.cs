using EcommerceAPI.Context;
using EcommerceAPI.DTO;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;
using EcommerceAPI.Repositories;
using EcommerceAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository ClienteRepository;

        //Instanciar o PasswordService
       

        public ClienteController(IClienteRepository clienteRepository)
        {
            ClienteRepository = clienteRepository;
        }

        [HttpGet]
        [Authorize]
        public IActionResult ListarTodos()
        {
            return Ok(ClienteRepository.ListarTodos());

        }

        [HttpPost]
        public IActionResult CadastrarCliente(CadastrarClienteDTO cliente)
        {
            ClienteRepository.Cadastrar(cliente);
            return Created();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarClientePorId(int id)
        {
            var cliente = ClienteRepository.BuscarPorId(id);

            if (cliente == null)
                return NotFound(); // Retorna 404 se não encontrar o produto

            return Ok(cliente); // Retorna 200 com os dados do produto
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCliente(int id)
        {
            var clienteBuscado = ClienteRepository.BuscarPorId(id);

            if (clienteBuscado == null)
                return NotFound(); // 404 se não existir

            ClienteRepository.Deletar(id);

            return NoContent(); // 204 - Sucesso na exclusão
        }
        [HttpPut("{id}")]
        public IActionResult AtualizarCliente(int id, CadastrarClienteDTO cliente)
        {
            var clienteBuscado = ClienteRepository.BuscarPorId(id);

            if (clienteBuscado == null)
                return NotFound(); // 404 se não existir

            ClienteRepository.Atualizar(id, cliente);

            return NoContent(); // 204 - Sucesso, sem conteúdo de retorno
        }


        [HttpPost("Login")]
        public IActionResult Login(LoginDTO login)
        {
            var cliente = ClienteRepository.BuscarPorEmailSenha(login.Senha, login.Email);

            if (cliente == null)
            {
                return Unauthorized("Email ou Senha invalidos!");
            }                


            var tokenService = new TokenService();
            var token = tokenService.GenerateToken(cliente.Email);


            return Ok(token);
        }
        [HttpGet("/buscar/{Nome}")]

        public IActionResult BuscarPorNome(string nome)
        {
            return Ok(ClienteRepository.BuscarClientePorNome(nome));

        }
    }
}
