#nullable enable
using System.Threading.Tasks;
using ERP.Data.Abstractions;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Creation;
using ERP.Services.DTO.Return;
using ERP.Services.Services.Abstractions;

namespace ERP.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _employeeRepo;
        private readonly IGenericRepository<Position> _positionsRepo;
        private readonly IGenericRepository<Company> _companyRepo;

        public EmployeeService(IGenericRepository<Employee> employeeRepo, IGenericRepository<Position> positionsRepo, IGenericRepository<Company> companyRepo)
        {
            _employeeRepo = employeeRepo;
            _positionsRepo = positionsRepo;
            _companyRepo = companyRepo;
        }

        public Position CreatePosition()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateEmployeeById()
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePositionById()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employeeRepo.GetAsync(id);
        }

        public ContactPerson CreateContactPerson()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateContactPersonById()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Employee> Create(CreateEmployeeDto dto)
        {
            var position = await _positionsRepo.GetAsync(dto.PositionId);
            
            var employee = new Employee();
            
            employee.TakePosition(position);

            await _employeeRepo.AddAsync(employee);
            await _employeeRepo.SaveChangesAsync();

            return employee;
        }

        public Task<ContactPerson> Create(CreateContactPersonDto dto)
        {
            throw new System.NotImplementedException();
        }
    }
}