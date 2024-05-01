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
using System.Xml.Serialization;

namespace chorBZRwf
{
    public partial class RemovePRO : Form
    {
        public string choice;
        Validations validation = new Validations();
        productInterface inter;
        public string seller;
        public RemovePRO(string choice , string seller)
        {
            InitializeComponent();
            this.choice = choice;
            initializeInterface();
            this.seller = seller;
            viewCombo();

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

        private void viewCombo()
        {
            List<ProductBL> products = inter.Products();
            productCombo.Items.Clear();
            foreach(ProductBL prod in products)
            {
                if(prod.getSeller() == seller)
                {
                    productCombo.Items.Add(prod.getName());
                }
            }
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void RemovePro()
        {
            try
            {
            string name = productCombo.SelectedItem.ToString();
                if (String.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Please fill this feild");
                    return;
                }
            List<ProductBL> pro = inter.Products();
                if (name == null)
                {
                    MessageBox.Show("Name can not be Empty");
                }
                else
                {
                    ProductBL existingProduct = validation.GetProductByNameAndSeller(name, seller, pro);
                    inter.DeleteProduct(existingProduct);
                    MessageBox.Show("Product deleted successfully");

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            try
            {

            RemovePro();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
