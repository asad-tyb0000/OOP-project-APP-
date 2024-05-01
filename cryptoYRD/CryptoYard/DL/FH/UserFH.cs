using CryptoConsole.BL;
using CryptoConsole.DLInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoConsole.DL.FH
{
    public class UserFH : IUserDL
    {
        private static string filePath = ConnectionFH.GetUsersFilePath();

        public void CreateUser(User user)
        {
            if (!File.Exists(filePath))
            {
                using (StreamWriter writer = File.CreateText(filePath))
                {
                    writer.WriteLine($"{user.GetUserId()},{user.GetUserName()},{user.GetRole()},{user.GetPassword()},{user.GetCnic()},{user.GetDateCreated()}");
                }
            }
            else
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine($"{user.GetUserId()},{user.GetUserName()},{user.GetRole()},{user.GetPassword()},{user.GetCnic()},{user.GetDateCreated()}");
                }
            }
        }
        private User ParseUserDetails(string[] userDetails)
        {
            if (userDetails.Length >= 6)
            {
                int userId = int.Parse(userDetails[0]);
                string userName = userDetails[1];
                string role = userDetails[2];
                string password = userDetails[3];
                long cnic = long.Parse(userDetails[4]);
                DateTime dateCreated = DateTime.Parse(userDetails[5]);

                return new User(userId, userName, password, role, cnic, dateCreated);
            }
            return null;
        }

        public User GetUserById(int userId)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] userDetails = line.Split(',');
                    if (int.TryParse(userDetails[0], out int id) && id == userId)
                    {
                        return ParseUserDetails(userDetails);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            try
            {
                if (!File.Exists(filePath))
                {

                    return users;
                }

                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] userDetails = line.Split(',');
                    User user = ParseUserDetails(userDetails);
                    if (user != null)
                    {
                        users.Add(user);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return users;
        }

        public void UpdateUser(User user)
        {
            List<User> users = GetAllUsers();
            int index = users.FindIndex(u => u.GetUserId() == user.GetUserId());
            if (index != -1)
            {
                users[index] = user;
                UpdateUsersFile(users);
            }
            else
            {

            }
        }

        public void DeleteUser(int userId)
        {
            List<User> users = GetAllUsers();
            users.RemoveAll(u => u.GetUserId() == userId);
            UpdateUsersFile(users);
        }
        private void UpdateUsersFile(List<User> users)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (User user in users)
                    {
                        writer.WriteLine($"{user.GetUserId()},{user.GetUserName()},{user.GetRole()},{user.GetPassword()},{user.GetCnic()},{user.GetDateCreated()}");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
