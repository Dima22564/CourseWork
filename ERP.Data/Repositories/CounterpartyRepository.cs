using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ERP.Data.Abstractions;
using ERP.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Data.Repositories
{
    public class CounterpartyRepository : GenericRepository<Counterparty>, ICounterpartyRepository
    {
        public CounterpartyRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Counterparty> GetByIdWithAllIncludeData(object id)
        {
            return _dbSet.AsNoTracking()
                .Where(x => x.Tin == (long) id)
                .Include(c => c.BankAccounts)
                .ThenInclude(c => c.Bank)
                .Include(c => c.BankAccounts)
                .ThenInclude(c => c.Currency)
                .AsEnumerable();
        }
    }
}