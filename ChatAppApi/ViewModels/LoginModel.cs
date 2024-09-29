using System.ComponentModel.DataAnnotations;

namespace ChatAppApi.ViewModels
{
    public class LoginModel
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}
