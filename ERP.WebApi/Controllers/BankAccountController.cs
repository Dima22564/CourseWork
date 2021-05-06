using System;
using System.Collections.Generic;
using System.Linq;
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
    [Route("api/bank-account")]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountsService _bankAccountsService;
        private readonly IMapper _mapper;

        public BankAccountController(IBankAccountsService bankAccountsService, IMapper mapper)
        {
            _bankAccountsService = bankAccountsService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получает все банковские счета с валютой, банком и контрагентом
        /// </summary>
        /// <returns>Все банковские счета</returns>
        /// <response code="200">Ok</response>
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<BankAccountToReturn>), StatusCodes.Status200OK)]
        public IActionResult Index()
        {
            var accounts = _bankAccountsService.GetAll();
            return Ok(_mapper.Map<ICollection<BankAccount>, ICollection<BankAccountToReturn>>(accounts));
        }
        
        /// <summary>
        /// Ищет банковский счет но его номеру
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns>Банковский счет</returns>
        /// <response code="200">Ok</response>
        /// <response code="404">Банковский счет не найден</response>
        [HttpGet("{accountNumber:long}")]
        [ProducesResponseType(typeof(CounterpartyToReturn), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status404NotFound)]
        public IActionResult Get(long accountNumber)
        {
            var account = _bankAccountsService.GetById(accountNumber);

            if (account.FirstOrDefault() == null)
            {
                return NotFound(new ApiException(StatusCodes.Status400BadRequest, "Банковский счет не найден"));
            }
            
            return Ok(_mapper.Map<BankAccount, BankAccountToReturn>(account.FirstOrDefault()));
        }
        
        /// <summary>
        /// Создает новый банковский счет для компании, задавая валюту
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Созданный банковский счет</returns>
        /// <response code="201">Банковский счет создан</response>
        /// <response code="400">Банковский счет не создан, ошибки валидации данных</response>
        [HttpPost]
        [ProducesResponseType(typeof(BankAccountToReturn), 201)]
        [ProducesResponseType(typeof(ApiException), 400)]
        public async Task<IActionResult> Create([FromForm] BankAccountCreateDto dto)
        {
            try
            {
                var account = await _bankAccountsService.Create(dto);
                return Created("Ok", _mapper.Map<BankAccount, BankAccountToReturn>(account));
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(StatusCodes.Status400BadRequest, e.Message));
            }
        }
    }
}