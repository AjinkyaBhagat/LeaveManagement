using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LeaveManagement.API.Models.Domain;

namespace LeaveManagement.API.Models.DTO
{
    public class AddEmployeeRequestDto
    {
        public Guid EmployeeId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }

        public DateTime BirthDate { get; set; }
        [Required]

        public string PhoneNumber { get; set; }

        [Required]
        public string Designation { get; set; }
        public int LeavesAvailable { get; set; }
        public int LeavesTotal { get; set; }
    }
}
