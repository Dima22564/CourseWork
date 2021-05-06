using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Creation;
using ERP.Services.DTO.Return;
using ERP.Services.Services.Abstractions;
using ERP.WebApi.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.WebApi.Controllers
{
    [ApiController]
    [Route("/api/bank")]
    public class BankController : ControllerBase
    {
        private readonly IBankService _bankService;
        private readonly IMapper _mapper;

        public BankController(IBankService bankService, IMapper mapper)
        {
            _bankService = bankService;
            _mapper = mapper;
        }

        /// <summary>
        /// Возвращает все зарегистрированные банки
        /// </summary>
        /// <returns>Все зарегистрированные банки</returns>
        /// <response code="200">Ok</response>
        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(ICollection<BankToReturn>), 200)]
        public async Task<IActionResult> Index()
        {
            var banks = await _bankService.GetAll();
            return Ok(_mapper.Map<ICollection<Bank>, ICollection<BankToReturn>>(banks));
        }

        /// <summary>
        /// Регистрирует в системе новый банк
        /// </summary>
        /// <returns>Созданный банк</returns>
        /// <response code="201">Created</response>
        /// <response code="400">Ошибка валидации данных</response>
        [HttpPost]
        [ProducesResponseType(typeof(BankToReturn), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromForm] CreateBankDto dto)
        {
            try
            {
                var bank = await _bankService.Create(dto);
                return Created("Ok", _mapper.Map<Bank, BankToReturn>(bank));
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(StatusCodes.Status400BadRequest, e.Message));
            }
        }
    }
}