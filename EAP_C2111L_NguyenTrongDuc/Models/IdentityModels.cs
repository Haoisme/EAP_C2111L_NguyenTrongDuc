using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EAP_C2111L_NguyenTrongDuc.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DataContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public void InitializeData()
        {
            // Create a RoleManager and UserManager
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this));

            // Create a role
            var roleName = "Admin";
            if (!roleManager.RoleExists(roleName))
            {
                var role = new IdentityRole(roleName);
                roleManager.Create(role);
            }

            // Create a user
            var userEmail = "admin@mvc.com";
            var userPassword = "Abcd@1234";
            var user = new ApplicationUser { UserName = userEmail, Email = userEmail };
            var result = userManager.Create(user, userPassword);

            // Assign the user to the role
            if (result.Succeeded)
            {
                userManager.AddToRole(user.Id, roleName);
            }
        }
        }
}