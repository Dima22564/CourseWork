using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
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
    [Route("api/")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        private readonly IMapper _mapper;
        
        public CurrencyController(ICurrencyService currencyService, IMapper mapper)
        {
            _currencyService = currencyService;
            _mapper = mapper;
        }

        /// <summary>
        /// Возвращает все зарегистрированные валюты
        /// </summary>
        /// <returns>Все зарегистрированные валюты</returns>
        /// <response code="200">Ok</response>
        [HttpGet]
        [Route("currencies")]
        [ProducesResponseType(typeof(ICollection<CurrencyToReturn>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var currencies = await _currencyService.GetAll();
            return Ok(_mapper.Map<ICollection<Currency>, ICollection<CurrencyToReturn>>(currencies));
        }

        /// <summary>
        /// Создает новую валюту
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Созданную валюту</returns>
        /// <response code="201">Валюта создана</response>
        /// <response code="400">Валюта не создана, ошибки валидации данных</response>
        [HttpPost]
        [Route("currency/create")]
        [ProducesResponseType(typeof(CurrencyToReturn), 201)]
        [ProducesResponseType(typeof(ApiException), 400)]
        public async Task<IActionResult> Create([FromForm] CreateCurrencyDto dto)
        {
            try
            {
                var currency = await _currencyService.Create(dto);
                return Created("Ok", _mapper.Map<Currency, CurrencyToReturn>(currency));
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(StatusCodes.Status400BadRequest, e.Message));
            }
        }

        /// <summary>
        /// Обновляет данные валюты по ее номеру
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Обновленную валюту</returns>
        /// <response code="200">Валюта успешно обновлена</response>
        /// <response code="400">Валюта не обновлена, ошибки валидации данных</response>
        /// <response code="404">Валюта не найдена</response>
        [HttpPatch("currency")]
        [ProducesResponseType(typeof(CurrencyToReturn), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromForm] CreateCurrencyDto dto)
        {
            try
            {
                var updated = await _currencyService.ChangeByCode(dto);
                return Ok(new ApiResponse(StatusCodes.Status200OK, "Created", _mapper.Map<Currency, CurrencyToReturn>(updated)));
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