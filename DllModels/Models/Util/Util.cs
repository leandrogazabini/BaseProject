using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllModels.Models.Util
{
	public class Responses
	{
		public enum ResponseStatus
		{
			Ok = 00,
			Error = 99,
		}

		public class Response
		{
			public ResponseStatus ResponseStatus { get; internal set; }
			public string? ResponseMessage { get; internal set; } = "";
			public string? Reference { get; internal set; } = "";
		}

		public Response Success(string message = "", string reference = "")
		{
			return new Response{ ResponseStatus = ResponseStatus.Ok };
		}

		public Response Error(string message = "", string reference = "")
		{
			return new Response { ResponseStatus = ResponseStatus.Error };
		}
	}
}
