using System.Security.Cryptography;
using EcommerceAPI.Models;

namespace EcommerceAPI.Interfaces
{
    public interface IClienteRepository
    {
        List<Cliente> ListarTodos();
        Cliente BuscarPorId(int id);
        Cliente BuscarPorE_mailSenha(string senha, string E_mail);
        void Cadastrar(Cliente cliente);

        void Atualizar(int id, Cliente cliente);

        void Deletar(int id);
    }
}
