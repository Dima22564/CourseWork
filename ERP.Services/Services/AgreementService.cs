using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Data.Abstractions;
using ERP.Domain.Core.Enums;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Creation;
using ERP.Services.Services.Abstractions;

namespace ERP.Services.Services
{
    public class AgreementService : IAgreementService
    {
        private readonly IGenericRepository<AgreementWithCustomer> _agreementRepo;
        private readonly IBusinessProposalRepository _bpRepo;
        private readonly IPartnerRepository _partnerRepository;
        private readonly IMapper _mapper;

        public AgreementService(IGenericRepository<AgreementWithCustomer> agreementRepo, IMapper mapper, IPartnerRepository partnerRepository, IBusinessProposalRepository bpRepo)
        {
            _agreementRepo = agreementRepo;
            _mapper = mapper;
            _partnerRepository = partnerRepository;
            _bpRepo = bpRepo;
        }
        
        public ICollection<AgreementWithCustomer> GetAll()
        {
            return _agreementRepo.GetWithInclude(x=> x.Currency, x => x.Partner);
        }

        public async Task<AgreementWithCustomer> Create(AgreementCreateDto dto)
        {
            var partner = await _partnerRepository.GetAsync(dto.PartnerId);
            int number;
            if (partner is null)
            {
                throw new Exception("Партнер не найден");
            }

            if (dto.Number is null || dto.Number == 0)
            {
                number = _bpRepo.CountNumberProposalsByPrefix(partner.Prefix) + 1;
            }
            else
            {
                number = (int) dto.Number;
            }

            var bp = _mapper.Map<AgreementCreateDto, AgreementWithCustomer>(dto);
            bp.GenerateNumber(partner.Prefix, number);
            bp.Status = DocumentStatuses.NotApproved;
            
            await _agreementRepo.AddAsync(bp);
            await _agreementRepo.SaveChangesAsync();

            return bp;
        }
    }
}