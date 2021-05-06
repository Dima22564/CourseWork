using System;
using System.Collections.Generic;
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
    public class BankService : IBankService
    {
        private readonly IGenericRepository<Bank> _bankRepo;
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public BankService(IGenericRepository<Bank> bankRepo, IMapper mapper, ICountryService countryService)
        {
            _bankRepo = bankRepo;
            _mapper = mapper;
            _countryService = countryService;
        }

        public async Task<Bank> GetById(object id)
        {
            return await _bankRepo.GetAsync(id);
        }

        public async Task<ICollection<Bank>> GetAll()
        {
            return await _bankRepo.GetAllListAsync();
        }

        public async Task<Bank> Create(CreateBankDto dto)
        {
            var bank = await _bankRepo.GetAsync(dto.Bic);
            if (bank != null)
            {
                throw new ApplicationException("Банк уже зарегистрирован");
            }

            var country = await _countryService.GetById(dto.CountryCode);
            if (country is null)
            {
                throw new ModelNotFoundException("Страна не найдена");
            }

            var newBank = _mapper.Map<CreateBankDto, Bank>(dto);
            newBank.InCountry(country);

            await _bankRepo.AddAsync(newBank);
            await _bankRepo.SaveChangesAsync();

            return newBank;
        }
    }
}