using System.ComponentModel.DataAnnotations;

namespace WebAppRESTAPI.Models.ViewModels
{
    public class CreateLoginViewModel : LoginViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
    }
}
