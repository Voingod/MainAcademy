using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Patederm.Models
{
    public class UserDbContext : IdentityDbContext<AppUser>
    {
        public UserDbContext() : base("MartineDbConnection") { }

        public static UserDbContext Create()
        {
            return new UserDbContext();
        }
    }
}