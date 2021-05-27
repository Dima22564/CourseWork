using System.Collections.Generic;
using System.Linq;
using ERP.Data.Abstractions;
using ERP.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Data.Repositories
{
    public class PartnerRepository : GenericRepository<Partner>, IPartnerRepository
    {
        public PartnerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Partner> GetByIdWithAllIncludeData(object id)
        {
            return _dbSet.AsNoTracking()
                .Where(x => x.PartnerId == (long) id)
                .Include(c => c.AgreementsWithCustomers)
                .ThenInclude(x => x.ClientOrders)
                .Include(x => x.ResponsiblePerson)
                .AsEnumerable();
        }
    }
}