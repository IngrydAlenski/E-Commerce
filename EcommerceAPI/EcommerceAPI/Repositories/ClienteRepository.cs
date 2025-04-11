using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;

namespace EcommerceAPI.Repositories

 // 1- Cria a classe 
// 2- Herda da interface
// 3- Da um ctrl.e implementa
//Injetar Contexto
{
    public class ClienteRepository : IClienteRepository //Herda
    {
        //Injeta contexto
        private  readonly EcommerceContext _context;

        public ClienteRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Cliente cliente) // Implementa
        {
            throw new NotImplementedException();
        }

        public Cliente BuscarPorE_mailSenha(string senha, string E_mail)
        {
            throw new NotImplementedException();
        }

        public Cliente BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
