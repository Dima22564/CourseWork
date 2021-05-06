using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace ERP.Domain.Core.Models
{
    public class Person : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public Person(string fullName, string phone, string email)
        {
            FullName = fullName;
            Phone = phone;
            Email = email;
        }

        public Person()
        {
        }

        private Person(string fullName, string phone, string email, string password)
        {
            FullName = fullName;
            Phone = phone;
            Email = email;
            Password = password;
        }

        public string FullName { get; set; }
        public string Phone { get; set; }
        public int Tin { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        
        [CanBeNull] public int? PositionId { get; set; }
        [CanBeNull] public virtual Position Position { get; set; }

        public static Person Create(string fullName, string phone, string email, string password)
        {
            return new Person(fullName, phone, email, password);
        }
    }
}