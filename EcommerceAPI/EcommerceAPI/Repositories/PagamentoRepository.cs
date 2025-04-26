using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private EcommerceContext _context;

        public PagamentoRepository(EcommerceContext context)
        {
            this._context = context;
        }
        
            public void Atualizar(int id, Pagamento pagamentoNovo)
            {
            Pagamento pagamentoencontrado = _context.Pagamentos.Find(id);

            if (pagamentoencontrado == null)
            {
                throw new Exception();
            }
            pagamentoencontrado.FormaPagamento = pagamentoNovo.FormaPagamento;
            pagamentoencontrado.DataPagamento = pagamentoNovo.DataPagamento;
            pagamentoencontrado.StatusPagamento = pagamentoNovo.StatusPagamento;
            pagamentoencontrado.IdPedido = pagamentoNovo.IdPedido;

            _context.SaveChanges();
        }

            public Pagamento BuscarPorId(int id)
            {

            return _context.Pagamentos.FirstOrDefault(p => p.IdPagamento == id);

            }

            public void Cadastrar(Pagamento pagamento)
            {
             
            _context.Pagamentos.Add(pagamento);
            _context.SaveChanges();
             }

            public void Deletar(int id)
            {
            Pagamento pagamentobuscado = _context.Pagamentos.Find(id);

            if (pagamentobuscado != null)
            {
                _context.Pagamentos.Remove(pagamentobuscado);
                _context.SaveChanges();
            }

            }
            public List<Pagamento> ListarTodos()
            {
                return _context.Pagamentos
              .Include(p => p.IdPedidoNavigation)
                .ToList();

            }
        }
    }

