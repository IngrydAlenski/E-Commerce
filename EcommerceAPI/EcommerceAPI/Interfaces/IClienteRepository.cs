using System.Security.Cryptography;
using EcommerceAPI.DTO;
using EcommerceAPI.Models;
using EcommerceAPI.ViewModels;

namespace EcommerceAPI.Interfaces
{
    public interface IClienteRepository
    {
        List<ListarClienteViewModel> ListarTodos();
        Cliente BuscarPorId(int id);
        Cliente BuscarPorEmailSenha(string senha, string E_mail);
        void Cadastrar(CadastrarClienteDTO cliente);
        void Atualizar(int id, CadastrarClienteDTO cliente);
        void Deletar(int id);
        List<Cliente> BuscarClientePorNome(string nome);

    }
}
