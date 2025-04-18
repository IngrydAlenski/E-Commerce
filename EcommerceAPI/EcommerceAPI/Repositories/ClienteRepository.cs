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
            Cliente clienteencontrado = _context.Clientes
                .FirstOrDefault(x => x.IdCliente == id);  // Busca o produto pelo ID

            if (cliente != null)  // Verifica se o produto foi encontrado
            {
                clienteencontrado.NomeCompleto = cliente.NomeCompleto;  // Atualiza as propriedades
               

                _context.SaveChanges();  // Persiste as alterações no banco
            }
        }
     

        public Cliente BuscarPorE_mailSenha(string senha, string E_mail)
        {
            throw new NotImplementedException();
        }

        public Cliente BuscarPorId(int id)
        {
            return _context.Clientes.FirstOrDefault(p => p.IdCliente == id);
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Cliente clientebuscado = _context.Clientes.Find(id);

            if (clientebuscado != null)
            {
                _context.Clientes.Remove(clientebuscado);
                _context.SaveChanges();
            }
        }
        public List<Cliente> ListarTodos()
        {
            return _context.Clientes.ToList();
        }
    }
}
