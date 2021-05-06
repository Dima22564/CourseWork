using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Data.Abstractions;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Creation;
using ERP.Services.DTO.Return;
using ERP.Services.Exceptions;
using ERP.Services.Services.Abstractions;
using ERP.WebApi.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.WebApi.Controllers
{
    [ApiController]
    [Route("/api/country")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountryController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        /// <summary>
        /// Создает новую страну
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Созданную страну</returns>
        /// <response code="201">Страна успешно создана</response>
        /// <response code="400">Страна не создана, ошибки валидации данных</response>
        [HttpPost]
        [ProducesResponseType(typeof(CountryToReturn), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromForm] CreateCountryDto dto)
        {
            try
            {
                var country = await _countryService.Create(dto);
                return Created("Ok", _mapper.Map<Country, CountryToReturn>(country));
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(StatusCodes.Status400BadRequest, e.Message));
            }
        }

        /// <summary>
        /// Возвращает все зарегистрированные страны
        /// </summary>
        /// <returns>Все зарегистрированные страны</returns>
        /// <response code="200">Ok</response>
        [HttpGet("all")]
        [ProducesResponseType(typeof(ICollection<CountryToReturn>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _countryService.GetAll();
            return Ok(_mapper.Map<ICollection<Country>, ICollection<CountryToReturn>>(countries));
        }

        /// <summary>
        /// Обновляет данные страны по ее номеру, кроме поля code
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Обновленную страну</returns>
        /// <response code="200">Страна успешно обновлена</response>
        /// <response code="400">Страна не обновлена, ошибки валидации данных</response>
        /// <response code="404">Страна не найдена</response>
        [HttpPatch]
        [ProducesResponseType(typeof(CountryToReturn), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromForm] CreateCountryDto dto)
        {
            try
            {
                var updated = await _countryService.UpdateByCode(dto);
                return Ok(new ApiResponse(StatusCodes.Status200OK, "Created", _mapper.Map<Country, CountryToReturn>(updated)));
            }
            catch (ModelNotFoundException e)
            {
                return NotFound(new ApiException(StatusCodes.Status404NotFound, e.Message));
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(StatusCodes.Status400BadRequest, e.Message));
            }
        }
    }
}