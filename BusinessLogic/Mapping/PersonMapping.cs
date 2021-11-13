using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mapping
{
	public class PersonMapping
	{
		public readonly IMapper _mapper;
		public PersonMapping()
		{
			var configuration = new MapperConfiguration(cfg =>
			{
				//BLL <--VM
				cfg.CreateMap<ViewModels.NewPersonViewModel, BLLs.Person>()
				.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null))
				;

				//BLL <--VM
				cfg.CreateMap<ViewModels.PersonViewModel, BLLs.Person>()
				.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null))
				;

				//BLL -> VM
				cfg.CreateMap<BLLs.Person, ViewModels.PersonViewModel>()
				.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null))
				;

				//BLL -> DB
				cfg.CreateMap<BLLs.Person, DllDatabase.Models.Person>()
				.ForMember(p => p.Id, act => act.Ignore())
				.ForMember(p => p.Version, act => act.Ignore())
				.ForMember(p => p.GUID, act => act.Ignore())
				.ForMember(p => p.ChangedAt, act => act.Ignore())
				.ForMember(p => p.CreatedAt, act => act.Ignore())
				.ForMember(p => p.DeletedAt, act => act.Ignore())
				.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null))
				;

				//BLL <-- DB
				cfg.CreateMap<DllDatabase.Models.Person, BLLs.Person>()
				.ForMember(p => p.Id, act => act.Ignore())
				.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null))
				;
			});
			
			var mapper = configuration.CreateMapper();
			_mapper = mapper;
		}

	}
}
