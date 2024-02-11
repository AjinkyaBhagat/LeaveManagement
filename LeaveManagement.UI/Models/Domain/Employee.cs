using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.UI.Models.Domain
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


        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        public DateTime BirthDate { get; set; }
        [Required]

        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Designation { get; set; }
        public int LeavesAvailable { get; set; }
        public int LeavesTotal { get; set; }

        // Navigation property for leaves
        public virtual ICollection<Leave> Leaves { get; set; }
    }
}
