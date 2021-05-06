using System;
using System.Collections.Generic;
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
    [Route("/api/counterparty")]
    public class CounterpartyController : ControllerBase
    {
        private readonly ICounterpartyService _counterpartyService;
        private readonly IMapper _mapper;

        public CounterpartyController(ICounterpartyService counterpartyService, IMapper mapper)
        {
            _counterpartyService = counterpartyService;
            _mapper = mapper;
        }

        /// <summary>
        /// Создает нового контрагента
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Созданного контрагента</returns>
        /// <response code="201">Контрагент успешно создан</response>
        /// <response code="400">Контрагент не создан, ошибки валидации данных</response>
        [HttpPost]
        [ProducesResponseType(typeof(CounterpartyToReturn), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromForm] CreateCounterpartyDto dto)
        {
            try
            {
                var counterparty = await _counterpartyService.Create(dto);
                return Created("Created", _mapper.Map<Counterparty, CounterpartyToReturn>(counterparty));
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(StatusCodes.Status400BadRequest, e.Message));
            }
        }

        /// <summary>
        /// Получает всех контрагентов
        /// </summary>
        /// <returns>Всех контрагентов</returns>
        /// <response code="200">Ok</response>
        [HttpGet("all")]
        [ProducesResponseType(typeof(ICollection<CounterpartyToReturn>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Index()
        {
            var counterparty = await _counterpartyService.GetAll();
            return Ok(_mapper.Map<ICollection<Counterparty>, ICollection<CounterpartyToReturn>>(counterparty));
        }

        /// <summary>
        /// Обновляет данные о контактах и местоположении контрагента
        /// </summary>
        /// <returns>Обновленного контрагента</returns>
        /// <response code="202">Accepted</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Контрагент не найден</response>
        [HttpPatch("contacts")]
        [ProducesResponseType(typeof(CounterpartyToReturn), StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddContacts([FromForm] CounterpartyContactsCreateDto dto)
        {
            try
            {
                var counterparty = await _counterpartyService.UpdateContacts(dto);
                return Accepted(_mapper.Map<Counterparty, CounterpartyToReturn>(counterparty));
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

        /// <summary>
        /// Ищет контрагента по ИНН
        /// </summary>
        /// <param name="tin"></param>
        /// <returns>Контрагента</returns>
        ///<response code="200">Ok</response>
        /// <response code="404">Контрагент не найден</response>
        [HttpGet("{tin:long}")]
        [ProducesResponseType(typeof(CounterpartyToReturn), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status404NotFound)]
        public IActionResult Get(long tin)
        {
            try
            {
                var counterparty = _counterpartyService.GetById(tin);
                return Ok(_mapper.Map<Counterparty, CounterpartyToReturn>(counterparty));
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