using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using FluentValidation;
using Service.DTOs.Admin.Countries;
using Service.Helpers;
using Service.Services.Interfaces;
using Service.Services;

namespace Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableDataAnnotationsValidation = true;
            });

            services.AddScoped<IValidator<CountryCreateDto>, CountryCreateDtoValidator>();
            services.AddScoped<ICountryService, CountryService>();

            return services;
        }
    }
}
