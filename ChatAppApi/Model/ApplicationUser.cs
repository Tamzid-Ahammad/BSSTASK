using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatAppApi.Model
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Column(TypeName = "nvarchar(150)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string LastName { get; set; }

        public ICollection<UsersConversation> UsersConversations { get; set; }
    }
}
