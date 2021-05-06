using System.Threading.Tasks;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Creation;

namespace ERP.Services.Services.Abstractions
{
    public interface IEmployeeService : ICreation<Employee, CreateEmployeeDto>, ICreation<ContactPerson, CreateContactPersonDto>
    {
        public Position CreatePosition();
        public void UpdateEmployeeById();
        public void UpdatePositionById();

        public Task<Employee> GetEmployeeById(int id);

        public ContactPerson CreateContactPerson();
        public void UpdateContactPersonById();
    }
}