using MemberOutReachSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace MemberOutReachSystem.Data
{
    public class MemberDbContext: DbContext
    {
        
        public MemberDbContext(DbContextOptions<MemberDbContext> options) : base(options)
        {

        }

        public DbSet<MemberDetail> memberDetails { get; set; }
        public DbSet<MOS_MEMBER_DETAILS_BASE> MOS_MEMBER_DETAILS_BASE { get; set; }
         
    }
}
