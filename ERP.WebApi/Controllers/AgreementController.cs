using System.Collections.Generic;
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
    [Route("/api/agreement")]
    public class AgreementController : ControllerBase
    {
        private readonly IAgreementService _agreementService;
        private readonly IMapper _mapper;

        public AgreementController(IAgreementService agreementService, IMapper mapper)
        {
            _agreementService = agreementService;
            _mapper = mapper;
        }

        /// <summary>
        /// Создает новое КП
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Созданное КП</returns>
        /// <response code="201">КП успешно создано</response>
        [HttpPost]
        [ProducesResponseType(typeof(AgreementToReturnDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] AgreementCreateDto dto)
        {
            var newBp = await _agreementService.Create(dto);

            return Created("Created", _mapper.Map<AgreementWithCustomer, AgreementToReturnDto>(newBp));
        }
        
        /// <summary>
        /// Возвращает все КП
        /// </summary>
        /// <returns>Все КП</returns>
        /// <response code="200">Ok</response>
        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(ICollection<AgreementToReturnDto>), StatusCodes.Status200OK)]
        public IActionResult Index()
        {
            var banks = _agreementService.GetAll();
            return Ok(_mapper.Map<ICollection<AgreementWithCustomer>, ICollection<AgreementToReturnDto>>(banks));
        }
    }
}