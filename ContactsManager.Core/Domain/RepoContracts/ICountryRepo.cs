using ContactsManager.Core.Domain.Entities;
using ContactsManager.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ContactsManager.Core.Domain.RepoContracts
{
    public interface ICountryRepo
    {
        public Task<TheCountryResponse> AddCountry(Country country);
        public Task<TheCountryResponse?> GetCountryById(Guid? Id);
        public Task DeleteCountry(Guid Id);
        public Task<List<TheCountryResponse>> GetAll();
    }
}
