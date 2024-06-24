using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Countries;
using Service.Services.Interfaces;

namespace TaskApp.Controllers.Admin
{
    public class CountryController : BaseController
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var countries = await _countryService.GetAllAsync();

                if (countries.Count() < 0)
                {
                    throw new ArgumentNullException();
                }
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CountryCreateDto request)
        {
            try
            {
                await _countryService.CreateAsync(request);

                return CreatedAtAction(nameof(Create), new
                {
                    Response = "Data succesfully created"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int? id)
        {
            try
            {
                if (id is null)
                {
                    throw new ArgumentNullException();
                }

                var country = await _countryService.GetById((int)id);

                if (country is null)
                {
                    throw new ArgumentNullException();
                }

                return Ok(country);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            try
            {
                if (id is null)
                {
                    throw new ArgumentNullException();
                }
                var country = await _countryService.GetById((int)id);

                if (country is null)
                {
                    throw new ArgumentNullException();
                }

                await _countryService.DeleteAsync(country);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromQuery] int? id, [FromBody] CountryEditDto request)
        {
            try
            {
                if (id is null)
                {
                    throw new ArgumentNullException();
                }

                var country = await _countryService.GetById((int)id);

                if (country is null)
                {
                    throw new ArgumentNullException();
                }

                await _countryService.EditAsync((int)id,request);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
