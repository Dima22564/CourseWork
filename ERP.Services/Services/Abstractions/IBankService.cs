using ERP.Domain.Core.Models;
using ERP.Services.DTO;
using ERP.Services.DTO.Creation;

namespace ERP.Services.Services.Abstractions
{
    public interface IBankService : IFetch<Bank>, ICreation<Bank, CreateBankDto>
    {
    }
}