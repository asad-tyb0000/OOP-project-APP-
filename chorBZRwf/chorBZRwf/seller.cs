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
    public partial class seller : Form
    {
        Form activeForm;
        public string choice;
        public string name;
        public seller(string choice , string name)
        {
            InitializeComponent();
            this.choice = choice;
            this.name = name;
        }

        public seller(string choice)
        {
            InitializeComponent();
            this.choice = choice;
        }

        private void openChildForm(Form child, object sender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = child;

            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;

            this.guna2CustomGradientPanel3.Controls.Add(child);
            this.guna2CustomGradientPanel3.Tag = child;

            child.BringToFront();
            child.Show();
        }
        private void guna2CustomGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ChangeButtonColor(Guna.UI2.WinForms.Guna2Button clickedButton)
        {
            guna2Button1.FillColor = Color.MediumSlateBlue;
            guna2Button2.FillColor = Color.MediumSlateBlue;
            guna2Button3.FillColor = Color.MediumSlateBlue;
            guna2Button4.FillColor = Color.MediumSlateBlue;
            guna2Button5.FillColor = Color.MediumSlateBlue;
            clickedButton.FillColor = Color.DarkBlue;

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            openChildForm(new AddProduct(choice , name), sender);
            ChangeButtonColor(guna2Button1);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            openChildForm(new RemovePRO(choice, name), sender);
            ChangeButtonColor(guna2Button2);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            openChildForm(new UpdatePro(choice, name), sender);
            ChangeButtonColor(guna2Button3);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            openChildForm(new ViewPro(choice, name), sender);
            ChangeButtonColor(guna2Button4);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            openChildForm(new DeleteAcc(choice, name), sender);
            ChangeButtonColor(guna2Button5);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Login aa = new Login(choice);
            this.Hide();
            aa.Show();
        }

        private void seller_Load(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
