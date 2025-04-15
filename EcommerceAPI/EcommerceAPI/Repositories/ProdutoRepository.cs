using System.Collections.Concurrent;
using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;

namespace EcommerceAPI.Repositories
{
    public class ProdutoRepository : IProdutoRepository

    {
        // METODOS QUE ACESSAM O BANCO DE DADOS

        // Injetar o Context 

        private readonly EcommerceContext _context;

        // METODO COSTRUTOR
        //QUANDO CRIAR UM OBJETO O QUE EU PRECISO TER?
        public ProdutoRepository(EcommerceContext context)
        {
            _context = context;  
        }
        public void Atualizar(int id, Produto produto)
        {
            throw new NotImplementedException();
        }

        public Produto BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Produto produto)
        {
            _context.Produtos.Add(produto);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Produto> ListarTodos()
        {
            return _context.Produtos.ToList();
        }
    }
}
