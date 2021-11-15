using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using CommonSettings;

namespace DllModels.Models.Default.ValidationMessages
{
	public class DefaultMessages
	{
		private readonly CultureInfo actualCulture;
		public DefaultMessages()
		{
			actualCulture = Settings.CultureSettings.ActualCultureInfo;
		}
		private string getMessagesFromResource(string? req = null, CultureInfo culture = null)
		{
			//culture = culture ?? actualCulture;
			var result = "";
			try
			{
				if (req != null)
				{
					result = Default.ValidationMessages.Messages.ResourceManager.GetString(req, culture);
				}
				else
				{
					result = Default.ValidationMessages.Messages.ResourceManager.GetString(req, culture);
				}
			}
			catch (Exception)
			{
				result = Default.ValidationMessages.Messages.InvalidValue;
			}
			return result;
		}

		public class Response
		{
			public bool ResponseStatus { get; internal set; }
			public string? ResponseMessage { get; internal set; } = "";
			public string? ReferenceMessage { get; internal set; } = "";
			public Object? ReferenceObject { get; internal set; } = null;
			public void SetReferenceObject(object objRef)
			{
				this.ReferenceObject = objRef;
			}
		}

		public Response ReturnSuccess(string message = null, string reference = "", Object obj = null)
		{
			return new Response
			{
				ResponseStatus = true,
				ResponseMessage = getMessagesFromResource(message) ?? getMessagesFromResource("0"),
				ReferenceMessage = reference,
				ReferenceObject = obj
			};
		}

		public Response ReturnError(string message = null, string reference = "", Object obj = null)
		{
			return new Response
			{
				ResponseStatus = false,
				ResponseMessage = getMessagesFromResource(message) ?? getMessagesFromResource("99"),
				ReferenceMessage = reference,
				ReferenceObject = obj
			};
		}
	}
}
