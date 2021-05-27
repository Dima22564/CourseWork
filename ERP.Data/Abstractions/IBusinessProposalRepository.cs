using ERP.Domain.Core.Models;

namespace ERP.Data.Abstractions
{
    public interface IBusinessProposalRepository : IGenericRepository<BusinessProposal>
    {
        public int CountNumberProposalsByPrefix(string prefix);
    }
}