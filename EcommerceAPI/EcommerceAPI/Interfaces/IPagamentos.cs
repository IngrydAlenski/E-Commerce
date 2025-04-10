using EcommerceAPI.Models;

namespace EcommerceAPI.Interfaces
{
    public interface IPagamentos
    {
        List<Pagamento> ListarTodos();
        Pagamento BuscarPorId(int id);

        void Cadastrar(Pagamento pagamento);

        void Atualizar(int id, Pagamento pagamento);

        void Deletar(int id);
    }
}
