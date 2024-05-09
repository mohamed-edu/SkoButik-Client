using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkoButik_Client.Models
{
        public class Customer
        {
            [Key]
            public int CustomerId { get; set; }

            [Required(ErrorMessage = "First name is required")]
            [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Last name is required")]
            [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Email is required")]
            [StringLength(30, MinimumLength = 4, ErrorMessage = "Email must be between 4 and 30 characters")]
            [EmailAddress(ErrorMessage = "Invalid email address")]
            public string Email { get; set; }

            [StringLength(30, MinimumLength = 4, ErrorMessage = "Address must be between 4 and 30 characters")]
            [Required(ErrorMessage = "Address is required")]
            public string Address { get; set; }

            [Required(ErrorMessage = "Phone number is required")]
            [StringLength(12, MinimumLength = 4, ErrorMessage = "Phone-number must be between 4 and 12 characters")]
            [Phone(ErrorMessage = "Invalid phone number")]
            public string Phone { get; set; }

            public ICollection<Shopping_Session>? Shopping_Sessions { get; set; }
            public ICollection<Order_Detail>? Order_Details { get; set; }

    }
}
