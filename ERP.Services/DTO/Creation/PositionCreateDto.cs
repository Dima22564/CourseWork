using System;
using ERP.Services.DTO.Abstract;
using JetBrains.Annotations;

namespace ERP.Services.DTO.Creation
{
    public class PositionCreateDto : CreationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime IncludeAt { get; set; }
    }
}