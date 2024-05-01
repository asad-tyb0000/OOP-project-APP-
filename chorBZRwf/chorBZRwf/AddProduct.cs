using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using chorbzr;
using chorbzr.DL.FH;
using chorbzr.DL.DB;
using chorbzr.BL;
using chorbzr.DLInterface;
using System.Web.UI;
using chorBZRwf.Util;


namespace chorBZRwf
{
    public partial class AddProduct : Form
    {
        public string choice;
        Validations validation = new Validations();
        productInterface inter;
        public string seller;

        public AddProduct(string choice , string seller)
        {
            InitializeComponent();
            this.choice = choice;
            this.seller = seller;
            initializeInterface();
            showCombo();
        }

        private void showCombo()
        {
            catcombo.Items.Clear();

            catcombo.Items.Add("original");
            catcombo.Items.Add("copy");
            catcombo.SelectedIndex = 0;
        }

        private void initializeInterface()
        {
            if (choice == "1")
            {
                inter = new productDL();
            }
            else if (choice == "2")
            {
                inter = new productDB();
            }
        }

        private void catcombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void addProduct()
        {
            List<ProductBL> pro = inter.Products();
            string name = nameText.Text;
            var check = validation.CheckIfProductNameExists( name , pro);
            if(check.exists)
            {
                MessageBox.Show("Product already exists");
                
            }
            else
            {
                string price = priceText.Text;
                var validationResult = validation.ValidateAndConvertToInt(price);
                if (validationResult.isValid)
                {
                    int parsedInteger = validationResult.result;
                    string quantity = qunatityText.Text;
                    
                    var validationResult1 = validation.ValidateAndConvertToInt(quantity);
                    if (validationResult1.isValid)
                    {
                        int parsedInteger1 = validationResult1.result;
                        string category = catcombo.SelectedText.ToString();
                        string description = descriptionText.Text;
                        bool isValid = validation.ValidateString(description);
                        if (isValid)
                        {
                            ProductBL product = new ProductBL(seller, name, Convert.ToString(parsedInteger), Convert.ToString(parsedInteger1), category, description);
                            inter.addProduct(product);
                            MessageBox.Show("product added successfully");
                        }
                        else
                        {
                            MessageBox.Show("Invalid string. String cannot contain comma or \\0.");
                        }
                        
                    }
                    else
                    {
                        string errorMessage = validationResult.errorMessage;
                        MessageBox.Show("Input is not valid. Error message: " + errorMessage);
                    }
                }
                else
                {
                    string errorMessage = validationResult.errorMessage;
                    MessageBox.Show("Input is not valid. Error message: " + errorMessage);
                }
            }
            
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            addProduct();
        }
    }
}
