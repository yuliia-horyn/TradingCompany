using BLL.Interfaces;
using DAL.Interfaces;
using DTO;
using System.Collections.Generic;

namespace BLL.Concrete
{
    public class Authentication: IAuthentication
    {
        private readonly IUserDal userDal;
        public Authentication(IUserDal userDal)
        {
            this.userDal = userDal;
        }
        public int GetUserByLogin(string username)
        {
            return userDal.GetUserByLogin(username).UserID;
        }
        public UserDTO GetUserByID(int id)
        {
            return userDal.GetUserByID(id);
        }
        public List<UserDTO> GetUsers()
        {
            return userDal.GetAllUsers();
        }
        public bool Login(string username, string password)
        {
            return userDal.Login(username, password);
        }
        public bool Register(string firstName, string lastName, string login, string password, string keyword, bool gender, string address, string email, string phoneNumber, string bankcard)
        {
            try
            {
                userDal.CreateUser(firstName, lastName, login, password, keyword, gender, address, email, phoneNumber, bankcard);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool ResetPassword(string login, string keyword, string newpassword)
        {
            var user = userDal.GetUserByLogin(login);
            if (user.Keyword== keyword)
            {
               var newPassword = userDal.hash(newpassword, user.Salt.ToString());
               user.Passsword = newPassword;
               this.userDal.UpdateUserByID(user, user.UserID);
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
