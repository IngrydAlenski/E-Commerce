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
    public class ProdutoController : ControllerBase
    {
        private readonly EcommerceContext _context;

        private IProdutoRepository produtoRepository;

        public ProdutoController(EcommerceContext context)
        {
            _context = context;
            produtoRepository = new ProdutoRepository(_context);
        }

        // GET 
        [HttpGet]
        public IActionResult ListarProdutos()
        {
            return Ok(produtoRepository.ListarTodos());
        }


        // Cadastrar produto
        [HttpPost]
                                             // "PROD" esse nome poder ser qualquer um
        public IActionResult CadastrarProduto(Produto prod)
        {
            //1 Coloco o produto no banco de dados
            produtoRepository.Cadastrar(prod);

            //2 Salvo a alteracao
            _context.SaveChanges();

            //3 201 - created
            return Ok();

        }

    }
    
}
