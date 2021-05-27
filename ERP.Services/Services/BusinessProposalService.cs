using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Data.Abstractions;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Adding;
using ERP.Services.DTO.Creation;
using ERP.Services.Services.Abstractions;

namespace ERP.Services.Services
{
    public class BusinessProposalService : IBusinessProposalService
    {
        private readonly IPartnerRepository _partnerRepository;
        private readonly IBusinessProposalRepository _bpRepo;
        private readonly IGenericRepository<BusinessProposalProduct> _bpProductRepo;
        private readonly IMapper _mapper;

        public BusinessProposalService(IPartnerRepository partnerRepository, IBusinessProposalRepository bpRepo, IMapper mapper, IGenericRepository<BusinessProposalProduct> bpProductRepo)
        {
            _partnerRepository = partnerRepository;
            _bpRepo = bpRepo;
            _mapper = mapper;
            _bpProductRepo = bpProductRepo;
        }

        public async Task<BusinessProposal> Create(BusinessProposalCreateDto dto)
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
            
            var bp = _mapper.Map<BusinessProposalCreateDto, BusinessProposal>(dto);
            bp.GenerateNumber(partner.Prefix, number);
            
            await _bpRepo.AddAsync(bp);
            await _bpRepo.SaveChangesAsync();

            return bp;
        }
        
        public ICollection<BusinessProposal> GetAll()
        {
            return _bpRepo.GetWithInclude(x => x.Partner);
        }

        public void Reject(string number)
        {
            var bp = _bpRepo.GetTracked(x => x.Number == number).FirstOrDefault();
            if (bp is null)
            {
                throw new Exception("КП не найдено");
            }
            
            if (!bp.IsApprove()) throw new Exception("Нельзя поменять статус");

            bp.Reject();
            _bpRepo.SaveChanges();
        }

        public void Approve(string number)
        {
            var bp = _bpRepo.GetTracked(x => x.Number == number).FirstOrDefault();
            if (bp is null)
            {
                throw new Exception("КП с таким номером не найдено");
            }

            if (bp.IsApprove()) throw new Exception("Нельзя поменять статус");
            
            bp.Approve();
            _bpRepo.SaveChanges();
        }
        
        public void Invalidate(string number)
        {
            var bp = _bpRepo.GetTracked(x => x.Number == number).FirstOrDefault();
            if (bp is null)
            {
                throw new Exception("КП с таким номером не найдено");
            }
            
            bp.Close();
            _bpRepo.SaveChanges();
        }

        public async Task<BusinessProposal> AddProducts(List<AddBusinessProposalProduct> products, string number)
        {
            var bp = _bpRepo.Get(x => x.Number == number).FirstOrDefault();

            var i = 0;
            foreach (var product in products)
            {
                i += 1;
                var newBpProduct = _mapper.Map<AddBusinessProposalProduct, BusinessProposalProduct>(product);
                newBpProduct.CalculateAmount();
                newBpProduct.BusinessProposalId = number;
                newBpProduct.PositionNumber = i;

                await _bpProductRepo.AddAsync(newBpProduct);
            }
            
            await _bpProductRepo.SaveChangesAsync();
            
            return bp;
        }
    }
}