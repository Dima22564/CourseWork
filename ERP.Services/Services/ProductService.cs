using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Data.Abstractions;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Creation;
using ERP.Services.Services.Abstractions;

namespace ERP.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<Product> Create(ProductCreateDto dto)
        {
            var position = _mapper.Map<ProductCreateDto, Product>(dto);
            await _productRepo.AddAsync(position);
            await _productRepo.SaveChangesAsync();

            return position;
        }

        public async Task<ICollection<Product>> GetAll()
        {
            return await _productRepo.GetAllListAsync();
        }
    }
}