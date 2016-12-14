using Microsoft.AspNet.Identity.EntityFramework;

namespace ETFSjedniceWeb.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<ETFSjedniceWeb.Models.ZAPISNIK> ZAPISNIKs { get; set; }

        public System.Data.Entity.DbSet<ETFSjedniceWeb.Models.DNEVNI_RED> DNEVNI_RED { get; set; }

        public System.Data.Entity.DbSet<ETFSjedniceWeb.Models.PRILOG> PRILOGs { get; set; }

        public System.Data.Entity.DbSet<ETFSjedniceWeb.Models.TIP_GLASA> TIP_GLASA { get; set; }

        public System.Data.Entity.DbSet<ETFSjedniceWeb.Models.STATUS_STAVKE_DNEVNOG_REDA> STATUS_STAVKE_DNEVNOG_REDA { get; set; }

        public System.Data.Entity.DbSet<ETFSjedniceWeb.Models.STAVKA_DNEVNOG_REDA> STAVKA_DNEVNOG_REDA { get; set; }

        public System.Data.Entity.DbSet<ETFSjedniceWeb.Models.UCESNIK> UCESNIKs { get; set; }

        public System.Data.Entity.DbSet<ETFSjedniceWeb.Models.GLA> GLAs { get; set; }

        public System.Data.Entity.DbSet<ETFSjedniceWeb.Models.STATUS_SJEDNICE> STATUS_SJEDNICE { get; set; }

        //public System.Data.Entity.DbSet<ETFSjedniceWeb.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}