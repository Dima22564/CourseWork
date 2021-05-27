using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Creation;
using ERP.Services.DTO.Return;
using ERP.Services.Services.Abstractions;
using ERP.WebApi.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.WebApi.Controllers
{
    [ApiController]
    [Route("/api/position")]
    public class PositionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPositionService _positionService;

        public PositionController(IMapper mapper, IPositionService positionService)
        {
            _mapper = mapper;
            _positionService = positionService;
        }

        /// <summary>
        /// Возвращает все позиции сотрудников
        /// </summary>
        /// <returns>Все позиции сотрудников</returns>
        /// <response code="200">Ok</response>
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<PositionToReturnDto>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var positions = await _positionService.GetAll();
            return Ok(_mapper.Map<ICollection<Position>, ICollection<PositionToReturnDto>>(positions));
        }
        
        /// <summary>
        /// Создает новую должность
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Созданную должность</returns>
        /// <response code="201">Должность создана</response>
        /// <response code="400">Должность не создана, ошибки валидации данных</response>
        [HttpPost]
        [ProducesResponseType(typeof(PositionToReturnDto), 201)]
        [ProducesResponseType(typeof(ApiException), 400)]
        public async Task<IActionResult> Create([FromForm] PositionCreateDto dto)
        {
            try
            {
                var position = await _positionService.Create(dto);
                return Created("Ok", _mapper.Map<Position, PositionToReturnDto>(position));
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(StatusCodes.Status400BadRequest, e.Message));
            }
        }
    }
}