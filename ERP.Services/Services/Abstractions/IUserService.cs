using System.Threading.Tasks;
using ERP.Domain.Core.Abstract;
using ERP.Domain.Core.Models;

namespace ERP.Services.Services.Abstractions
{
    public interface IUserService
    {
        public Task<Person> GetUserByIdAsync(object id);
    }
}