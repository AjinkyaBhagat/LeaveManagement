using LeaveManagement.API.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.API.Models.DTO
{
    public class AddLeaveRequestDto
    {
        //[Required]
        //public Guid LeaveId { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }

        //[ForeignKey(nameof(EmployeeId))]
        //public virtual Employee Employee { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        public string LeaveType { get; set; }
        [Required]
        public string Reason { get; set; }

        public string Status { get; set; }
    }
}
