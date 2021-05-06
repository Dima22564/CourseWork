using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Data.Abstractions;
using ERP.Domain.Core.Models;
using ERP.Services.DTO;
using ERP.Services.DTO.Creation;
using ERP.Services.DTO.Return;
using ERP.Services.Services.Abstractions;

namespace ERP.Services.Services
{
    public class BankAccountService : IBankAccountsService
    {
        private readonly IGenericRepository<BankAccount> _bankAccountRepo;
        private readonly IGenericRepository<Currency> _currencyRepo;
        private readonly IGenericRepository<Bank> _bankRepo;
        private readonly IGenericRepository<Counterparty> _counterpartyRepo;
        private readonly IMapper _mapper;

        public BankAccountService(IGenericRepository<BankAccount> bankAccountRepo, IGenericRepository<Currency> currencyRepo, IGenericRepository<Bank> bankRepo, IGenericRepository<Counterparty> counterpartyRepo, IMapper mapper)
        {
            _bankAccountRepo = bankAccountRepo;
            _currencyRepo = currencyRepo;
            _bankRepo = bankRepo;
            _counterpartyRepo = counterpartyRepo;
            _mapper = mapper;
        }

        public ICollection<BankAccount> GetById(object id)
        {
            return _bankAccountRepo.GetWithInclude(c => c.AccountNumber ==  (long) id, c => c.Currency, c => c.Bank, c => c.Company);
        }

        public ICollection<BankAccount> GetAll()
        {
            return _bankAccountRepo.GetWithInclude(c => c.Currency, c => c.Bank, c => c.Company);
        }

        public async Task<BankAccount> Create(BankAccountCreateDto dto)
        {
            var currency = await _currencyRepo.GetAsync(dto.CurrencyCode);
            var bank = await _bankRepo.GetAsync(dto.BankBic);
            var counterparty = await _counterpartyRepo.GetAsync(dto.CompanyId);

            var account = _mapper.Map<BankAccountCreateDto, BankAccount>(dto);
            
            account.InBank(bank)
                .InCurrency(currency)
                .AttachCounterparty(counterparty);
            
            await _bankAccountRepo.AddAsync(account);
            await _bankAccountRepo.SaveChangesAsync();

            return account;
        }
    }
}