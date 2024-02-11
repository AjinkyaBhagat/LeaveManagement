﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LeaveManagement.UI.Models.Domain;

namespace LeaveManagement.UI.Models.DTO
{
    public class LeaveDto
    {
        [Key]
        public Guid LeaveId { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee Employee { get; set; }

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
