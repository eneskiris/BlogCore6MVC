using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace JWT.DataAccess;

public class BuildToken
{
    public string CreateToken()
    {
        var bytes = Encoding.UTF8.GetBytes("superSecretKey@345");
        var key = new SymmetricSecurityKey(bytes);
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost",
                                         notBefore: DateTime.Now, expires: DateTime
                                                                          .Now.AddMinutes(30),
                                         signingCredentials: credentials);
        var handler = new JwtSecurityTokenHandler();
        return handler.WriteToken(token);
    }
}