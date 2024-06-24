using Domain.Entities;
using Service.DTOs.Admin.Countries;

namespace Service.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAllAsync();
        Task CreateAsync(CountryCreateDto request);
        Task DeleteAsync(Country request);
        Task EditAsync(int id, CountryEditDto request);
        Task<Country> GetById(int id);
    }
}
