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
    public partial class Form1 : Form
    {


        public string choice;
        public Form1()
        {
            InitializeComponent();
            DBradio.Checked = true;
        }

        private void interfaceChoice()
        {
            if (FHradio.Checked)
            {
                choice = "1";
            }
            else if (DBradio.Checked)
            {
                choice = "2";
            }   
        }
       

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            interfaceChoice();
            SignPage ad = new SignPage(choice);
            ad.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void FHradio_CheckedChanged(object sender, EventArgs e)
        {
            if(FHradio.Checked)
            {
                DBradio.Checked = false;
            }
            
        }

        private void DBradio_CheckedChanged(object sender, EventArgs e)
        {
            if(DBradio.Checked)
            {
                FHradio.Checked = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
    }
}
