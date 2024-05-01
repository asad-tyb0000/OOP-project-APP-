using chorbzr.DLInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using chorbzr.DLInterface;
using chorbzr.DL.FH;
using chorbzr.DL.DB;
using chorbzr.BL;

namespace chorBZRwf
{
    public partial class AddKrt : Form
    {

        public string choice;
        public string cust;
        kartInterface inter;
        productInterface pro;

        public AddKrt(string choice, string cust)
        {
            InitializeComponent();
            this.choice = choice;
            this.cust = cust;
            initializeInterface();
            viewCombo();
            
        }

        private void initializeInterface()
        {
            if (choice == "1")
            {
                inter = new KartDL();
                pro = new productDL();
            }
            else if (choice == "2")
            {
                inter = new KartDB();
                pro = new productDB();
            }
        }

        private void viewCombo()
        {
            List<ProductBL> store = pro.Products();
            productCombo.Items.Clear();
            foreach(ProductBL item in store)
            {
                productCombo.Items.Add(item.getName());
            }

        }

        private void showTextBox()
        {
            List<ProductBL> products = pro.Products();
            string pname = productCombo.SelectedItem.ToString();
            if(pname == null)
            {
                MessageBox.Show("Name can not be empty");
            }
            else
            {
                foreach (ProductBL prod in products)
                {
                    if (prod.getName() == pname)
                    {
                        textBox.Text = prod.getPrice();
                    }
                }
            }
            
        }

        private void AddKrt_Load(object sender, EventArgs e)
        {

        }

        private void AddToKart()
        {
            string name = productCombo.SelectedItem.ToString();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Plaese fill the field");
                return;
            }
            List<ProductBL> product = pro.Products();
            foreach (ProductBL prod in product)
            {
                if (prod.getName() == name)
                {
                    Kart krt = new Kart(cust, prod.getName(), prod.getPrice());
                    inter.AddToKart(krt);
                    MessageBox.Show("Item Added to the Kart");
                }
            }
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            AddToKart();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void productCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            showTextBox();
        }
    }
}
