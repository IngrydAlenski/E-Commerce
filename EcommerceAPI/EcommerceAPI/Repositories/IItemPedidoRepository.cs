using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;

namespace EcommerceAPI.Repositories
{
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        private readonly EcommerceContext _context;

        // METODO COSTRUTOR
        //QUANDO CRIAR UM OBJETO O QUE EU PRECISO TER?
        public ItemPedidoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, ItemPedido itempedido)
        {
            var pedidoEncontrado = _context.ItemPedidos.FirstOrDefault(c => c.  IdItemPedido == id);

            if (pedidoEncontrado == null)
            {
                throw new ArgumentException(" Item Pedido não encontrado");
            }

            pedidoEncontrado.Quantidade = itempedido.Quantidade;
            pedidoEncontrado.IdPedido = itempedido.IdPedido;
            pedidoEncontrado.IdProduto = itempedido.IdProduto;
            
            _context.SaveChanges();
        }

        public ItemPedido BuscarPorId(int id)
        {
            return _context.ItemPedidos.FirstOrDefault(p => p.IdPedido == id);
        }

        public void Cadastrar(ItemPedido itemPedido)
        {
            ItemPedido pedidocadastro = new ItemPedido
            {
                IdItemPedido = itemPedido.IdItemPedido,

            };

            _context.ItemPedidos.Add(pedidocadastro);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Pedido pedidobuscado = _context.Pedidos.Find(id);

            if (pedidobuscado == null)
            {
                throw new ArgumentNullException(" Item do pedido não encontrado");
            }
            _context.Pedidos.Remove(pedidobuscado);
            _context.SaveChanges();
        }

        public List<ItemPedido> ListarTodos()
        {
            return _context.ItemPedidos.ToList();
        }
    }
}
