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
        private IProdutoRepository ProdutoRepository;

        //Injeção de dependencia
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            ProdutoRepository = produtoRepository;
        }

        // GET 
        [HttpGet]
        public IActionResult ListarProdutos()
        {
            return Ok(ProdutoRepository.ListarTodos());
        }


        // Cadastrar produto
        [HttpPost]
                                             // "PROD" esse nome poder ser qualquer um
        public IActionResult CadastrarProduto(Produto prod)
        {
            //1 Coloco o produto no banco de dados
            ProdutoRepository.Cadastrar(prod);

            //3 201 - created
            return Ok();

        }

    }
    
}
