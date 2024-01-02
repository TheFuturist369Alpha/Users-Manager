using System;
using ContactsManager.Core.ServiceContracts;
using ContactsManager.Core.DTO;
using ContactsManager.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using ContactsManager.Core.Enums;
using ContactsManager.Core.RepoContracts;

namespace Services
{
    public class GetAllPersonService : IPersonGetAllService
    {
        public IPersonRepo _personrepo;
        
        private ICountryService countryService;

        public GetAllPersonService(IPersonRepo personrepo,ICountryService cs)
        {
            this._personrepo = personrepo;
            countryService =cs;
        }

       

        public async Task<List<PersonResponse>> GetPeople()
        {
            return  (await _personrepo.GetAllPersons()).Select(temp => temp.ToResponse()).ToList();
        }

       
    }
}
