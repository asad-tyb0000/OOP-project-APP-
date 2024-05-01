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
    public partial class ViewKrt : Form
    {
        public string choice;
        public string cust;
        kartInterface inter;
        public ViewKrt(string choice , string cust)
        {
            InitializeComponent();
            this.choice = choice;
            this.cust = cust;
            initializeInterface();
            viewProducts();
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

        private void viewProducts()
        {
            List<Kart> items = inter.GetKartItems();
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();

            dataGrid.Columns.Add("NameColumn", "Name");
            dataGrid.Columns.Add("PriceColumn", "Price");

            foreach (Kart item in items)
            {
                if (item.getCustomerName().Equals(cust, StringComparison.OrdinalIgnoreCase))
                {
                    int rowIndex = dataGrid.Rows.Add();
                    DataGridViewRow row = dataGrid.Rows[rowIndex];

                    row.Cells["NameColumn"].Value = item.getName();
                    row.Cells["PriceColumn"].Value = item.getPrice();
                }
            }
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
