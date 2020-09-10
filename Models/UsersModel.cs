using System.ComponentModel.DataAnnotations;

namespace Bug_Bag_Manager.Models
{
    public class UsersModel
    {
        [Display(Name = "User ID")]
        [Range(100000, 999999, ErrorMessage = "You need to enter a valid UserID")]
        public int UserId { get; set; }


        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You need to give us your first name.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You need to give us your last name.")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "You need to give us your email address.")]
        public string EmailAddress { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Confirm Email")]
        [Compare("EmailAddress", ErrorMessage = "The Email and Confirm Email must match.")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You must have a password.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "You need to provide a long enough password")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Your password and confirm password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "User Type")]
        public int UserType { get; set; } //creates a user type. 0 = superuser, 1 = admin, 2 = user
    }
}