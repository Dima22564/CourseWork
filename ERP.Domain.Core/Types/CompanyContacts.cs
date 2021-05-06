using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace ERP.Domain.Core.Types
{
    [Owned]
    public class CompanyContacts
    {
        [Column("Phone")]
        [CanBeNull] public string Phone { get; set; }
        
        [Column("Email")]
        [CanBeNull] public string Email { get; set; }

        public CompanyContacts(string phone, string email)
        {
            Phone = phone;
            Email = email;
        }

        public CompanyContacts()
        {
        }
    }
}