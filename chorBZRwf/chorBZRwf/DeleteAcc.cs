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
using chorbzr.BL;
using System.Xml.Linq;

namespace chorBZRwf
{
    public partial class DeleteAcc : Form
    {
        public string choice;
        Validations validation = new Validations();
        UserInterface inter;
        productInterface pro;
        public string seller;

        public DeleteAcc(string choice , string seller)
        {
            InitializeComponent();
            this.choice = choice;
            this.seller = seller;
            initializeInterface();
        }

        private void initializeInterface()
        {
            if (choice == "1")
            {
                inter = new UserDL();
                pro = new productDL();
            }
            else if (choice == "2")
            {
                inter = new userDB();
                pro = new productDB();
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            List<User> users = inter.getUsers();
            List<ProductBL> products = pro.Products();
            User user = validation.giveUser(seller , users);
            if(!(user == null))
            {
            inter.removeUser(user);
            foreach(ProductBL product in products)
            {
                if(product.getSeller() == seller)
                {
                    ProductBL existingProduct = validation.GetProductByNameAndSeller(product.getName(), seller, products);
                    pro.DeleteProduct(existingProduct);
                }
            }
            MessageBox.Show("Account Deleted Successfully");
            Login aa = new Login(choice);
            aa.Show();
            this.Hide();
            seller ss = new seller(choice);
            ss.Hide();
                customer cc = new customer(choice);
                cc.Hide();
            }
            else
            {
                MessageBox.Show("Some issue occured deleting the account! For further assistance contact the developers");
            }
        }
    }
}
