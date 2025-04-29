using System.Runtime.Serialization.Formatters;
using EcommerceAPI.Context;
using EcommerceAPI.DTO;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly EcommerceContext _context;
        public PedidoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Pedido pedidonovo)
        {
            Pedido pedidoencontrado = _context.Pedidos.Find(id);

            if (pedidoencontrado == null)
            {
                throw new Exception();
            }
            pedidoencontrado.StatusPedido=pedidonovo.StatusPedido;
            pedidoencontrado.DataPedido=pedidonovo.DataPedido;
        }

        public Pedido BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(CadastrarPedidoDTO pedidoDTO)
        {
            //Cadastra pedido
            //Cria uma variavel pedido para guardar o que pedido tem
            var pedido = new Pedido
            {
             DataPedido = pedidoDTO.DataPedido,
             StatusPedido = pedidoDTO.StatusPedido,
             IdCliente = pedidoDTO.IdCliente,
             ValorTotal = pedidoDTO.ValorTotal
            };

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            //Cadastrar os itens pedido
            //Para cada produto eu crio um item pedido

            for (int i = 0; i < pedidoDTO.Produtos.Count; i++)
            {
                //Encontra um produto
                var produto = _context.Produtos.Find(pedidoDTO.Produtos[i]);



                //TODO: Lancar erro se produto nao existe



                //Cria uma variavel que guarda o item pedido, e me diz os item do pedido

                var itemPedido = new ItemPedido
                {
                    IdPedido = pedido.IdPedido,
                    IdProduto = produto.IdProduto,
                    Quantidade = 0

                };

                //Jogo no banco de dados
                _context.ItemPedidos.Add(itemPedido);
                //Salvo 
                _context.SaveChanges();
            }

        }

        public void CadastrarPedido(CadastrarPedidoDTO pedidoDTO)
        {
            var pedido = new Pedido
            {
                DataPedido = pedidoDTO.DataPedido,
                StatusPedido = pedidoDTO.StatusPedido,
                ValorTotal = pedidoDTO.ValorTotal,
                IdCliente = pedidoDTO.IdCliente,

            };
            

            _context.Pedidos.Add(pedido);

            _context.SaveChanges();

            for (int i = 0; i < pedidoDTO.Produtos.Count; i++)
            {
                var produto = _context.Produtos.Find(pedidoDTO.Produtos[i]);

                var itemPedido = new ItemPedido
                {
                    IdPedido = pedido.IdPedido,
                    IdProduto = pedidoDTO.Produtos[i],
                };

                _context.ItemPedidos.Add(itemPedido);

                _context.SaveChanges();
            }
        }
        public void Deletar(int id)
        {
            Pedido Pedidobuscado = _context.Pedidos.Find(id);

            if (Pedidobuscado == null)
            {
                throw new ArgumentNullException("Pedido não encontrado");
            }
            _context.Pedidos.Remove(Pedidobuscado);
            _context.SaveChanges();
        }

        public List<Pedido> ListarTodos()
        {
            return _context.Pedidos
                .Include(p => p.ItemPedidos)
                .ThenInclude(p => p.Produto).
                ToList();
        }
    }
}
