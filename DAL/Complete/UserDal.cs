using AutoMapper;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DAL.Complete
{
    public class UserDal : IUserDal
    {
        private readonly IMapper _mapper;
        public UserDal(IMapper mapper)
        {
            _mapper = mapper;
        }
        public UserDTO CreateUser(string firstName, string lastName, string login, string password, string keyword, bool gender, string address, string email, string phonenumber, string bankcard)
        {
            using (var entities = new shoefactoryEntities())
            {
                if (entities.Users.Any(u => u.Login == login))
                {
                    throw new Exception("User already exists!");
                }
                Guid salt = Guid.NewGuid();
                var user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Login = login,
                    Salt = salt,
                    Keyword = keyword,
                    IsFemale = gender,
                    Address = address,
                    Email = email,
                    PhoneNumber = phonenumber,
                    BankCard = bankcard,                   
                    Passsword = hash(password, salt.ToString()),
                    RowInsertTime = System.DateTime.Now,
                    RowUpdateTime = System.DateTime.Now
                };
                entities.Users.Add(user);
                entities.SaveChanges();
                return _mapper.Map<UserDTO>(user);
            }
        }
        public List<UserDTO> GetAllUsers()
        {
            using(var entities= new shoefactoryEntities())
            {
                var users = entities.Users.ToList();
                return _mapper.Map<List<UserDTO>>(users);
            }
        }
        public UserDTO UpdateUserByID(UserDTO user, int id)
        {
            using (var entites = new shoefactoryEntities())
            {
                var userInDB = _mapper.Map<User>(user);
                userInDB = entites.Users.SingleOrDefault(x => x.UserID == id);
                if (userInDB != null)
                {
                    userInDB.RowUpdateTime = DateTime.Now;
                    userInDB.FirstName= user.FirstName;
                    userInDB.LastName = user.LastName;
                    userInDB.Login = user.Login;
                    userInDB.Passsword = user.Passsword;
                    userInDB.Keyword = user.Keyword;
                    userInDB.IsFemale = user.IsFemale;
                    userInDB.Address = user.Address;
                    userInDB.Email = user.Email;
                    userInDB.PhoneNumber = user.PhoneNumber;
                    userInDB.BankCard = user.BankCard;
                    entites.SaveChanges();
                }
                return _mapper.Map<UserDTO>(userInDB);
            }
        }
        public UserDTO GetUserByID(int id)
        {
            using (var entities = new shoefactoryEntities())
            {
                var userID = entities.Users.Select(x => x.UserID).ToList();
                var user = entities.Users.Where(x => userID.Contains(id)).ToList();
                return _mapper.Map<UserDTO>(user[id-1]);
            }
        }
        public UserDTO DeleteUserByID(int id)
        {
            using (var entites = new shoefactoryEntities())
            {
                var usersInDB = entites.Users.SingleOrDefault(x => x.UserID == id);
                if (usersInDB != null)
                {
                    entites.Users.Remove(usersInDB);
                    entites.SaveChanges();
                }
                return _mapper.Map<UserDTO>(usersInDB);
            }
        }
        public  byte[] hash(string password, string salt)
        {
            var alg = SHA512.Create();
            return alg.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
        }
        public UserDTO GetUserByLogin(string login)
        {
            using (var entities = new shoefactoryEntities())
            {
                var found = entities.Users.SingleOrDefault(d => d.Login == login);
                return _mapper.Map<UserDTO>(found);
            }
        }
        public bool Login(string username, string password)
        {
            using (var ent = new shoefactoryEntities())
            {
                UserDTO user = _mapper.Map<UserDTO>(ent.Users.FirstOrDefault(u => u.Login == username));
                return user != null && user.Passsword.SequenceEqual(hash(password, user.Salt.ToString()));
            }
        }
    }
}
