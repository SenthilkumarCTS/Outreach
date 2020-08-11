using MemberOutReachSystem.Data;
using MemberOutReachSystem.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberOutReachSystem.Business
{
    public class UserRepository : IUserRepository
    {
        private const string SP_LookUp_DETAILS = "[dbo].[USP_LOOKUP_DATA_READ]";
        public UserRepository(AppDbContext context)
        {
            Context = context;            
        }

        public AppDbContext Context { get; }

        public bool UserAuthentication(string UserName, string Password)
        {   

            IEnumerable<MOS_USER_DETAILS_BASE> userDetails =  Context.MOS_USER_DETAILS_BASE;

            bool isAuthenticated = (userDetails.Any(a => a.USERNAME == UserName && a.PASSWORD == Password));

            return isAuthenticated;
        }

        public bool UserRegistration(MOS_USER_DETAILS_BASE UserDetail)
        {
            try
            {
                 Context.MOS_USER_DETAILS_BASE.Add(UserDetail);
                 Context.SaveChanges(true);
              
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Exception",ex);
            }

            return true;
        }

        public async Task<List<LookUpData>> GetLookUpData()
        {
            List<LookUpData> userLookUpData;

            try
            {                
                userLookUpData = await Context.UserLookUpData.FromSqlRaw(SP_LookUp_DETAILS).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception",ex);
            }

            return userLookUpData;
        }
    }
}
