using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BSSSoftware
{
    public partial class frmReceipt : Form
    {
        int order = 1;
        double total = 0;
        public frmReceipt()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPdName.Text) || !string.IsNullOrEmpty(txtQty.Text))
            {
                Receipt obj = new Receipt()
                {
                    Id = order++,
                    ProductName = txtPdName.Text,
                    Price = Convert.ToDouble(txtPrice.Text),
                    Quantity = Convert.ToInt32(txtQty.Text)
                };
                total += obj.Price * obj.Quantity;
                testInvBindingSource.Add(obj);
                testInvBindingSource.MoveLast();
                txtPdName.Text = string.Empty;
                txtPrice.Text = string.Empty;
                txtQty.Text = string.Empty;
                txtTotal.Text = string.Format("{0} Ks", total);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Receipt obj = testInvBindingSource.Current as Receipt;
            if (obj != null)
            {
                total -= obj.Price * obj.Quantity;
                txtTotal.Text = string.Format("{0} Ks", total);
            }
            testInvBindingSource.RemoveCurrent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (frmPrint frm = new frmPrint(testInvBindingSource.DataSource as List<Receipt>, string.Format("{0}$", total), DateTime.Now.ToString("MM/dd/yyyy"), string.Format("{0}$", txtCash.Text), string.Format("{0}$", (Convert.ToDouble(txtCash.Text) - total))))
            {
                frm.ShowDialog();
            }
          
        }

        private void frmReceipt_Load(object sender, EventArgs e)
        {
            testInvBindingSource.DataSource = new List<Receipt>();
        }

    }
}
