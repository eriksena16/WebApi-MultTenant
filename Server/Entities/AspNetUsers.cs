using Microsoft.AspNetCore.Identity;

namespace Server.Entities
{
    public class Users :  IdentityUser
    {
        public long AccountId { get; set; }
    }
}
