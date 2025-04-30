using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace EcommerceAPI.Services
{
    public class TokenService
    {
        //Claims - Informações do usuario que eu quero guardar
        public string GenerateToken(string email)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email)
            };

        //Criar uma chave de sguranca e cripitografar ela

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Minha-chave-ultra-mega-secreta-senai"));

            //Cripitografando a chave de seguranca
            var creds = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            //Montar Token

            var token = new JwtSecurityToken
                (
                issuer: "Eccomerce",
                audience:"Eccomerce",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
