using MemberOutReachSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace MemberOutReachSystem.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
            
        }
        public DbSet<MOS_USER_DETAILS_BASE> MOS_USER_DETAILS_BASE { get; set; }

        public DbSet<LookUpData> UserLookUpData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<LookUpData>().HasNoKey();
        }
    }
}
