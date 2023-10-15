using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BSSSoftware.SaleReturnReport
{
    public partial class SaleReturnReporting : Form
    {
        public SaleReturnReporting()
        {
            InitializeComponent();
        }

        private void SaleReturnReporting_Load(object sender, EventArgs e)
        {

            this.rptSaleReturn.RefreshReport();
        }
    }
}
