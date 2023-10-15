using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BSSBussinessLogic.ProductSaleControl;

namespace BSSSoftware.CodeSetup
{
    public partial class InvoiceView : Form
    {
        public InvoiceView()
        {
            InitializeComponent();
            Initalizing();
        }
        public void Initalizing()
        {
            GeneralControl g_control = new GeneralControl();
            dgvInvoice.AutoGenerateColumns = false;
            dgvInvoice.DataSource = g_control.SelectAllInvoice();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
