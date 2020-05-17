using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patederm.Models
{
    public class AppUser : IdentityUser
    {
        //public virtual Student Student { get; set; }
        //public int StudentID { get; set; }
        //public string UserId { get; set; }
    }

    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store) : base(store)
        {
        }
        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options,
            IOwinContext context)
        {
            MartineDbContext db = context.Get<MartineDbContext>();
            AppUserManager manager = new AppUserManager(new UserStore<AppUser>(db))
            {
                PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 6,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireUppercase = true
                }
            };
            manager.UserValidator = new UserValidator<AppUser>(manager)
            {
                RequireUniqueEmail = true
            };
            return manager;
        }
    }
}