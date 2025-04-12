using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;

namespace EcommerceAPI.Repositories

 // 1- Cria a classe Repositories
// 2- Herda da interface
// 3- Da um ctrl.e implementa
//Injetar Contexto
{
    public class ClienteRepository : IClienteRepository //Herda
    {
        //Injeta contexto
        private  readonly EcommerceContext _context;

        //Metodo costrutor e o metodo que tem o mesmo nome da classe
        //Argumento do construtor, e oque esta dentro dos parenteses 
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
            _context.Clientes.Add(cliente);
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ListarTodos()
        {
            return _context.Clientes.ToList();
        }
    }
}
