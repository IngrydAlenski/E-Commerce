using EcommerceAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace EcommerceAPI.Services
{
    public class PasswordServices
    {
        //  PasswordHasher - PBKDF2
        private readonly PasswordHasher<Cliente> _hasher = new();

        // 1- Gerar um hash
        public string HashPassword(Cliente cliente)
        {
            return _hasher.HashPassword(cliente, cliente.Senha);
        }

        // 2- Verificar o hash

        public bool VerificarSenha(Cliente cliente, string senhaInformada)
        {
            var resultado = _hasher.VerifyHashedPassword(cliente, cliente.Senha, senhaInformada);

            return resultado == PasswordVerificationResult.Success; 
        }
    }
}
