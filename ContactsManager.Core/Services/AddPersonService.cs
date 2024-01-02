using System;
using ContactsManager.Core.ServiceContracts;
using ContactsManager.Core.DTO;
using ContactsManager.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using ContactsManager.Core.Enums;
using ContactsManager.Core.RepoContracts;

namespace Services
{
    public class AddPersonService : IPersonAddService
    {
        private readonly IPersonRepo _personrepo;
        
        private ICountryService countryService;

        public AddPersonService(IPersonRepo db,ICountryService cs)
        {
            this._personrepo = db;
            countryService =cs;
        }

        public async Task<PersonResponse> AddPerson(PersonAddRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            ValidationHelper.Validate(request);


            if (await _personrepo.GetPersonByEmail(request.Email) != null)
            {
                throw new ArgumentException("Email already exists");
            }
            Person person = request.ToPerson();
           


                await _personrepo.AddPerson(person);
            
            PersonResponse peopleResponse = person.ToResponse();
           
            
                return peopleResponse;
                    
        }

        
    }
}
