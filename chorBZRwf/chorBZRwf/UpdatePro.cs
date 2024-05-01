using chorbzr.BL;
using chorbzr.DL.DB;
using chorbzr.DL.FH;
using chorbzr.DLInterface;
using chorBZRwf.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chorBZRwf
{
    public partial class UpdatePro : Form
    {
        public string choice;
        Validations validation = new Validations();
        productInterface inter;
        public string seller;
        public UpdatePro(string choice , string seller)
        {
            InitializeComponent();
            this.choice = choice;
            initializeInterface();
            this.seller = seller;
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

        public void updateProduct()
        {
            List<ProductBL> pro = inter.Products();
            string name = nameText.Text;
            var check = validation.CheckIfProductNameExists(name, pro);
            if (check.exists)
            {
                ProductBL existingProduct = validation.GetProductByNameAndSeller(name, seller, pro);
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
                        string category = catcombo.SelectedItem.ToString();
                        string description = descriptionText.Text;
                        bool isValid = validation.ValidateString(description);
                        if (isValid)
                        {

                            ProductBL product = new ProductBL(seller, name, Convert.ToString(parsedInteger), Convert.ToString(parsedInteger1), category, description);
                            inter.UpdateProduct(existingProduct, product);
                            MessageBox.Show("Data Updated successfully");
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
            else
            {
                MessageBox.Show(check.errorMessage);
            }

        }


        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            updateProduct();
        }
    }
}
