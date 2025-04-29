using AutoMapper;
using BLL.DTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AutoMapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Drivers, DriversDTO>();

			CreateMap<DriversDTO, Drivers>();


            CreateMap<Managers, ManagersDTO>();
            CreateMap<ManagersDTO, Managers>();

			CreateMap<RouteDto, Route>();
			CreateMap<Route, RouteDto>();

            CreateMap<Companies, CompaniesDTO>();
            CreateMap<CompaniesDTO, Companies>();

            CreateMap<Payment, PaymentDTO>();
            CreateMap<PaymentDTO, Payment>();
        }
	}
}
