using System;

namespace ERP.Services.DTO.Return
{
    public class PositionToReturnDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime IncludeAt { get; set; }
        public DateTime ExcludeAt { get; set; }
    }
}