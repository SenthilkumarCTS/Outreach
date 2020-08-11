using MemberOutReachSystem.API.Controllers;
using MemberOutReachSystem.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace MemberOutreachSystem.Test
{
    [TestFixture]
    public class CallHistoryTest
    {

        [Test]
        public async Task Get_Mbr_CallHistory_Exists()
        {
            DbContextOptionsBuilder<OutreachDbContext> option = new DbContextOptionsBuilder<OutreachDbContext>().UseSqlServer("server=CTSDOTNET11;database=OutreachSystem;Trusted_Connection=true");
            OutreachDbContext mbrCntxt = new OutreachDbContext(option.Options);
            //Arrange
            var controller = new CallTrackController(mbrCntxt);

            //Act
            var result = await controller.Get("MBR01");

            //Assert
            Assert.IsTrue(result.Count() > 20);

        }

    }
}
