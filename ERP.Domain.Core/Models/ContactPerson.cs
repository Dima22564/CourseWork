using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Domain.Core.Abstract;
using ERP.Domain.Core.Intermediary;

namespace ERP.Domain.Core.Models
{
    [Table("ContactPeople")]
    public class ContactPerson : Person
    {
        public virtual ICollection<PartnerContactPeople> PartnerContactPeople { get; set; }
    }
}