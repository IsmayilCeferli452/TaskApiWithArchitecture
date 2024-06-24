using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Countries;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class CountryService : ICountryService
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepo;
        private readonly IBaseRepository<Country> _baseRepo;

        public CountryService(IMapper mapper, 
                              ICountryRepository countryRepository,
                              IBaseRepository<Country> baseRepository)
        {
            _mapper = mapper;
            _countryRepo = countryRepository;
            _baseRepo = baseRepository;
        }
        public async Task CreateAsync(CountryCreateDto request)
        {
            if(request is null)
            {
                throw new ArgumentNullException();
            }
            await _countryRepo.CreateAsync(_mapper.Map<Country>(request));
        }

        public async Task DeleteAsync(Country request)
        {
            if (request is null)
            {
                throw new ArgumentNullException();
            }

            var country = await _baseRepo.GetByIdAsync(request.Id);

            if (country is null)
            {
                throw new ArgumentNullException();
            }

            await _baseRepo.DeleteAsync(country);
        }

        public async Task EditAsync(int id, CountryEditDto request)
        {
            var country = await _baseRepo.GetByIdAsync(id);

            if (country is null)
            {
                throw new ArgumentNullException();
            }

            _mapper.Map(request,country);

            country.Name = request.Name;

            await _baseRepo.EditAsync(country);
        }

        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CountryDto>>(await _countryRepo.GetAllAsync());
        }

        public Task<Country> GetById(int id)
        {
            return _baseRepo.GetByIdAsync(id);
        }
    }
}
