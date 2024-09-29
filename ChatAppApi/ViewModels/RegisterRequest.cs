using System.ComponentModel.DataAnnotations;

namespace ChatAppApi.ViewModels
{
    public class RegisterRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
