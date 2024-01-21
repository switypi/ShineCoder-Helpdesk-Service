using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ShineCoder_Helpdesk.Core.Models;
using ShineCoder_Helpdesk.Infrastructure.Models;

namespace ShineCoder_Helpdesk.Core.Helpers
{
	public class MappingProfile:Profile
	{
        public MappingProfile()
        {
			CreateMap<CategoryModel,Category>().ForMember(x => x.Name, y => y.MapFrom(x => x.Name));
				
			CreateMap<Tickets, TicketsModel>();
            CreateMap<TicketsModel,Tickets>();
        }
    }
}
