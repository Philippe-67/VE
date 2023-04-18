using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VE.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<VE.Models.Voitures>? Voitures { get; set; }
        public DbSet<VE.Models.Reparations>? Reparations { get; set; }
        public DbSet<VE.Models.Interventions>? Interventions { get; set; }
        public DbSet<VE.Models.Reparation_Intervention>? Reparation_Intervention { get; set; }
    }
    
}