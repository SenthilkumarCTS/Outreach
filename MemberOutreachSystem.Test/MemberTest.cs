using Microsoft.Extensions.Configuration;
using MemberOutReachSystem.API.Controllers;
using MemberOutReachSystem.Business;
using MemberOutReachSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace MemberOutreachSystem.Test
{
    [TestFixture]
    public class MemberTest
    {
        

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public async Task Get_Member_Exist_In_DB()
        {
            //Arrange
            DbContextOptionsBuilder<MemberDbContext> option = new DbContextOptionsBuilder<MemberDbContext>().UseSqlServer("server=CTSDOTNET11;database=MemberManagement;Trusted_Connection=true");
            MemberDbContext mbrCntxt = new MemberDbContext(option.Options);            
            var controller = new MemberController(mbrCntxt);

            //Act
            var result = await controller.Get();

            //Assert
            Assert.IsTrue(result.Count()>0);

        }

        [Test]
        public async Task Get_Member_Count_In_DB()
        {
            //Arrange
            DbContextOptionsBuilder<MemberDbContext> option = new DbContextOptionsBuilder<MemberDbContext>().UseSqlServer("server=CTSDOTNET11;database=MemberManagement;Trusted_Connection=true");
            MemberDbContext mbrCntxt = new MemberDbContext(option.Options);
            var controller = new MemberController(mbrCntxt);

            //Act
            var result = await controller.Get();

            //Assert
            Assert.AreEqual(26,result.Count());

        }
    }
}