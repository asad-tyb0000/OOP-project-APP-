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
    public partial class ViewPro : Form
    {
        public string choice;
        Validations validation = new Validations();
        productInterface inter;
        public string seller;

        public ViewPro(string choice ,string seller)
        {
            InitializeComponent();
            this.choice = choice;
            initializeInterface();
            this.seller = seller;
            viewProducts();
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

        private void ViewPro_Load(object sender, EventArgs e)
        {

        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void viewProducts()
        {
            List<ProductBL> pro = inter.Products();
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();

            dataGrid.Columns.Add("NameColumn", "Name");
            dataGrid.Columns.Add("PriceColumn", "Price");
            dataGrid.Columns.Add("QuantityColumn", "Quantity");
            dataGrid.Columns.Add("DescriptionColumn", "Description");

            foreach (ProductBL product in pro)
            {
                if (product.getSeller().Equals(seller, StringComparison.OrdinalIgnoreCase))
                {
                    int rowIndex = dataGrid.Rows.Add();
                    DataGridViewRow row = dataGrid.Rows[rowIndex];

                    row.Cells["NameColumn"].Value = product.getName();
                    row.Cells["PriceColumn"].Value = product.getPrice();
                    row.Cells["QuantityColumn"].Value = product.getQuantity();
                    row.Cells["DescriptionColumn"].Value = product.getDescription();
                }
            }
        }

    }
}
