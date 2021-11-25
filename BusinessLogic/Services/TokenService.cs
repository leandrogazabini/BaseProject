using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.BLLs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System;

namespace BusinessLogic.Services
{
	public static class TokenService
	{
		public static Settings.LoggedUser GetDataFromToken(string token)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenRead = tokenHandler.ReadJwtToken(token);
			var data = tokenRead.Payload.Claims;
			var dataToReturn = new Settings.LoggedUser();

			//dataToReturn.Name = data.First(claim => claim.Type == "Unique_name").Value ?? "";
			//dataToReturn.Role = data.First(claim => claim.Type == "Role").Value ?? "";

			//xx dataToReturn.Name = "teste";
			//xx dataToReturn.Role = "teste 2";
			return dataToReturn;
		}
	//private readonly Settings Config {get;set; }
	public static string GenerateToken(User user, int interval)
	{
		var settings = new CommonSettings.Settings();
		var tokenHandler = new JwtSecurityTokenHandler();
		var key = Encoding.ASCII.GetBytes(settings._jwtSettings.GetJwtKey());
		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(new Claim[]
			{
					new Claim(ClaimTypes.Name, user.Username.ToString() ?? ""),
					new Claim(ClaimTypes.Role, user.Role.RoleName.ToString() ?? "")
			}),
			Expires = DateTime.UtcNow.AddMinutes(interval),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
		};
		var token = tokenHandler.CreateToken(tokenDescriptor);
		return tokenHandler.WriteToken(token);
	}
}
}
