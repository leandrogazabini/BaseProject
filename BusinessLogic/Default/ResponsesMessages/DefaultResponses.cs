using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using CommonSettings;

namespace BusinessLogic.Default.ResponsesMessages
{
	public class DefaultResponses
	{
		private readonly CultureInfo actualCulture;
		public DefaultResponses()
		{
			actualCulture = Settings.ActualCultureInfo;
		}
		//private string getMessagesFromResource(string? req = null, CultureInfo culture = null)
		//{
		//	//culture = culture ?? actualCulture;
		//	var result = "";
		//	try
		//	{
		//		if (req != null)
		//		{
		//			result = Messages.ResourceManager.GetString(req, culture);
		//		}
		//		else
		//		{
		//			result = Messages.ResourceManager.GetString("undefined", culture);
		//		}
		//	}
		//	catch (Exception)
		//	{
		//		result = Messages.UnexpectedError;
		//	}
		//	return result;
		//}

		public class Response
		{
			public bool Status { get; internal set; }
			public string? Message { get; internal set; } = "";
			public string? Reference { get; internal set; } = "";
			public Object? ReferenceObject { get; internal set; } = null;
			public void SetReferenceObject<objType>(object objRef)
			{
				this.ReferenceObject = (objType)objRef;
			}
		}

		public Response ReturnSuccess(string message = null, string reference = "", Object obj = null)
		{
			return new Response
			{
				Status = true,
				Message = message ?? Messages.Success,
				Reference = reference,
				ReferenceObject = obj,
			};
		}

		public Response ReturnError(string message = null, string reference = "", Object obj = null)
		{
			return new Response
			{
				Status = false,
				Message = message ?? Messages.Error,
				Reference = reference,
				ReferenceObject = obj
			};
		}
		//public Response ReturnSuccess(string message = null, string reference = "", Object obj = null)
		//{
		//	return new Response
		//	{
		//		Status = true,
		//		Message = getMessagesFromResource(message) ?? getMessagesFromResource("Success"),
		//		Reference = reference,
		//		ReferenceObject = obj,
		//	};
		//}

		//public Response ReturnError(string message = null, string reference = "", Object obj = null)
		//{
		//	return new Response
		//	{
		//		Status = false,
		//		Message = getMessagesFromResource(message) ?? getMessagesFromResource("Error"),
		//		Reference = reference,
		//		ReferenceObject = obj
		//	};
		//}
	}
}
