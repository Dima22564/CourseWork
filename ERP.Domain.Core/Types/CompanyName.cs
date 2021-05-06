using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERP.Domain.Core.Types
{
    [Owned]
    public class CompanyName
    {
        [Column("FullName")]
        public string FullName { get; set; }
        
        [Column("WorkName")]
        public string WorkName { get; set; }

        public CompanyName(string fullName, string workName)
        {
            FullName = fullName;
            WorkName = workName;
        }

        public CompanyName()
        {
        }
    }
}