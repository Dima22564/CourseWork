using System.Collections.Generic;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Creation;

namespace ERP.Services.Services.Abstractions
{
    public interface IAgreementService : ICreation<AgreementWithCustomer, AgreementCreateDto>
    {
        public ICollection<AgreementWithCustomer> GetAll();
    }
}