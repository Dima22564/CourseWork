using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Adding;
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
    [Route("/api/partner")]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerService _partnerService;
        private readonly IMapper _mapper;

        public PartnerController(IMapper mapper, IPartnerService partnerService)
        {
            _mapper = mapper;
            _partnerService = partnerService;
        }

        /// <summary>
        /// Создает нового партнера
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Созданного партнера</returns>
        /// <response code="201">Партнер успешно создан</response>
        [HttpPost]
        [ProducesResponseType(typeof(PartnerToReturnDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromForm] PartnerCreateDto dto)
        {
            var newPartner = await _partnerService.Create(dto);

            return Created("Created", _mapper.Map<Partner, PartnerToReturnDto>(newPartner));
        }
        
        /// <summary>
        /// Получает всех партнеров
        /// </summary>
        /// <returns>Всех партнеров</returns>
        /// <response code="200">Ok</response>
        [HttpGet("all")]
        [ProducesResponseType(typeof(ICollection<PartnerToReturnDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Index()
        {
            var partner = await _partnerService.GetAll();
            return Ok(_mapper.Map<ICollection<Partner>, ICollection<PartnerToReturnDto>>(partner));
        }
        
        /// <summary>
        /// Ищет партнера по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Партнера</returns>
        ///<response code="200">Ok</response>
        /// <response code="404">Партнер не найден</response>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(PartnerToReturnDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status404NotFound)]
        public IActionResult Get(long id)
        {
            try
            {
                var partner = _partnerService.GetById(id);
                return Ok(_mapper.Map<Partner, PartnerToReturnDto>(partner));
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

        [HttpPost("{id:long}/add-counterparty")]
        public async Task<IActionResult> AddCounterparty([FromBody] AddCounterpartyToPartnerDto dto)
        {
            var partner = await _partnerService.AddCounterparties(dto.Counterparties, dto.PartnerId);

            return Created("Created", _mapper.Map<Partner, PartnerToReturnDto>(partner));
        }
    }
}