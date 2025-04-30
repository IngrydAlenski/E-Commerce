using EcommerceAPI.Context;
using EcommerceAPI.DTO;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;
using EcommerceAPI.Services;
using EcommerceAPI.ViewModels;

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

        public void Atualizar(int id, CadastrarClienteDTO clientenovo) // Implementa
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

        public List<Cliente> BuscarClientePorNome(string nome)
        {
            var ListaClientes = _context.Clientes.Where(c => c.NomeCompleto == nome).ToList();

            return ListaClientes;
        }

        public Cliente? BuscarPorEmailSenha(string senha, string E_mail)
        {
            //Encontrar o cliente que possui o email e senha fornecidos 

            Cliente? clienteEncontrado = _context.Clientes.FirstOrDefault(c => c.Email == E_mail);

            //Caso nao encontre retorne nulo
            if (clienteEncontrado == null)  
            return null;

            var passwordService = new PasswordServices();

            //Verificar se a senha e o mesmo hash
            var resultado = passwordService.VerificarSenha(clienteEncontrado, senha);

            if (resultado == true) return clienteEncontrado;
            return null;
        }

        public Cliente BuscarPorId(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.IdCliente == id);
        }
         public void Cadastrar(CadastrarClienteDTO cliente)
        {

            var passwordService = new PasswordServices();


            Cliente clientecadastro = new Cliente
            {
               NomeCompleto = cliente.NomeCompleto,
               Email = cliente.Email,
               Telefone = cliente.Telefone,
               Endereco = cliente.Endereco,
               DataCadastro = cliente.DataCadastro,                
               Senha = cliente.Senha
            };

            clientecadastro.Senha = passwordService.HashPassword(clientecadastro);


            _context.Clientes.Add(clientecadastro);

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
        public List<ListarClienteViewModel> ListarTodos()
        {
            return _context.Clientes
                //Permite que eu selecione quais campos eu quero pegar
                .Select(
                c => new ListarClienteViewModel
                {
                   IdCliente = c.IdCliente,
                   NomeCompleto = c.NomeCompleto,
                   Email = c.Email,
                   Telefone = c.Telefone,
                   Endereco = c.Endereco,
                   DataCadastro= c.DataCadastro

                })
                .ToList();
        }
    }
}
