using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Domain.Core.Models;
using ERP.Services.DTO;
using ERP.Services.DTO.Creation;

namespace ERP.Services.Services.Abstractions
{
    public interface IBankAccountsService : ICreation<BankAccount, BankAccountCreateDto>
    {
        public ICollection<BankAccount> GetById(object id);
        public ICollection<BankAccount> GetAll();
    }
}