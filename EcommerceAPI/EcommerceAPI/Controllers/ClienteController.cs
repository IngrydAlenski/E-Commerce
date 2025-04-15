using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
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
    }
}
