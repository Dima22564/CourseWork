using System.Threading.Tasks;
using ERP.Data.Abstractions;
using ERP.Domain.Core.Abstract;
using ERP.Domain.Core.Models;
using ERP.Services.Services.Abstractions;

namespace ERP.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<Person> _userRepository;

        public UserService(IGenericRepository<Person> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Person> GetUserByIdAsync(object id)
        {
            return await _userRepository.GetAsync(id);
        }
    }
}