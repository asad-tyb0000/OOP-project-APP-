using chorbzr.BL;
using chorbzr.DL.DB;
using chorbzr.DL.FH;
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

namespace chorBZRwf
{
    public partial class RemoveKrt : Form
    {
        public string choice;
        public string cust;
        kartInterface inter;
        public RemoveKrt(string choice , string cust)
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
            }
            else if (choice == "2")
            {
                inter = new KartDB();
            }
        }

        private void RemoveKrt_Load(object sender, EventArgs e)
        {

        }

        private void viewCombo()
        {
            List<Kart> items = inter.GetKartItems();
            productCombo.Items.Clear();
            foreach (Kart item in items)
            {
                if(item.getCustomerName() == cust )
                {
                    productCombo.Items.Add(item.getName());
                }
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Removeit()
        {
            List<Kart> items = inter.GetKartItems();
            string name = productCombo.SelectedItem.ToString();
            if(name == null)
            {
                MessageBox.Show("Name can not be empty");
            }
            else
            {
                foreach(Kart item in items)
                {
                    if(name == item.getName() && cust == item.getCustomerName())
                    {
                        Kart krt = new Kart(cust , item.getName() , item.getPrice());
                        inter.RemoveFromKart(krt);
                        MessageBox.Show("Item Removed Successfully");
                    }
                }
            }
        }
        private void nextButton_Click(object sender, EventArgs e)
        {
            Removeit();
        }
    }
}
