using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Creation;

namespace ERP.Services.Services.Abstractions
{
    public interface IProductService : ICreation<Product, ProductCreateDto>
    {
        public Task<ICollection<Product>> GetAll();
    }
}