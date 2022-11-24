using BLL.Concrete;
using DAL.Interfaces;
using DTO;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace UnitTestBLL
{

    [TestFixture]
    public class AuthenticationTests
    {
        private Mock<IUserDal> userDal;
        private Authentication auth;
        private List<UserDTO> users= new List<UserDTO> ();
        private UserDTO user = new UserDTO
        {
            Login = "test",
            Passsword = Convert.FromBase64String("0000"),
            FirstName = "test",
            LastName = "test",
            Keyword = "test",
            IsFemale = true,
            Email = "test",
            Address = "test",
            PhoneNumber = "test",
            BankCard = "test",
        };
        
        [SetUp]
        public void Setup()
        {
            userDal = new Mock<IUserDal>(MockBehavior.Strict);
            auth = new Authentication(userDal.Object);
        }

        [Test]
        public void LoginTest()
        {
            string login = "ann_j";
            string password = "1313";
            userDal.Setup(d => d.Login(login, password)).Returns(true);
            var res = auth.Login(login, password);
            Assert.IsTrue(res);
        }
        [Test]
        public void RegisterTest()
        {
            string login = "test";
            string password = "0000";
            string firstName = "test";
            string lastName = "test";
            string keyword = "test";
            bool gender = true;
            string email = "test";
            string address = "test";
            string phoneNumber = "test";
            string bankcard = "test";
            userDal.Setup(d => d.CreateUser(firstName, lastName, login, password, keyword, gender, address, email, phoneNumber, bankcard)).Returns(user);
            var res = auth.Register(firstName, lastName, login, password, keyword, gender, address, email, phoneNumber, bankcard);
            Assert.IsTrue(res);
        }
        //[Test]
       /* public void ResetPasswordTest()
        {
            string login = "ann_j";
            string keyword= "apple";
            string password = "1313";
            userDal.Setup(d => d.UpdateUserByID(user, user.UserID)).Returns(user);
            var res = auth.ResetPassword(login, keyword, password);
            Assert.IsTrue(res);
        }*/

        [Test]
        public void GetUserByLoginTest()
        {           
            string login = "";
            userDal.Setup(d => d.GetUserByLogin(login)).Returns(user);
            var res = auth.GetUserByLogin(login);
            Assert.IsTrue(user.UserID.GetType()==res.GetType());
        }
        [Test]
        public void GetUserByIdTest()
        {
            int id = 1;
            userDal.Setup(d => d.GetUserByID(id)).Returns(user);
            var res = auth.GetUserByID(id);
            Assert.IsTrue(user.GetType() == res.GetType());
        }

        [Test]
        public void GetAllUsersTest()
        {
            users.Add(user);
            userDal.Setup(d => d.GetAllUsers()).Returns(users);
            var res = auth.GetUsers();
            Assert.IsTrue(users.Contains(user)==res.Contains(user));
        }
    }
}
