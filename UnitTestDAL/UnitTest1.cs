using AutoMapper;
using DAL.Complete;
using DTO;
using NUnit.Framework;
using System.Configuration;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.InteropServices;

namespace UnitTestDAL
{
    [TestFixture]
    [Transaction(TransactionOption.RequiresNew),ComVisible(true)]
    public class UserDalTest:ServicedComponent
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
        public void UserIsInDB()
        {
            //Arange
            var userDal = new UserDal(_mapper);
            //Act
            var users = userDal.GetAllUsers();
            //Assert
            Assert.IsNotNull(users);
            Assert.Contains("Anna",users.Select(u=>u.FirstName).ToList());
        }
        [Test]
        public void CreateUserTest()
        {
            UserDal dal = new UserDal(_mapper);
            var result = dal.CreateUser(new UserDTO
            {
                FirstName = "Jane",
                LastName = "Brown",
                Login = "jannie",
                Password = "9071",
                Keyword = "moon",
                Gender = "women",
                Address = "871 West Brickell Street Hochelaga,QC H1W 9R5",
                Email = "jane27@gmail.com",
                PhoneNumber = "0967123455",
                BankCard = "2309 8175 4650 3028"
            });
            Assert.IsTrue(result.UserID != 0, "returned ID>0");
        }
        [Test]
        public void GetAllUsersTest()
        {
            UserDal dal = new UserDal(_mapper);
            var result = dal.CreateUser(new UserDTO
            {
                FirstName="Jane",
                LastName="Brown",
                Login="jannie",
                Password="9071",
                Keyword="moon",
                Gender="women",
                Address= "871 West Brickell Street Hochelaga,QC H1W 9R5",
                Email="jane27@gmail.com",
                PhoneNumber="0967123455",
                BankCard="2309 8175 4650 3028"
            });
            var users = dal.GetAllUsers();
            Assert.AreEqual(1, users.Count(x => x.Keyword == "moon"));
        }
        [TearDown]
        public void TearDown()
        {
            if (ContextUtil.IsInTransaction)
            {
                ContextUtil.SetAbort();
            }
        }
    }
}
