using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Data.Abstractions;
using ERP.Data.Repositories;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Creation;
using ERP.Services.Exceptions;
using ERP.Services.Services.Abstractions;

namespace ERP.Services.Services
{
    public class CounterpartyService : ICounterpartyService
    {
        private readonly ICounterpartyRepository _repo;
        private readonly IMapper _mapper;

        public CounterpartyService(IMapper mapper, ICounterpartyRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public Counterparty GetById(object id)
        {
            var counterparty = _repo.GetByIdWithAllIncludeData(id).ToList();
            if (counterparty.FirstOrDefault() is null)
            {
                throw new ModelNotFoundException("Контрагент не найден");
            }

            return counterparty.FirstOrDefault();
        }

        public async Task<ICollection<Counterparty>> GetAll()
        {
            return await _repo.GetAllListAsync();
        }

        public async Task<Counterparty> Create(CreateCounterpartyDto dto)
        {
            if (_repo.IsExists(x => x.Tin == dto.Tin))
            {
                throw new ApplicationException("Контрагент с таким ИНН уже существует");
            }

            var newCounterparty = _mapper.Map<CreateCounterpartyDto, Counterparty>(dto);
            newCounterparty.AttachName(dto.WorkName, dto.FullName);
            
            await _repo.AddAsync(newCounterparty);
            await _repo.SaveChangesAsync();

            return newCounterparty;
        }

        public async Task<Counterparty> UpdateContacts(CounterpartyContactsCreateDto dto)
        {
            var counterparty = await _repo.GetAsync(dto.Tin);

            if (counterparty is null)
            {
                throw new ModelNotFoundException("Контрагент не найден");
            }
            
            counterparty.AttachAddress(dto.LegalAddress, dto.PhysicalAddress);
            counterparty.AttachContacts(dto.Phone, dto.Email);

            await _repo.SaveChangesAsync();

            return counterparty;
        }
    }
}