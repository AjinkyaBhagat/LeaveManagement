using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.UI.Models.DTO
{
    public class AddEmployeerequestDto
    {
        //[Required(ErrorMessage = "Id is required.")]
        //public Guid EmployeeId { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Birth Date is required.")]
        public DateTime BirthDate { get; set; }


        [Required(ErrorMessage = "Phone Number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Designation is required.")]
        public string Designation { get; set; }
        public int LeavesAvailable { get; set; }
        public int LeavesTotal { get; set; }
    }
}
