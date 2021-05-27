using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Adding;
using ERP.Services.DTO.Creation;

namespace ERP.Services.Services.Abstractions
{
    public interface IBusinessProposalService : ICreation<BusinessProposal, BusinessProposalCreateDto>
    {
        public ICollection<BusinessProposal> GetAll();
        public void Reject(string number);
        public void Approve(string number);
        public void Invalidate(string number);
        public Task<BusinessProposal> AddProducts(List<AddBusinessProposalProduct> products, string number);
    }
}