using System;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Creation;
using ERP.Services.DTO.Return;
using ERP.Services.Services.Abstractions;
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
    }
}