using EcommerceAPI.Context;
using EcommerceAPI.DTO;
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
        public IActionResult CadastrarProduto(CadastrarProtudoDTO prod)
        {
            //1 Coloco o produto no banco de dados
            ProdutoRepository.Cadastrar(prod);

            //3 201 - created
            return Ok();

        }
        [HttpGet("{id}")]
        public IActionResult BuscarProdutoPorId(int id)
        {
            var produto = ProdutoRepository.BuscarPorId(id);

            if (produto == null)
                return NotFound(); // Retorna 404 se não encontrar o produto

            return Ok(produto); // Retorna 200 com os dados do produto
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarProduto(int id)
        {
            var produtoBuscado = ProdutoRepository.BuscarPorId(id);

            if (produtoBuscado == null)
                return NotFound(); // 404 se não existir

            ProdutoRepository.Deletar(id);

            return NoContent(); // 204 - Sucesso na exclusão
        }
        [HttpPut("{id}")]
        public IActionResult AtualizarProduto(int id, CadastrarProtudoDTO prod)
        {
            var produtoBuscado = ProdutoRepository.BuscarPorId(id);

            if (produtoBuscado == null)
                return NotFound(); // 404 se não existir

            ProdutoRepository.Atualizar(id, prod);

            return NoContent(); // 204 - Sucesso, sem conteúdo de retorno
        }
       
    }
    
}
