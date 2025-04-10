using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly EcommerceContext _context;

        private IProdutoRepository produtoRepository;

        public ProdutoController(EcommerceContext context)
        {
            _context = context;
            produtoRepository  = new ProdutoRepository(_context);
        }

        // GET 
        [HttpGet]
        public IActionResult ListarProdutos()
        {
            return Ok(produtoRepository.ListarTodos());
        }
    }
}
