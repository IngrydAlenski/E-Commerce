using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {

        private readonly EcommerceContext _context;

        private IPagamentoRepository pagamentoRepository;

        public PagamentoController(EcommerceContext context)
        {
            _context = context;
            pagamentoRepository = new PagamentoRepository(_context);
        }

        [HttpGet]

        public IActionResult ListarTodos()
        {
            return Ok(pagamentoRepository.ListarTodos());
          
        }
    }
}
