using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;

namespace EcommerceAPI.Repositories
{
    public class PagamentoRepository
    {
        public class PagamentoRepository : IPagamentoRepository


           //Injetar context



        {
            public void Atualizar(int id, Pagamento pagamento)
            {
                throw new NotImplementedException();
            }

            public Pagamento BuscarPorId(int id)
            {
                throw new NotImplementedException();
            }

            public void Cadastrar(Pagamento pagamento)
            {
                throw new NotImplementedException();
            }

            public void Deletar(int id)
            {
                throw new NotImplementedException();
            }

            public List<Pagamento> ListarTodos()
            {
                throw new NotImplementedException();
            }
        }
    }
}
