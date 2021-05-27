using System.Linq;
using ERP.Data.Abstractions;
using ERP.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Data.Repositories
{
    public class BusinessProposalRepository : GenericRepository<BusinessProposal>, IBusinessProposalRepository 
    {
        public BusinessProposalRepository(ApplicationDbContext context) : base(context)
        {
        }

        public int CountNumberProposalsByPrefix(string prefix)
        {
            return _context.BusinessProposals.Count(p => EF.Functions.Like(p.Number, $"%{prefix}%"));
        }
    }
}