using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Creation;
using ERP.Services.DTO.Return;
using ERP.Services.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.WebApi.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        /// <summary>
        /// Создает новый товар
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Созданный товар</returns>
        /// <response code="201">Товар успешно создан</response>
        [HttpPost]
        [ProducesResponseType(typeof(ProductToReturnDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] ProductCreateDto dto)
        {
            var newProduct = await _productService.Create(dto);

            return Created("Created", _mapper.Map<Product, ProductToReturnDto>(newProduct));
        }
        
        /// <summary>
        /// Получает все товары
        /// </summary>
        /// <returns>Все товары</returns>
        /// <response code="200">Ok</response>
        [HttpGet("all")]
        [ProducesResponseType(typeof(ICollection<ProductToReturnDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Index()
        {
            var partner = await _productService.GetAll();
            return Ok(_mapper.Map<ICollection<Product>, ICollection<ProductToReturnDto>>(partner));
        }
    }
}