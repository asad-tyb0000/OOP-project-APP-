using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoConsole.BL
{
    public class Admin : User
    {
        // Constructor
        public Admin(int userId, string userName, string password, string role, long cnic, DateTime dateCreated)
            : base(userId, userName, password, role, cnic, dateCreated)
        {
            // Additional initialization specific to Admin if needed
        }

        // Additional properties and methods specific to Admin can be added here
        // For example:
        // - Properties for admin-specific data
        // - Methods for administrative functionalities
    }
}
