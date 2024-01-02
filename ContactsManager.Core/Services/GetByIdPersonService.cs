using System;
using ContactsManager.Core.ServiceContracts;
using ContactsManager.Core.DTO;
using ContactsManager.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using ContactsManager.Core.Enums;
using ContactsManager.Core.RepoContracts;

namespace Services
{
    public class GetByIdPersonService : IPersonGetByIdService
    {
        private readonly IPersonRepo _personRepo;
        
        private ICountryService countryService;

        public GetByIdPersonService(IPersonRepo pr,ICountryService cs)
        {
            this._personRepo = pr;
            countryService =cs;
        }


        public async Task<PersonResponse?> GetPersonByPersonId(Guid PId)
        {
            if (PId == Guid.Empty)
            return null;

            return (await _personRepo.GetPersonById(PId))?.ToResponse();
        }

    }
}
