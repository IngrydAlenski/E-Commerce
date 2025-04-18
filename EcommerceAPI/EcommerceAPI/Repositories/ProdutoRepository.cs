﻿using System.Collections.Concurrent;
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
            Produto produtoencontrado = _context.Produtos.Find(id);

            if (produtoencontrado == null)
            {
                throw new Exception();
            }
            produtoencontrado.NomeProduto=produto.NomeProduto;
            produtoencontrado.DescricaoProduto=produto.DescricaoProduto;
            produtoencontrado.Preco=produto.Preco;
            produtoencontrado.CategoriaProduto=produto.CategoriaProduto;
            produtoencontrado.ImagemProduto=produto.ImagemProduto;
            produtoencontrado.EstoqueDisponivel=produto.EstoqueDisponivel;

            _context.SaveChanges();
        }

        public Produto BuscarPorId(int id)
        {
          return _context.Produtos.FirstOrDefault(p => p.IdProduto == id);
        }

        public void Cadastrar(Produto produto)
        {
            _context.Produtos.Add(produto);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Produto produtoencontrado = _context.Produtos.Find(id);

            if (produtoencontrado == null)
            {
                throw new Exception();
            }

            _context.Produtos.Remove(produtoencontrado);

            _context.SaveChanges();
        }

        public List<Produto> ListarTodos()
        {
            return _context.Produtos.ToList();
        }
    }
}
