using MemberOutReachSystem.Data;
using MemberOutReachSystem.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemberOutReachSystem.Business
{
    public interface IMemberRepository
    {
        MemberDbContext Context { get; }

        Task<List<MemberDetail>> GetMemberDetails();
        void UploadMemberDetails(List<MOS_MEMBER_DETAILS_BASE> MemberDetails);
    }
}