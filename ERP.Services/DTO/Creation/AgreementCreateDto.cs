using System;
using ERP.Services.DTO.Abstract;
using JetBrains.Annotations;

namespace ERP.Services.DTO.Creation
{
    public class AgreementCreateDto : CreationDto
    {
        public long PartnerId { get; set; }
        public int? Number { get; set; }
        public DateTime From { get; set; }
        [CanBeNull] public string Comment { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int CurrencyCode { get; set; }
    }
}