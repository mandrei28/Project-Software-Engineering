using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TenantsAssociation.ApplicationLogic.DataModel;

namespace TenantsAssociation.ApplicationLogic.Services
{
    public class MappingEntity : Profile
    {
        public MappingEntity()
        {
            CreateMap<Administrator, User>();
            CreateMap<User, Administrator>();
        }
    }
}
