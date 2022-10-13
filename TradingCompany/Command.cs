using AutoMapper;
using DAL.Complete;
using DTO;
using System;

namespace TradingCompany
{
    public class Command
    {
        static IMapper Mapper = SetupMapper();

        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(UserDal).Assembly)
                );
            return config.CreateMapper();
        }
        internal void CreateNewUser(string firstName, string lastName, string login, string password, string keyword, string gender, string address, string email, string phonenumber, string bankcard)
        {
            var dal = new UserDal(Mapper);
            var user = new UserDTO
            {
                FirstName = firstName,
                LastName = lastName,
                Login=login,
                Password=password,
                Keyword=keyword,
                Gender=gender,
                Address=address,
                Email=email,
                PhoneNumber=phonenumber,
                BankCard=bankcard
            };
            user = dal.CreateUser(user);
            Console.WriteLine($"New user ID = : {user.UserID}");
        }
        public void ReadAllUsers()
        {
            var dal = new UserDal(Mapper);
            var users = dal.GetAllUsers();
            Console.WriteLine($"UserID FirstName     LastName\t Gender \t\tAddress \t\t\t\t\tEmail" + $"                     PhoneNumber      BankCard           RowInsertTime         RowUpdateTime");
            foreach (var user in users)
            {
                Console.WriteLine(user.ToString());
            }
        }
        internal void UpdateUser(int id,string firstName, string lastName, string login, string password, string keyword, string gender, string address, string email, string phonenumber, string bankcard)
        {
            var dal = new UserDal(Mapper);
            var user = new UserDTO
            {
                FirstName = firstName,
                LastName = lastName,
                Login = login,
                Password = password,
                Keyword = keyword,
                Gender = gender,
                Address = address,
                Email = email,
                PhoneNumber = phonenumber,
                BankCard = bankcard
            };
            user = dal.UpdateUserByID(user, id);
            Console.WriteLine($"Update user ID : {user.UserID}");
        }
        internal void DeleteUser(int userId)
        {
            var dal = new UserDal(Mapper);
            Console.WriteLine($"Deleted user by ID= : {dal.DeleteUserByID(userId).UserID}");
        }
        internal void CreateNewShoes(string shoesName, int size, string color, float price)
        {
            var dal = new ShoesDal(Mapper);
            var shoes = new ShoesDTO
            {
                ShoeName = shoesName,
                Size = size,
                Color=color,
                Price=price
            };
            shoes = dal.CreateShoes(shoes);
            Console.WriteLine($"New shoes ID = : {shoes.ShoeID}");
        }
        public void ReadAllShoes()
        {
            var dal = new ShoesDal(Mapper);
            var users = dal.GetAllShoes();
            Console.WriteLine($"ShoesID \tShoesName                        \t\tSize    \tColor        \tPrice \t\tRowInsertTime           RowUpdateTime");
            foreach (var user in users)
            {
                Console.WriteLine(user.ToString());
            }
        }
        internal void UpdateShoes(int id,string shoesName, int size, string color, float price)
        {
            var dal = new ShoesDal(Mapper);
            var shoes = new ShoesDTO
            {
                ShoeName = shoesName,
                Size = size,
                Color = color,
                Price = price
            };
            shoes = dal.UpdateShoesByID(shoes,id);
            Console.WriteLine($"New shoes ID = : {shoes.ShoeID}");
        }
        internal void DeleteShoes(int shoesId)
        {
            var dal = new ShoesDal(Mapper);
            Console.WriteLine($"Deleted shoes by ID=  : {dal.DeleteShoesByID(shoesId).ShoeID}");
        }
        internal void CreateNewOrder(int shoesId, int userId, int quantity, DateTime orderdate, float price)
        {
            var dal = new OrderDal(Mapper);
            var order = new OrderDTO
            {
                ShoeID = shoesId,
                UserID = userId,
                Quantity = quantity,
                OrderDate = orderdate,
                Price=price
            };
            order = dal.CreateOrder(order);
            Console.WriteLine($"New order ID = : {order.OrderID}");
        }
        public void ReadAllOrders()
        {
            var dal = new OrderDal(Mapper);
            var users = dal.GetAllOrders();
            Console.WriteLine($"OrderID|ShoesID|UserID|Quantity|OrderDate|    |Price|            |RowInsertTime|        |RowUpdateTime|");
            foreach (var user in users)
            {
                Console.WriteLine(user.ToString());
            }

        }
        internal void UpdateOrders(int id,int shoesId, int userId, int quantity, DateTime orderdate, float price)
        {
            var dal = new OrderDal(Mapper);
            var order = new OrderDTO
            {
                ShoeID = shoesId,
                UserID = userId,
                Quantity = quantity,
                OrderDate = orderdate,
                Price = price
            };
            order = dal.UpdateOrderByID(order,id);
            Console.WriteLine($"Update order ID = : {order.OrderID}");
        }
        internal void DeleteOrder(int orderId)
        {
            var dal = new OrderDal(Mapper);
            Console.WriteLine($"Deleted order by ID=  : {dal.DeleteOrderByID(orderId).OrderID}");
        }
    }
}
