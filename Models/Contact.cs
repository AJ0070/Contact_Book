using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters")]
        [Display(Name = "First Name")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters")]
        [Display(Name = "Last Name")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [Display(Name = "Phone Number")]
        public required string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
        [Display(Name = "Address")]
        public required string Address { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";
    }
}
