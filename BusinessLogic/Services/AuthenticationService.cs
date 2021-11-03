using BusinessLogic.BLLs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
	public class AuthenticationService
	{
		public AuthenticationService()
		{ }
		public dynamic Authenticate(string usr, string pwd, int interval = 10)
		{

			// Recupera o usuário
			var user = new User() { Username = "username", Password = "password", Role = "adm" }; /*UserRepository.Get(model.Username, model.Password);*/

			// Verifica se o usuário existe
			if (user == null)
				return new { message = "Usuário ou senha inválidos" };

			// Gera o Token
			var token = TokenService.GenerateToken(user, interval:interval);

			// Oculta a senha
			user.Password = "";

			// Retorna os dados
			return new
			{
				token = token
			};
		}
	}
}

