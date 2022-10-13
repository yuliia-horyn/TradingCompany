using AutoMapper;
using DAL.Complete;
using NUnit.Framework;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.InteropServices;

namespace UnitTestDAL
{
    [TestFixture]
    [Transaction(TransactionOption.RequiresNew),ComVisible(true)]
    public class UnitTest1
    {
        private IMapper _mapper;
        [OneTimeSetUp]
        public void SetupOnce()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(UserDal).Assembly)
                );
            _mapper= config.CreateMapper();
        }
        [Test]
        public void TestMethod1()
        {
            
            var userDal = new UserDal(_mapper);
            var users = userDal.GetAllUsers();
            Assert.IsNotNull(users);
            Assert.Contains("Anna",users.Select(u=>u.FirstName).ToList());
        }
    }
}
