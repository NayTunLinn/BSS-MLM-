using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace BSSSoftware
{
    public partial class frmPrint : Form
    {
        List<Receipt> _list;
        string _total, _date, _cash, _change;
        public frmPrint(List<Receipt> datasource,string total,string date,string cash,string change)
        {
            InitializeComponent();
            _list = datasource;
            _total = total;
            _date = date;
            _cash = cash;
            _change = change;
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            TestInvDataTableBindingSource.DataSource = _list;
            ReportParameter[] para = new ReportParameter[]
            {
                 new ReportParameter("pTotal",_total),
                  new ReportParameter("pDate",_date),
                   new ReportParameter("pCash",_cash),
                    new ReportParameter("pChange",_change)
            };
            this.reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.RefreshReport();

        }
    }
}
