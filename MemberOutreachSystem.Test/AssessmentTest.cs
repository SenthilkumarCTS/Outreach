using MemberOutReachSystem.API.Controllers;
using MemberOutReachSystem.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace MemberOutreachSystem.Test
{
    [TestFixture]
    public class AssessmentTest
    {

        [Test]
        public async Task Check_Member_Assessment_History_Exist()
        {
            //Arrange
            DbContextOptionsBuilder<OutreachDbContext> option = new DbContextOptionsBuilder<OutreachDbContext>().UseSqlServer("server=CTSDOTNET11;database=MemberManagement;Trusted_Connection=true");
            OutreachDbContext mbrCntxt = new OutreachDbContext(option.Options);
            var controller = new AssessmentController(mbrCntxt);

            //Act
            var result = await controller.Get("MBR01");

            //Assert
            Assert.IsTrue(result.Count() > 0);

        }
    }
}
