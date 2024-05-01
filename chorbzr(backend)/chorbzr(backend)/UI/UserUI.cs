using chorbzr.BL; 
using System;
using System.Collections.Generic;
using System.Linq;
using chorbzr.Util;
using chorbzr;
using chorbzr.DL.DB;
using chorbzr.DL.FH;
using System.Security.Cryptography.X509Certificates;
using chorbzr_backend_.UI;

namespace chorbzr.DLInterface
{
    public class UserSignUI
    { 
        public string choice1;
        UserInterface inter;
        Validation validation = new Validation();

        public UserSignUI()
        {
        }


        public void Start()
        {
            bool exit = false;
            Console.WriteLine("Store data by: 1. File 2. Database : ");
            choice1 = Console.ReadLine();
            if (choice1 == "1")
            {
                inter = new UserDL();
            }
            else
            {
                inter = new userDB();
            }


            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Sign In");
                Console.WriteLine("3. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        SignUp(inter);
                        break;
                    case "2":
                        SignIn(inter);
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }


        }


        public void SignIn(UserInterface users)
        {
            Console.Clear();
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your Password: ");
            string password = Console.ReadLine();
            string check = validation.findUser(name, password , users.getUsers());
            if(check == "seller")
            {
                sellerUI seller = new sellerUI(choice1,name);
                seller.Start();
            }
            else if(check == "customer")
            {
                Console.WriteLine("Welcome " + name + "!");
                Console.WriteLine("Your role is " + check);
            }
            else
            {
                Console.WriteLine("Not Found");
                Console.ReadKey();
            }
            
            
        }



   
        public void SignUp(UserInterface users)
        {
            Console.Clear();
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            bool nameCheck = validation.ValidateNameAndCheckIfExists(name, users.getUsers());
            if (!nameCheck)
            {
                return;
            }

            Console.Write("Enter your Password: ");
            string password = Console.ReadLine();
            bool passwordCheck = Validation.ValidatePassword(password);
            if (!passwordCheck)
            {
                return;
            }

            Console.Write("Enter your role: ");
            string role = Console.ReadLine();
            bool roleCheck = Validation.ValidateRole(role);
            if (!roleCheck)
            {
                return;
            }

            if (role == "seller")
            {
                User user = new Seller(name, password, role);
                inter.addUser(user);
            }
            else
            {
                User user = new Customer(name, password, role);
                inter.addUser(user);
            }
        }

    }
}
