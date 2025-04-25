using System.Runtime.Serialization.Formatters;
using EcommerceAPI.Context;
using EcommerceAPI.DTO;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;

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

        public void CadastrarPedido(CadastrarPedidoDTO pedido)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
