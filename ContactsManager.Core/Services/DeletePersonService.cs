using System;
using ContactsManager.Core.ServiceContracts;
using ContactsManager.Core.DTO;
using ContactsManager.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using ContactsManager.Core.Enums;
using ContactsManager.Core.RepoContracts;
using Microsoft.Extensions.Logging;

namespace Services
{
    public class DeletePersonService : IPersonDeleteService
    {
        
        
        private ICountryService countryService;
        private readonly IPersonRepo _personRepo;
        private readonly ILogger<DeletePersonService> _logger;

        public DeletePersonService(ICountryService cs, ILogger<DeletePersonService> logger,IPersonRepo personRepo)
        {
            _logger = logger;
           
            countryService =cs;
            _personRepo =personRepo;
        }


        public async Task<bool> DeletePerson(Guid id)
        {
            _logger.LogInformation("DeletePerson method executing...");
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));    
            }

            Person person = await _personRepo.GetPersonById(id);
           
            if(person == null)
            {
                return false;
            }
            await _personRepo.DeletePerson(id);
            _logger.LogDebug($"{person.Name} deleted.");
            return true;

        }

    }
}
