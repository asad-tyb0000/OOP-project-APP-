using System;
using System.Collections.Generic;
using CryptoConsole.BL;

namespace CryptoConsole.DLInterfaces
{
    public interface IUserDL
    {
        void CreateUser(User user);

        User GetUserById(int userId);

        List<User> GetAllUsers();

        void UpdateUser(User user);

        void DeleteUser(int userId);
    }
}
