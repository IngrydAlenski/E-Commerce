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

        [HttpPost]
        public IActionResult CadastrarProduto(Pagamento pagamento)
        {
           PagamentoRepository.Cadastrar(pagamento);

            return Created();
        }


        [HttpGet("{id}")]
        public IActionResult BuscarProdutoPorId(int id)
        {
            var produto = PagamentoRepository.BuscarPorId(id);

            if (produto == null)
                return NotFound(); // Retorna 404 se não encontrar o produto

            return Ok(produto); // Retorna 200 com os dados do produto
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarProduto(int id)
        {
            var produtoBuscado = PagamentoRepository.BuscarPorId(id);

            if (produtoBuscado == null)
                return NotFound(); // 404 se não existir

           PagamentoRepository.Deletar(id);

            return NoContent(); // 204 - Sucesso na exclusão
        }
        [HttpPut("{id}")]
        public IActionResult AtualizarProduto(int id, Pagamento pagamento)
        {
            var produtoBuscado = PagamentoRepository.BuscarPorId(id);

            if (produtoBuscado == null)
                return NotFound(); // 404 se não existir

            PagamentoRepository.Atualizar(id, pagamento);

            return NoContent(); // 204 - Sucesso, sem conteúdo de retorno
        }


    }
}
