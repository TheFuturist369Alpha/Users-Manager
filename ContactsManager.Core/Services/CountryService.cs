using ContactsManager.Core.ServiceContracts;
using ContactsManager.Core.DTO;
using ContactsManager.Core.Domain.Entities;
using ContactsManager.Core.Domain.RepoContracts;

namespace Services
{
    public class CountryService : ICountryService
    {
   private readonly ICountryRepo _countryRepo;
        public CountryService(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;

            
   
        }
       
        public async Task<TheCountryResponse> AddCountry(CountryAddRequest request)
        {
            //Validation: request is null
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            //Validation: Country name is null
            if(request.CountryName == null)
            {
                throw new ArgumentException(nameof(request.CountryName));
            }
            //Validation: Duplicate country name
           return await _countryRepo.AddCountry(request.ToCountry());
        }

        public async Task<List<TheCountryResponse>> GetAllCountries()
        {
            return await _countryRepo.GetAll();
        }

        public async Task<TheCountryResponse?> GetCountryById(Guid? Id)
        {
            /*if (Id == null)
            {
                return null;
            }

            if (_db.Countries == null)
            {
                return null;
            }*/
            return await _countryRepo.GetCountryById(Id);
        }
    }
}