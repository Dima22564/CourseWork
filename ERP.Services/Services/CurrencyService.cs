using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Data.Abstractions;
using ERP.Domain.Core.Models;
using ERP.Services.DTO;
using ERP.Services.DTO.Creation;
using ERP.Services.DTO.Return;
using ERP.Services.Exceptions;
using ERP.Services.Services.Abstractions;

namespace ERP.Services.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IGenericRepository<Currency> _currencyRepo;
        private readonly IMapper _mapper;

        public CurrencyService(IGenericRepository<Currency> currencyRepo, IMapper mapper)
        {
            _currencyRepo = currencyRepo;
            _mapper = mapper;
        }
        
        public float GetExchangeRateForCurrencyFromExternalApi(int currencyNumericCode)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Currency> ChangeByCode(CreateCurrencyDto currencyDto)
        {
            var currency = await _currencyRepo.GetAsync(currencyDto.NumericCode);
            if (currency is null)
            {
                throw new ModelNotFoundException("Валюта не найдена");
            }
                
            currency.Name = currencyDto.Name;
            currency.CharacterCode = currencyDto.CharacterCode;
            currency.ExchangeRate = currencyDto.ExchangeRate;

            await _currencyRepo.SaveChangesAsync();

            return currency;
        }

        public async Task<Currency> GetById(object id)
        {
            return await _currencyRepo.GetAsync(id);
        }

        public async Task<ICollection<Currency>> GetAll()
        {
            return await _currencyRepo.GetAllListAsync();
        }

        public async Task<Currency> Create(CreateCurrencyDto dto)
        {
            var curr = await _currencyRepo.GetAsync(dto.NumericCode);
            if (!(curr is null))
            {
                throw new ModelNotFoundException("Валюта уже зарегистрированна");
            }
            
            var currency = _mapper.Map<CreateCurrencyDto, Currency>(dto);
            await _currencyRepo.AddAsync(currency);
            await _currencyRepo.SaveChangesAsync();

            return currency;
        }
    }
}