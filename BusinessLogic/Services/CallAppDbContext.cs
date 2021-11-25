using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllDatabase;

namespace BusinessLogic.Services
{
	public class CallAppDbContext : AppDbContext
	{
		public CallAppDbContext(string token) : base(Services.TokenService.GetDataFromToken(token))
		{
			
		}
		
	}
}
