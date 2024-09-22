using System.ComponentModel.DataAnnotations;

namespace ChatAppApi.Model
{
    public class LoginModel
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}
