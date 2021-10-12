using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllModels.Models.Util
{
	public class Responses
	{
		public Responses()
		{
			string moreInformation = " See reference for more information.";
			DefaultMessages = new SortedDictionary<string, string>()
			{ 
				{ "0", $"Report the developer: Reponse need to be configured (cod:000)." + moreInformation},
			    { "00", $"Succes" + moreInformation},
				{ "99", $"Error" + moreInformation},
				{ "001", $"Object is not of expected type." + moreInformation},
				{ "002", $"Validation rule have error." + moreInformation},
				{ "003", $"Item created in database!" + moreInformation },
				{ "004", $"" },
				{ "005", $"" },
				{ "006", $"" },
				{ "007", $"" },
				{ "008", $"" },
				{ "009", $"" },
				{ "999", $"Unexpected error occurred." }
			};
		}
		public string getDefaultMessages(string? req = null)
		{
			var result = "";
			if (req != null)
			{
				result = DefaultMessages[req ?? "0"];
			}
			else
			{
				result = DefaultMessages["0"] ?? "?";
			}
			return result;
		}
		private SortedDictionary<string, string> DefaultMessages { get; set; }

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

		public Response ReturnSuccess(string message = null, string reference = "")
		{
			return new Response
			{
				ResponseStatus = ResponseStatus.Ok,
				ResponseMessage = message ?? getDefaultMessages("1"),
				Reference = reference
			};
		}

		public Response ReturnError(string message = null, string reference = "")
		{
			return new Response
			{
				ResponseStatus = ResponseStatus.Error,
				ResponseMessage = message ?? getDefaultMessages("99"),
				Reference = reference
			};
		}
	}
}
