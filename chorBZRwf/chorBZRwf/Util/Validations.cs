using chorbzr.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using chorbzr.DLInterface;

namespace chorBZRwf.Util

{
    internal class Validations
    {
        public bool ValidateNameAndCheckIfExists(string name, List<User> existingUsers)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty.");
                return false;
            }

            if (name.Length < 3)
            {
                Console.WriteLine("Name must be at least 3 characters long.");
                return false;
            }

            if (!Regex.IsMatch(name, @"^[A-Za-z]+$"))
            {
                Console.WriteLine("Name must contain only alphabets.");
                return false;
            }

            foreach (User user in existingUsers)
            {
                if (user.getName().Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("User with this name already exists. Please choose a different name.");
                    return false; 
                }
            }

            return true; 
        }




        public static bool ValidateRole(string role)
        {
            if (string.IsNullOrEmpty(role))
            {
                Console.WriteLine("Role cannot be empty.");
                return false;
            }

            if (!Regex.IsMatch(role, @"^(seller|customer)$"))
            {
                Console.WriteLine("Role must be either 'seller' or 'customer'.");
                return false;
            }

            return true;
        }

        public bool ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Password cannot be empty.");
                return false;
            }

            if (password.Length < 6)
            {
                Console.WriteLine("Password must be at least 6 characters long.");
                return false;
            }

            if (Regex.IsMatch(password, @"\W"))
            {
                Console.WriteLine("Password cannot contain spaces or symbols.");
                return false;
            }

            return true; 
        }

        public bool validationCheck(string name)
        {
            string nameCheck = @"^ [A - Za - z] +$";
            if (Regex.IsMatch(nameCheck, name))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public string findUser(string name, string password, List<User> users)
        {
            foreach (User user in users)
            {
                if (user.getName() == name && user.getPassword() == password)
                {
                    return user.getRole();
                }
            }
            return null;
        }

        public User giveUser(string name, List<User> users)
        {
            foreach (User user in users)
            {
                if (user.getName() == name)
                {
                    return user;
                }
            }
            return null;
        }


        public (bool exists, string errorMessage) CheckIfProductNameExists(string name, List<ProductBL> existingProducts)
        {
            if (existingProducts.Any(p => p.getName().Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                return (true, "A product with this name already exists.");
            }
            else
            {
                return (false, null);
            }
        }

        public ProductBL GetProductByNameAndSeller(string name, string seller, List<ProductBL> existingProducts)
        {
            ProductBL product = existingProducts.FirstOrDefault(p => p.getName().Equals(name, StringComparison.OrdinalIgnoreCase) && p.getSeller().Equals(seller, StringComparison.OrdinalIgnoreCase));

            return product;
        }



        public (bool isValid, int result, string errorMessage) ValidateAndConvertToInt(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return (false, 0, "Input string cannot be empty.");
            }

            if (!input.All(char.IsDigit))
            {
                return (false, 0, "Input string must contain only digits.");
            }

            int parsedValue;
            if (!int.TryParse(input, out parsedValue))
            {
                return (false, 0, "Failed to convert input string to integer.");
            }

            return (true, parsedValue, null);
        }

        public (bool isValid, string errorMessage) validateRole(string role)
        {
            if (string.IsNullOrEmpty(role))
            {
                return (false, "Role cannot be empty.");
            }

            string trimmedRole = role.Trim().ToLower();

            if (trimmedRole != "copy" && trimmedRole != "original")
            {
                return (false, "Invalid role. Role must be either 'seller' or 'customer'.");
            }

            return (true, null);
        }

        public bool ValidateString(string input)
        {
            
            string pattern = "[,\x00]";

            if (Regex.IsMatch(input, pattern))
            {
                return false; 
            }
            else
            {
                return true; 
            }
        }


    }
}
