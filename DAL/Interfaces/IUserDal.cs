using DTO;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IUserDal
    {
        List<UserDTO> GetAllUsers();
        UserDTO CreateUser(UserDTO user);
        UserDTO UpdateUserByID(UserDTO user, int id);
        UserDTO DeleteUserByID(int id);
    }
}
