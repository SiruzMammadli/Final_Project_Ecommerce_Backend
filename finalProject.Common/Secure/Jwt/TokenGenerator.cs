using finalProject.Entities.Concretes.Users;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace finalProject.Common.Secure.Jwt
{
    public static class TokenGenerator
    {
        public static string GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("_id", user.Id.ToString()),
                new Claim("firstName", user.FirstName),
                new Claim("lastName", user.LastName),
                new Claim("email", user.Email),
                new Claim("role", user.Role)
            };

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes("RANAUbe3TPYcBZoPqChkrD"));
            SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha512Signature);
            DateTime expiry = DateTime.UtcNow.AddDays(7);

            return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
                claims: claims,
                signingCredentials: creds,
                expires: expiry,
                issuer: "ecommerceApp",
                audience: "ecommerceApp"
                ));
        }
    }
}
