using MemberOutReachSystem.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemberOutReachSystem.Business
{
    public interface IUserRepository
    {

        public bool UserAuthentication(string UserName, string Password);

        public bool UserRegistration(MOS_USER_DETAILS_BASE UserDetail);

        public Task<List<LookUpData>> GetLookUpData();

    }
}
