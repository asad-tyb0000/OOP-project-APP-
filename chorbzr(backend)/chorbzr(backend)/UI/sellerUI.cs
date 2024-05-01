using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chorbzr.DLInterface;
using chorbzr.BL;
using chorbzr.DL.DB;
using chorbzr.DL.FH;
using chorbzr.Util;
using System.Net.Http.Headers;

namespace chorbzr_backend_.UI
{
    internal class sellerUI
    {
        public string choice;
        public string seller;
        productInterface pro;
        Validation validation = new Validation();
        public sellerUI(string choice, string seller)
        {
            this.choice = choice;
            this.seller = seller;
        }


        public void Start()
        {
            bool exit = false;
            if (choice == "1")
            {
                pro = new productDL();
            }
            else
            {
                pro = new productDB();
            }

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Remove product");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. View Product");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        RemoveProduct();
                        break;
                    case "3":
                        UpdateProduct();
                        break;
                    case "4":
                        viewProducts();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }


        }

        public void AddProduct()
        {
            Console.Clear();
            Console.WriteLine("Enter product name : ");
            string name = Console.ReadLine();
            var check = validation.CheckIfProductNameExists(name, pro.Products());
            if (check.exists)
            {
                Console.WriteLine(check.errorMessage);
            }
            else
            {
                Console.WriteLine("Enter Price : ");
                string price = Console.ReadLine();
                var validationResult = validation.ValidateAndConvertToInt(price);
                if (validationResult.isValid)
                {
                    int parsedInteger = validationResult.result;
                    Console.WriteLine("Enter quantity : ");
                    string quantity = Console.ReadLine();
                    var validationResult1 = validation.ValidateAndConvertToInt(quantity);
                    if (validationResult1.isValid)
                    {
                        int parsedInteger1 = validationResult1.result;
                        Console.WriteLine("Enter the category(copy or original : )");
                        string category = Console.ReadLine();
                        var validationResult2 = validation.validateRole(category);
                        if (validationResult2.isValid)
                        {
                            Console.WriteLine("Enter the description : ");
                            string description = Console.ReadLine();
                            bool isValid = validation.ValidateString(description);
                            if (isValid)
                            {
                                ProductBL product = new ProductBL(seller, name, Convert.ToString(parsedInteger), Convert.ToString(parsedInteger1), category, description);
                                pro.addProduct(product);
                            }
                            else
                            {
                                Console.WriteLine("Invalid string. String cannot contain comma or \\0.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid role. Error message: " + validationResult.errorMessage);
                        }
                    }
                    else
                    {
                        string errorMessage = validationResult.errorMessage;
                        Console.WriteLine("Input is not valid. Error message: " + errorMessage);
                    }
                }
                else
                {
                    string errorMessage = validationResult.errorMessage;
                    Console.WriteLine("Input is not valid. Error message: " + errorMessage);
                }
            }
        }


        public void RemoveProduct()
        {
            Console.Clear();
            Console.WriteLine("Enter the product name : ");
            string name = Console.ReadLine();
            ProductBL existingProduct = validation.GetProductByNameAndSeller(name, seller, pro.Products());
            if (existingProduct != null)
            {
                pro.DeleteProduct(existingProduct);
            }
            else
            {
                Console.WriteLine("Product not found.");
            }

        }

        public void RemoveProduct(string name)
        {
            Console.Clear();
            ProductBL existingProduct = validation.GetProductByNameAndSeller(name, seller, pro.Products());
            if (existingProduct != null)
            {
                pro.DeleteProduct(existingProduct);
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }



        public void UpdateProduct()
        {
            Console.Clear();
            Console.WriteLine("Enter name : ");
            string name = Console.ReadLine();
            var check = validation.CheckIfProductNameExists(name, pro.Products());
            if (check.exists)
            {
                ProductBL existingProduct = validation.GetProductByNameAndSeller(name, seller, pro.Products());
                Console.WriteLine("Enter the new price : ");
                string price = Console.ReadLine();
                var validationResult = validation.ValidateAndConvertToInt(price);
                if (validationResult.isValid)
                {
                    int parsedInteger = validationResult.result;
                    Console.WriteLine("Enter the new quantity : ");
                    string quantity = Console.ReadLine();
                    var validationResult1 = validation.ValidateAndConvertToInt(quantity);
                    if (validationResult1.isValid)
                    {
                        int parsedInteger1 = validationResult1.result;
                        Console.WriteLine("Enter the new category(copy or original) : ");
                        string category = Console.ReadLine();
                        var validationResult2 = validation.validateRole(category);
                        if (validationResult2.isValid)
                        {
                            Console.WriteLine("Enter the new description : ");
                            string description = Console.ReadLine();
                            bool isValid = validation.ValidateString(description);
                            if (isValid)
                            {

                                ProductBL product = new ProductBL(seller, name, Convert.ToString(parsedInteger), Convert.ToString(parsedInteger1), category, description);
                                pro.UpdateProduct(existingProduct, product);
                            }
                            else
                            {
                                Console.WriteLine("Invalid string. String cannot contain comma or \\0.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid role. Error message: " + validationResult.errorMessage);
                        }
                    }
                    else
                    {
                        string errorMessage = validationResult.errorMessage;
                        Console.WriteLine("Input is not valid. Error message: " + errorMessage);
                    }
                }
                else
                {
                    string errorMessage = validationResult.errorMessage;
                    Console.WriteLine("Input is not valid. Error message: " + errorMessage);
                }
            }
            else
            {
                Console.WriteLine(check.errorMessage);
            }

        }


        public void viewProducts()
        {
            Console.Clear();
            Console.WriteLine("Your Products : ");
            foreach (ProductBL product in pro.Products())
            {
                if (product.getSeller().Equals(seller, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Name : " + product.getName() + "   Price : " + product.getPrice() + "  Quantity : " + product.getQuantity() + "  Description : " + product.getDescription());
                }
            }
            Console.ReadKey();
        }


    }
}
