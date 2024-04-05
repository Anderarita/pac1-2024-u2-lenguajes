using ExamenUnidad2.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamenUnidad2.Database
{
    public class IMCDbContext : IdentityDbContext<IdentityUser>
    {
        public IMCDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<IMCEntity> IMC { get; set; }
    }
}
