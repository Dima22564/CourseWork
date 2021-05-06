using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Domain.Core.Models;
using ERP.Services.DTO;
using ERP.Services.DTO.Creation;

namespace ERP.Services.Services.Abstractions
{
    public interface ICompanyService : ICreation<Company, CreateCompanyDto>, IFetch<Company>
    {
        public void UpdateById(int id, ManipulateCompanyDto companyDto);
        public void AttachAddressById(int id, CompanyAddressDto companyAddressDto);
        public void AttachContactsById(int id, CompanyContactsDto companyContactsDto);
        public void AddNewEmployee(int companyId, CreateEmployeeDto dto);
        public void AddExistingEmployee(int companyId, int employeeId);
        public void AddBankAccount();
    }
    
}