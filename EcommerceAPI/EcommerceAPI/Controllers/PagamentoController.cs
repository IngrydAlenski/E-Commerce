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
        private IPagamentoRepository PagamentoRepository;

        public PagamentoController(IPagamentoRepository pagamentoRepository)
        {
              PagamentoRepository = pagamentoRepository;
        }

        [HttpGet]

        public IActionResult ListarTodos()
        {
            return Ok(PagamentoRepository.ListarTodos());
          
        }
    }
}
