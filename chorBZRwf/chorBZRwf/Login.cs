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
using chorbzr;
using chorbzr.DL.FH;
using chorbzr.DL.DB;
using chorbzr.BL;
using chorbzr.DLInterface;
using System.Web.UI;
using chorBZRwf.Util;


namespace chorBZRwf
{
    public partial class Login : Form
    {
        string choice = "";
        UserInterface inter;
        Validations validation = new Validations();
        public Login(string choice)
        {
            InitializeComponent();
            this.choice = choice;
            interfaceCheck();
        }

       
        private void interfaceCheck()
        {
            if (choice == "1")
            {
                inter = new UserDL();
            }
            else if (choice == "2")
            {
                inter = new userDB();
            }
        }
        

        private void nextClick_Click(object sender, EventArgs e)
        {
            signIn();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignPage aa = new SignPage(choice);
            aa.Show();
            this.Hide();
        }

       

        private void signIn()
        {
            string name = nameText.Text;
            string password = passwordText.Text;
            List<User> user = inter.getUsers();
            if(user == null)
            {
                MessageBox.Show("ghalat kam an kro");
                return ;
            }
            string check = validation.findUser(name, password , user);
            if (check == "seller")
            {
                seller s = new seller(choice , name);
                s.Show();
                this.Hide();
            }
            else if (check == "customer")
            {
                customer c = new customer(choice , name);
                c.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("User not found!");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void passwordText_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
