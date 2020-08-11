using MemberOutReachSystem.Data;
using MemberOutReachSystem.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemberOutReachSystem.Business
{
    public class CallTrackRepository
    {
        private const string SP_CALLTRACK_DETAILS = "EXEC [dbo].[USP_MOS_CALLTRACKING_READ] " +  "@MEMBER_ID";

        private const string SP_CALLTRACK_LOOKUPDATA = "EXEC [dbo].[USP_CALLTRACK_LOOKUP_READ] ";
        public CallTrackRepository(OutreachDbContext outreachDbContext)
        {
            outreaachContext = outreachDbContext;
        }

        public OutreachDbContext outreaachContext { get; }


        public async Task<List<CallTrackDetail>> GetCallTrackDetails(string MemberId)
        {
            List<CallTrackDetail> CTDetails;

            try
            {
                string StoreProcName = SP_CALLTRACK_DETAILS;
                
                SqlParameter MemberID = new SqlParameter("@MEMBER_ID", MemberId);
                

                CTDetails = await outreaachContext.callTrackDetails.FromSqlRaw(StoreProcName, MemberID).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception",ex);
            }
                       
            return CTDetails;
        }



        public async Task<List<LookUpData>> GetCallTrackLookUpData( )
        {
            List<LookUpData> CTLookUpData;
            try
            {
               
                CTLookUpData = await outreaachContext.userLookUpDatas.FromSqlRaw(SP_CALLTRACK_LOOKUPDATA).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception",ex);
            }

            return CTLookUpData;
        }

        public bool SaveCallTrack(MOS_CALL_TRACK_DETAIL_BASE callTrack)
        {
            try
            {
                outreaachContext.MOS_CALL_TRACK_DETAIL_BASE.Add(callTrack);
                outreaachContext.SaveChanges(true);

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception",ex);
            }

            return true;
        }

    }
}
