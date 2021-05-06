using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Data.Abstractions;
using ERP.Domain.Core.Intermediary;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Creation;
using ERP.Services.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ERP.Services
{
    public class PartnerService : IPartnerService
    {
        private readonly IGenericRepository<Partner> _partnerRepo;
        private readonly IGenericRepository<Counterparty> _counterpartyRepo;
        private readonly IMapper _mapper;

        public PartnerService(IMapper mapper, IGenericRepository<Partner> partnerRepo, IGenericRepository<Counterparty> counterpartyRepo)
        {
            _mapper = mapper;
            _partnerRepo = partnerRepo;
            _counterpartyRepo = counterpartyRepo;
        }

        public Task<Partner> GetById(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<Partner>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Partner> Create(PartnerCreateDto dto)
        {
            var partner = _mapper.Map<PartnerCreateDto, Partner>(dto);
            
            partner.AttachAddress(dto.LegalAddress, dto.PhysicalAddress);
            partner.AttachContacts(dto.Phone, dto.Email);
            partner.AttachName(dto.WorkName, dto.FullName);

            await _partnerRepo.AddAsync(partner);
            await _partnerRepo.SaveChangesAsync();

            return partner;
        }

        public async Task<Partner> AddCounterparties(IEnumerable<long> counterpartiesTins, object id) // TODO
        {
            var partner = await GetById(id);
            
            foreach (var ct in counterpartiesTins)
            {
                var counterparty = await _counterpartyRepo.GetAsync(ct);
                if (!(counterparty is null))
                {
                    partner.CounterpartyPartners.Add(new CounterpartyPartner { Partner = partner, Counterparty = counterparty});
                }
            }

            await _partnerRepo.SaveChangesAsync();

            return partner;
        }
    }
}