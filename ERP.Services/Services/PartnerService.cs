using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Data.Abstractions;
using ERP.Domain.Core.Intermediary;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Creation;
using ERP.Services.Exceptions;
using ERP.Services.Services.Abstractions;

namespace ERP.Services.Services
{
    public class PartnerService : IPartnerService
    {
        private readonly IPartnerRepository _partnerRepo;
        private readonly IGenericRepository<Counterparty> _counterpartyRepo;
        private readonly IMapper _mapper;

        public PartnerService(IMapper mapper, IPartnerRepository partnerRepo, IGenericRepository<Counterparty> counterpartyRepo)
        {
            _mapper = mapper;
            _partnerRepo = partnerRepo;
            _counterpartyRepo = counterpartyRepo;
        }

        public Partner GetById(object id)
        {
            var counterparty = _partnerRepo.GetByIdWithAllIncludeData(id).ToList();
            if (counterparty.FirstOrDefault() is null)
            {
                throw new ModelNotFoundException("Партнер не найден");
            }

            return counterparty.FirstOrDefault();
        }

        public async Task<ICollection<Partner>> GetAll()
        {
            var partners = await _partnerRepo.GetAllListAsync();
            return partners;
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

        public async Task<Partner> AddCounterparties(List<long> counterpartiesTins, object id) // TODO
        {
            var partner = await _partnerRepo.GetAsync(id);
            var cps = await _counterpartyRepo.GetAllListAsync();
            foreach (var ct in counterpartiesTins)
            {
                var counterparty = cps.FirstOrDefault(x => x.Tin == ct);
                if (counterparty is null) continue;
                
                var cpPartner = new CounterpartyPartner {CounterpartyId = counterparty.Tin, PartnerId = partner.PartnerId};
                partner.CounterpartyPartners.Add(cpPartner);
                await _partnerRepo.SaveChangesAsync();
            }

            return partner;
        }
    }
}