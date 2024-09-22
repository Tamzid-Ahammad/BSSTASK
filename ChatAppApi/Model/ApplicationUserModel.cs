using System.ComponentModel.DataAnnotations;

namespace ChatAppApi.Model
{
    public class ApplicationUserModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
