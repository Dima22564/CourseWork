using System.Collections.Generic;
using ERP.Domain.Core.Models;

namespace ERP.Data.Abstractions
{
    public interface IPartnerRepository :  IGenericRepository<Partner>
    {
        public IEnumerable<Partner> GetByIdWithAllIncludeData(object id);
    }
}