using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ContactsManager.Core.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage ="Email Required")]
        [EmailAddress(ErrorMessage ="Email should be in the right format")]
        [Remote(action: "IsDuplicateEmail", controller: "Account", ErrorMessage = "Email already exists")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage ="First name Can't be blank")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Last name can't be blank")]
        public string LastName { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessage ="Numbers only")]
        [StringLength(11, ErrorMessage ="10 digits required.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage ="Confirmation password required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Confirmation-Password mismatch.")]
        public string ConfirmPassword { get; set; }
    }
}
