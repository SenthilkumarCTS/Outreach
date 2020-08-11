using MemberOutReachSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace MemberOutReachSystem.Data
{
    public class OutreachDbContext : DbContext
    {
        public OutreachDbContext(DbContextOptions<OutreachDbContext> options) :base(options)
        {

        }

        public DbSet<CallTrackDetail> callTrackDetails { get; set; }  

        public DbSet<AssessmentHistory> assessmentDetails { get; set; }

        public DbSet<QuestionOptionMapping> QuestionOptions { get; set; }
        
        public DbSet<LookUpData> userLookUpDatas { get; set; }


        public DbSet<MOS_CALL_TRACK_DETAIL_BASE> MOS_CALL_TRACK_DETAIL_BASE { get; set; }

        public DbSet<MOS_ASSESSMENT_DETAILS_BASE> MOS_ASSESSMENT_DETAILS_BASE { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<AssessmentHistory>().HasNoKey();
            modelBuilder.Entity<LookUpData>().HasNoKey();
        }

    }


}
