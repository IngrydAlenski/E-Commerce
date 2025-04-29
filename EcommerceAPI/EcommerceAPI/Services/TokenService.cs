using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace EcommerceAPI.Services
{
    public class TokenService
    {
        //Claims - Informações do usuario que eu quero guardar
        public string GenerateToken(string email)

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email)
            };

        //Criar uma chave de sguranca e cripitografar ela

        var chave = new SymmetricSecurityKey(Encoding.UTF8,GetBytes("Minha-chave-secreta-senai"));
    }
}
