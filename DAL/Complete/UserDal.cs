using AutoMapper;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Complete
{
    public class UserDal : IUserDal
    {
        private readonly IMapper _mapper;
        public UserDal(IMapper mapper)
        {
            _mapper = mapper;
        }
        public UserDTO CreateUser(UserDTO user)
        {
            using (var entites = new shoefactoryEntities())
            {
                var userInDB = _mapper.Map<User>(user);
                userInDB.RowInsertTime = DateTime.Now;
                userInDB.RowUpdateTime = DateTime.Now;
                entites.Users.Add(userInDB);
                entites.SaveChanges();
                return _mapper.Map<UserDTO>(userInDB);
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
                    userInDB.Password = user.Password;
                    userInDB.Keyword = user.Keyword;
                    userInDB.Gender = user.Gender;
                    userInDB.Address = user.Address;
                    userInDB.Email = user.Email;
                    userInDB.PhoneNumber = user.PhoneNumber;
                    userInDB.BankCard = user.BankCard;
                    entites.SaveChanges();
                }
                return _mapper.Map<UserDTO>(userInDB);
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
    }
}
