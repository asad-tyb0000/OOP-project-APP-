using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoConsole.BL
{
    public class User
    {
        private int UserId;
        private string UserName;
        private string Password;
        private string Role;
        private long Cnic;
        private DateTime DateCreated;
        public User(int userId, string userName, string password, string role, long cnic, DateTime dateCreated)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
            Role = role;
            Cnic = cnic;
            DateCreated = dateCreated;
        }


        public object GetAllPropertiesObject()
        {
            return new
            {
                UserId = this.UserId,
                UserName = this.UserName,
                Password = this.Password,
                Role = this.Role,
                Cnic = this.Cnic,
                DateCreated = this.DateCreated
            };
        }
        public void UpdateAllProperties(User updatedUser)
        {
            UserId = updatedUser.UserId;
            UserName = updatedUser.UserName;
            Password = updatedUser.Password;
            Role = updatedUser.Role;
            Cnic = updatedUser.Cnic;
            DateCreated = updatedUser.DateCreated;
        }
        public int GetUserId()
        {
            return UserId;
        }

        public void SetUserId(int userId)
        {
            UserId = userId;
        }

        public string GetUserName()
        {
            return UserName;
        }

        public void SetUserName(string userName)
        {
            UserName = userName;
        }

        public string GetPassword()
        {
            return Password;
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public string GetRole()
        {
            return Role;
        }

        public void SetRole(string role)
        {
            Role = role;
        }

        public long GetCnic()
        {
            return Cnic;
        }

        public void SetCnic(long cnic)
        {
            Cnic = cnic;
        }

        public DateTime GetDateCreated()
        {
            return DateCreated;
        }

        public void SetDateCreated(DateTime dateCreated)
        {
            DateCreated = dateCreated;
        }


        public static bool ValidateInput(User user)
        {
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(user.Password) || user.Password.Length < 6)
            {
                return false;
            }
            if (user.Role.ToLower() != "admin" && user.Role.ToLower() != "customer")
            {
                return false;
            }

            if (user.Cnic.ToString().Length != 13)
            {
                return false;
            }
            if (user.DateCreated > DateTime.Now)
            {
                return false;
            }
            return true;
        }
    }
}
