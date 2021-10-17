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
				{ "", $"[⚠] Report the developer: Reponse need to be configured (cod:0)." + moreInformation },
				{ "0", $"[⚠] Report the developer: Reponse need to be configured (cod:0)." + moreInformation },
				{ "00", $"[✔] Succes!" + moreInformation },
				{ "99", $"[❌] Error!" + moreInformation },
				{ "001", $"[⚠] Object is not of expected type." + moreInformation },
				{ "002", $"[⚠] Validation rule have error." + moreInformation },
				{ "003", $"[✔] Item created in database!" + moreInformation },
				{ "004", $"[⚠] This is not a new item. Try to edit it instead." + moreInformation },
				{ "005", $"[⚠] A field has the content not allowed." + moreInformation },
				{ "006", $"[]" },
				{ "007", $"[]" },
				{ "008", $"[]" },
				{ "009", $"[]" },
				{ "999", $"Unexpected error occurred." }
			};
		}
		private string getDefaultMessages(string? req = null)
		{
			var result = "";
			if (req != null)
			{
				try
				{
					result = DefaultMessages[req ?? "0"];

				}
				catch (Exception)
				{

					result = "[🔔]" + req;
				}
			}
			else
			{
				result = DefaultMessages["0"];
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
			public string? ReferenceMessage { get; internal set; } = "";
			public Object? ReferenceObject { get; internal set; } = null;
		}

		public Response ReturnSuccess(string message = null, string reference = "", Object obj = null)
		{
			return new Response
			{
				ResponseStatus = ResponseStatus.Ok,
				ResponseMessage = getDefaultMessages(message) ?? getDefaultMessages("0"),
				ReferenceMessage = reference,
				ReferenceObject = obj
			};
		}

		public Response ReturnError(string message = null, string reference = "", Object obj = null)
		{
			return new Response
			{
				ResponseStatus = ResponseStatus.Error,
				ResponseMessage = getDefaultMessages(message) ?? getDefaultMessages("99"),
				ReferenceMessage = reference,
				ReferenceObject = obj
			};
		}
	}
}
