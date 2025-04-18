using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;

namespace EcommerceAPI.Repositories
{
    public class PedidoRepository :IPedidoRepository
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

        public void Cadastrar(Pedido pedido)
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
