using System;
using System.Collections.Generic;
using System.Text;
using TenantsAssociation.ApplicationLogic.Abstractions;
using TenantsAssociation.ApplicationLogic.DataModel;
using TenantsAssociation.ApplicationLogic.Exceptions;

namespace TenantsAssociation.ApplicationLogic.Services
{
    public class AdministratorService
    {
        private readonly IAdministratorRepository administratorRepository;
        private ITokenCreator tokenCreator;
        public AdministratorService(IAdministratorRepository administratorRepository, ITokenCreator tokenCreator)
        {
            this.administratorRepository = administratorRepository;
            this.tokenCreator = tokenCreator;
        }
    }
}
