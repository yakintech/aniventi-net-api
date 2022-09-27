using Aniventi.Api.Models.Services.TokenServices;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Aniventi.Api.Models.TokenServices
{
    public class TokenHandler
    {


        public Token CreateAccessToken()
        {
            Token token = new Token();

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aEySwcUDaEySwcUD"));

            //token ın şifreleme algoritması
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            token.ExpirationDate = DateTime.Now.AddMinutes(5);

            //oluşturulacak token ın özellkler
            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: "cagatay.com",
                audience: "cagatay2.com",
                expires: token.ExpirationDate,
                signingCredentials: signingCredentials
                );


            //Token oluşturan sınıf
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            token.AccessToken = jwtSecurityTokenHandler.WriteToken(securityToken);

            return token;



        }

    }
}
