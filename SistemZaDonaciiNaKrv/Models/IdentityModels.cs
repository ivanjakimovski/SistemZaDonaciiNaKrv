using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SistemZaDonaciiNaKrv.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public bool hasDonated { get; set; }
        public string bloodType { get; set; }

        public virtual List<DonationModel> allDonations { get; set; }

        public virtual List<DonatorFormModel> allDonatorForms { get; set; }
        public ApplicationUser()
        {
            this.allDonations = new List<DonationModel>();
        }
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
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<SistemZaDonaciiNaKrv.Models.DonatorFormModel> DonatorFormModels { get; set; }

        public System.Data.Entity.DbSet<SistemZaDonaciiNaKrv.Models.BloodTypeModel> BloodTypeModels { get; set; }

        public System.Data.Entity.DbSet<SistemZaDonaciiNaKrv.Models.DonationModel> DonationModels { get; set; }
    }
}