using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Adding;
using ERP.Services.DTO.Creation;
using ERP.Services.DTO.Return;
using ERP.Services.Services.Abstractions;
using ERP.WebApi.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.WebApi.Controllers
{
    [ApiController]
    [Route("/api/business-proposal")]
    public class BusinessProposalController : ControllerBase
    {
        private readonly IBusinessProposalService _businessProposalService;
        private readonly IMapper _mapper;

        public BusinessProposalController(IMapper mapper, IBusinessProposalService businessProposalService)
        {
            _mapper = mapper;
            _businessProposalService = businessProposalService;
        }

        /// <summary>
        /// Создает новое КП
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Созданное КП</returns>
        /// <response code="201">КП успешно создано</response>
        [HttpPost]
        [ProducesResponseType(typeof(BusinessProposalCreateDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] BusinessProposalCreateDto dto)
        {
            var newBp = await _businessProposalService.Create(dto);

            return Created("Created", _mapper.Map<BusinessProposal, BusinessProposalToReturnDto>(newBp));
        }
        
        /// <summary>
        /// Возвращает все КП
        /// </summary>
        /// <returns>Все КП</returns>
        /// <response code="200">Ok</response>
        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(ICollection<BusinessProposalToReturnDto>), StatusCodes.Status200OK)]
        public IActionResult Index()
        {
            var banks = _businessProposalService.GetAll();
            return Ok(_mapper.Map<ICollection<BusinessProposal>, ICollection<BusinessProposalToReturnDto>>(banks));
        }

        [HttpPut("{number}")]
        [ProducesResponseType(typeof(ICollection<BusinessProposalToReturnDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ICollection<ApiException>), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> AddProducts([FromBody] List<AddBusinessProposalProduct> products, string number)
        {
            try
            {
               var bp = await _businessProposalService.AddProducts(products, number);
               return Ok(_mapper.Map<BusinessProposal, BusinessProposalToReturnDto>(bp));
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(StatusCodes.Status400BadRequest, e.Message));
            }
        }

        [HttpPatch]
        [Route("{number}/invalidate")]
        [ProducesResponseType(typeof(ICollection<BusinessProposalToReturnDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ICollection<ApiException>), StatusCodes.Status403Forbidden)]
        public IActionResult Invalidate(string number)
        {
            try
            {
                _businessProposalService.Invalidate(number);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(StatusCodes.Status400BadRequest, e.Message));
            }

            return Ok();
        }

        [HttpPatch]
        [Route("{number}/approve")]
        [ProducesResponseType(typeof(ICollection<BusinessProposalToReturnDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ICollection<ApiException>), StatusCodes.Status403Forbidden)]
        public IActionResult Approve(string number)
        {
            try
            {
                _businessProposalService.Approve(number);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(StatusCodes.Status400BadRequest, e.Message));
            }

            return Ok();
        }

        [HttpPatch]
        [Route("{number}/reject")]
        [ProducesResponseType(typeof(ICollection<BusinessProposalToReturnDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ICollection<ApiException>), StatusCodes.Status403Forbidden)]
        public IActionResult Reject(string number)
        {
            try
            {
                _businessProposalService.Reject(number);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(StatusCodes.Status400BadRequest, e.Message));
            }

            return Ok();
        }
    }
}