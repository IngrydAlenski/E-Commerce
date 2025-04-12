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

        private readonly EcommerceContext _context;

        private IClienteRepository clienteRepository;

        public ClienteController(EcommerceContext context)
        {
            _context = context;
            clienteRepository = new ClienteRepository(_context);
        }

        [HttpGet]

        public IActionResult ListarTodos()
        {
            return Ok(clienteRepository.ListarTodos());

        }
    }
}
