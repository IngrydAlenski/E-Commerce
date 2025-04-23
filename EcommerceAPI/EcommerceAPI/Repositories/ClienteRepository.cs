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

        public void Atualizar(int id, Cliente clientenovo) // Implementa
        {
            // Acho o cliente que desejo
            var clienteEncontrado = _context.Clientes.FirstOrDefault(c => c.IdCliente == id);

            if (clienteEncontrado == null)
            {
                throw new ArgumentException("Cliente não encontrado");
            }

            // Campo a campo alterado 
            clienteEncontrado.NomeCompleto = clientenovo.NomeCompleto;
            clienteEncontrado.Email = clientenovo.Email;
            clienteEncontrado.Telefone = clientenovo.Telefone;
            clienteEncontrado.Endereco = clientenovo.Endereco;
            clienteEncontrado.Senha = clientenovo.Senha;
            clienteEncontrado.DataCadastro = clientenovo.DataCadastro;

            _context.SaveChanges();
        }
        public Cliente? BuscarPorEmailSenha(string senha, string E_mail)
        {
            //Encontrar o cliente que possui o email e senha fornecidos 

            Cliente? clienteEncontrado = _context.Clientes.FirstOrDefault(c => c.Email == E_mail && c.senha);
            return clienteEncontrado;
        }

        public Cliente BuscarPorId(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.IdCliente == id);
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Cliente clientebuscado = _context.Clientes.Find(id);

            if (clientebuscado == null)
            {
                throw new ArgumentNullException("Cliente não encontrado");
            }
            _context.Clientes.Remove(clientebuscado);
            _context.SaveChanges();
        }
        public List<Cliente> ListarTodos()
        {
            return _context.Clientes.ToList();
        }
    }
}
