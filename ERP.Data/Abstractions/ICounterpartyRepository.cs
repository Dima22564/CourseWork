using System.Collections.Generic;
using ERP.Domain.Core.Models;

namespace ERP.Data.Abstractions
{
    public interface ICounterpartyRepository : IGenericRepository<Counterparty>
    {
        public IEnumerable<Counterparty> GetByIdWithAllIncludeData(object id);
    }
}