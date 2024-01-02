using ContactsManager.Core.Domain.Entities;
using ContactsManager.Core.Domain.RepoContracts;
using ContactsManager.Core.DTO;
using ContractManager.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Infrastructure.Repos
{
    public class CountryRepo:ICountryRepo
    {
        private readonly DBDemoDbContext _demoDbContext;

        public CountryRepo(DBDemoDbContext demoDbContext)
        {
            _demoDbContext = demoDbContext;
        }

        public async Task<TheCountryResponse> AddCountry(Country country)
        {
            _demoDbContext.Countries.Add(country);
            await _demoDbContext.SaveChangesAsync();
            return country.ToResponse();
        }

        public async Task DeleteCountry(Guid Id)
        {
            Country country = _demoDbContext.Countries.FirstOrDefault(temp => temp.Id == Id);
            if (country == null)
            {
                throw new Exception("Country not found");
            }
            _demoDbContext.Countries.Remove(country);
            await _demoDbContext.SaveChangesAsync();

        }

        public async Task<List<TheCountryResponse>> GetAll()
        {
            return await _demoDbContext.Countries.Select(temp => temp.ToResponse()).ToListAsync();
        }

        public async Task<TheCountryResponse?> GetCountryById(Guid? Id)
        {
            if (Id == null)
            {
                return null;
            }
            if (_demoDbContext.Countries == null)
                return null;

            return (await _demoDbContext.Countries.FirstOrDefaultAsync(temp => temp.Id == Id)).ToResponse();
        }
    }
}
