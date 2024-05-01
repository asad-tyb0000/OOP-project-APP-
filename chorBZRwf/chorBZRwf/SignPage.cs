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
    public partial class SignPage : Form
    {

        string choice;
        UserInterface inter;
        Validations validation = new Validations();


        public SignPage(string choice)
        {
            InitializeComponent();
            this.choice = choice;
            initializeInterface();
            addCombo();

        }

        private void initializeInterface()
        {
            if (choice == "1")
            {
                inter = new UserDL();
            }
            else if(choice == "2")
            {
                inter = new userDB();
            }
        }



        private void roleCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addCombo()
        {
            roleCombo.Items.Clear();
            roleCombo.Items.Add("seller");
            roleCombo.Items.Add("customer");
            roleCombo.SelectedIndex = 0;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login a = new Login(choice);
            a.Show();
            this.Hide();
        }


        private void nextClick_Click(object sender, EventArgs e)
        {
            AddUser();
        }

        private void AddUser()
        {
            
            string name = nameText.Text;
            List<User> users = inter.getUsers();
            bool isValid = validation.ValidateNameAndCheckIfExists(name, users);
            if(isValid)
            {
                string password = passwordText.Text;
                bool isValid2 = validation.ValidatePassword(password);
                if(isValid2)
                {
                    string role = roleCombo.SelectedItem.ToString();
                    if(role == "seller")
                    {
                        User newUser = new Seller(name, password, role);
                        inter.addUser(newUser);
                        MessageBox.Show("User Added Successfully");
                    }
                    else if(role == "customer")
                    {
                        User newUser = new Customer(name, password, role);
                        inter.addUser(newUser);
                        MessageBox.Show("User Added Successfully");
                    }
                    Login aa = new Login(choice);
                    aa.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Password! Must be 6 character long and does not contain comma");
                }

            }
            else
            {
                MessageBox.Show("Invalid UserName or user Already exists!  Must be 3 character long and does not contain comma");
            }



        }

        private void nameText_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
    }
}
