using DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IAuthentication
    {
        bool Login(string username, string password);
        bool Register(string firstName, string lastName, string login, string password, string keyword, bool gender, string address, string email, string phoneNumber, string bankcard);
        bool ResetPassword(string login, string keyword, string newpassword);
        int GetUserByLogin(string username);
        UserDTO GetUserByID(int id);
        List<UserDTO> GetUsers();
    }
}
