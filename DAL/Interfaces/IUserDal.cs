using DTO;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IUserDal
    {
        List<UserDTO> GetAllUsers();
        UserDTO CreateUser(string firstName, string lastName, string login, string password, string keyword, bool gender, string address, string email, string phonenumber, string bankcard);
        UserDTO UpdateUserByID(UserDTO user, int id);
        UserDTO GetUserByID(int id);
        UserDTO DeleteUserByID(int id);
        UserDTO GetUserByLogin(string username);
        byte[] hash(string password, string salt);
        bool Login(string username, string password);
    }
}
