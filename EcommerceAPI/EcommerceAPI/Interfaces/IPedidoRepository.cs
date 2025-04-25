using EcommerceAPI.DTO;
using EcommerceAPI.Models;

namespace EcommerceAPI.Interfaces
{
    public interface IPedidoRepository
    {
        List<Pedido> ListarTodos();
        Pedido BuscarPorId(int id);
        void Cadastrar(CadastrarPedidoDTO pedido);
        void Atualizar(int id, Pedido pedido);
        void Deletar(int id);
    }
}
