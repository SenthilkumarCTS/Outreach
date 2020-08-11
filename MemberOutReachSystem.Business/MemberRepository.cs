using MemberOutReachSystem.Data;
using MemberOutReachSystem.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemberOutReachSystem.Business
{
    public class MemberRepository : IMemberRepository
    {
        private const string SP_MEMBER_DETAILS = "EXEC [DBO].[USP_MOS_MEMBER_DETAIL_READ]";

        public MemberRepository(MemberDbContext mbrContext)
        {

            Context = mbrContext;
        }


        public MemberDbContext Context { get; }


        public async Task<List<MemberDetail>> GetMemberDetails()
        {
            List<MemberDetail> MemberDetails;

            try
            {
                string StoreProcName = SP_MEMBER_DETAILS;
                MemberDetails = await Context.memberDetails.FromSqlRaw(StoreProcName).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception",ex);
            }

            return MemberDetails;
        }

        public void UploadMemberDetails(List<MOS_MEMBER_DETAILS_BASE> MemberDetails)
        {
            try
            {
                MemberDetails.ForEach(mbrDetail =>
                {
                    Context.MOS_MEMBER_DETAILS_BASE.Add(mbrDetail);
                    Context.SaveChanges(true);
                }
                );
                
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Exception",ex);
            }

        }


    }
}
