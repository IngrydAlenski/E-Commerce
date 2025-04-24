using System.Security.Cryptography;
using EcommerceAPI.DTO;
using EcommerceAPI.Models;

namespace EcommerceAPI.Interfaces
{
    public interface IClienteRepository
    {
        List<Cliente> ListarTodos();
        Cliente BuscarPorId(int id);
        Cliente BuscarPorEmailSenha(string senha, string E_mail);
        void Cadastrar(CadastrarCliente cliente);

        void Atualizar(int id, CadastrarCliente cliente);

        void Deletar(int id);
        List<Cliente> BuscarClientePorNome(string nome);
    }
}
