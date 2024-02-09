using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.API.Models.Domain
{
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        public DateTime BirthDate { get; set; }
        [Required]
        [Phone]
        public int PhoneNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Designation { get; set;}
        public int LeavesAvailable { get; set; }
        public int LeavesTotal { get; set;}

        // Navigation property for leaves
        public virtual ICollection<Leave> Leaves { get; set; }

    }
}
