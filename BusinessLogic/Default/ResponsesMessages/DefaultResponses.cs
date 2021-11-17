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
		public DefaultResponses()
		{
		}


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
	}
}
