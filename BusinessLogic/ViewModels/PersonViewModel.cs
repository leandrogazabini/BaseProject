using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ViewModels
{
	public class PersonViewModel
	{
		public string OfficialName { get; set; }
		public string GUID { get; set; }
		public string AlternativeName { get; set; }
		public string MainDocumentNumber { get; set; }
		public string SecondDocumentNumber { get; set; }
		public int PersonLegalKind { get; set; }
	}

	public class NewPersonViewModel
	{
		public string OfficialName { get; set; }
		public string AlternativeName { get; set; }
		public string MainDocumentNumber { get; set; }
		public string SecondDocumentNumber { get; set; }
		public int PersonLegalKind { get; set; }
	}
}
