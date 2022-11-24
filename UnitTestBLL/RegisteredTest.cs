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
    public class RegisteredTest
    { 
        private Mock<IOrderDal> orderDal;
        private Mock<IShoesDal> shoesDal;
        private Registered reg;
        private List<ShoesDTO> shoess = new List<ShoesDTO>();
        private ShoesDTO shoes = new ShoesDTO
        {
            ShoeName = "test",
            Color = "test",
            Price=12,
            Size=37,
        };
        private List<OrderDTO> orders = new List<OrderDTO>();
        private OrderDTO order = new OrderDTO
        {
            UserID = 1,
            ShoeID=1,
            OrderDate=DateTime.Today,
            Price=10,
            Quantity=1,
        };

        [SetUp]
        public void Setup()
        {
            orderDal = new Mock<IOrderDal>(MockBehavior.Strict);
            shoesDal = new Mock<IShoesDal>(MockBehavior.Strict);
            reg = new Registered(orderDal.Object,shoesDal.Object);
        }
        [Test]
        public void GetAllShoesTest()
        {
            shoess.Add(shoes);
            shoesDal.Setup(d => d.GetAllShoes()).Returns(shoess);
            var res = reg.GetShoes();
            Assert.IsTrue(shoess.Contains(shoes) == res.Contains(shoes));
        }
        [Test]
        public void GetUserOrdersTest()
        {
            int id = 1;
            orders.Add(order);
            orderDal.Setup(d => d.GetUserOrders(id)).Returns(orders);
            var res = reg.GetUserOrders(id);
            Assert.IsTrue(orders.Contains(order) == res.Contains(order));
        }
        //[Test]
        /*public void CreateOrderTest()
        {
            orderDal.Setup(d => d.CreateOrder(order)).Returns(order);
            var res = reg.CreateOrder(order);
            Assert.IsTrue(res);
        }*/
        [Test]
        public void BuyTest()
        {
            int shoesid = 1;
            int userid = 1;
            int quantity = 1;
            float price = 10;
            bool r = true;
            var res = reg.Buy(shoesid, userid, quantity, price);
            Assert.AreEqual(r,res);
        }

    }
}
