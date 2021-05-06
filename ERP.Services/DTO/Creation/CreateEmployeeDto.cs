using System;
using ERP.Services.DTO.Abstract;

namespace ERP.Services.DTO.Creation
{
    public class CreateEmployeeDto : CreationDto
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Tin { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime HiringDate { get; set; }
        public string Gender { get; set; }
        public int PositionId { get; set; }
        public float Salary { get; set; }

        public CreateEmployeeDto(string fullName, string phone, string email, string tin, DateTime dateOfBirth, DateTime hiringDate, string gender, int positionId, float salary)
        {
            FullName = fullName;
            Phone = phone;
            Email = email;
            Tin = tin;
            DateOfBirth = dateOfBirth;
            HiringDate = hiringDate;
            Gender = gender;
            PositionId = positionId;
            Salary = salary;
        }
    }
}