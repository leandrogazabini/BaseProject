using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ViewModels

{	[Display(Name = "Person")]
	public class PersonViewModel
	{
		public string Name { get; set; }
	}
}
