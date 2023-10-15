using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BSSCommon;
using BSSSoftware.SaleReturnReport;

namespace BSSSoftware
{
    public partial class Main : Form
    {
        #region Variables
        System.Windows.Forms.Timer time;
        #endregion
        public Main()
        {
            InitializeComponent();
            Initalizing();
        }
        private void Initalizing()
        {
            lblTime.Text = System.DateTime.Now.ToString("hh:mm:ss tt");
            lblDate.Text = System.DateTime.Now.ToString("dd-MMMM-yyyy");
            time = new System.Windows.Forms.Timer();
          time.Tick +=new EventHandler(time_Tick);
            time.Interval = 1000;
            time.Start();
        }
        void time_Tick(object sender, EventArgs e)
        {
            lblTime.Text = System.DateTime.Now.ToString("hh:mm:ss tt");
            lblDate.Text = System.DateTime.Now.ToString("dd-MMMM-yyyy");

        }

        private void merchant1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeSetup.AgentRegister me = new CodeSetup.AgentRegister(0);
            me.Show(this);
        }

        private void merchant2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeSetup.AgentRegister me = new CodeSetup.AgentRegister(1);
            me.Show(this);
        }

        private void merchantToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CodeSetup.AgentRegister me = new CodeSetup.AgentRegister(2);
            me.Show(this);
        }

        private void merchant4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeSetup.AgentRegister me = new CodeSetup.AgentRegister(3);
            me.Show(this);
        }

        private void divisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeSetup.Division me = new CodeSetup.Division();
            me.Show(this);
        }

        private void cityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeSetup.City me = new CodeSetup.City();
            me.Show(this);
        }

        private void nationalityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeSetup.Nationality me = new CodeSetup.Nationality();
            me.Show(this);
        }

        private void raceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeSetup.Race me = new CodeSetup.Race();
            me.Show(this);
        }

        private void religionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeSetup.Religion me = new CodeSetup.Religion();
            me.Show(this);
        }

        private void saleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaleReturnReport.Sale sa = new SaleReturnReport.Sale();
            sa.Show(this);
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            CodeSetup.Division me = new CodeSetup.Division();
            me.Show(this);
        }

        private void btnRace_Click(object sender, EventArgs e)
        {
            CodeSetup.Race me = new CodeSetup.Race();
            me.Show(this);
        }

        private void btnNationality_Click(object sender, EventArgs e)
        {
            CodeSetup.Nationality me = new CodeSetup.Nationality();
            me.Show(this);
        }

        private void btnReligion_Click(object sender, EventArgs e)
        {
            CodeSetup.Religion me = new CodeSetup.Religion();
            me.Show(this);
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            SaleReturnReport.Sale sa = new SaleReturnReport.Sale();
            sa.Show(this);
        }

        private void btnCity_Click(object sender, EventArgs e)
        {
            CodeSetup.City me = new CodeSetup.City();
            me.Show(this);
        }

        private void btnMerchant4_Click(object sender, EventArgs e)
        {
            CodeSetup.AgentRegister me = new CodeSetup.AgentRegister(3);
            me.Show(this);
        }

        private void btnMerchant3_Click(object sender, EventArgs e)
        {
            CodeSetup.AgentRegister me = new CodeSetup.AgentRegister(2);
            me.Show(this);
        }

        private void btnMerchant2_Click(object sender, EventArgs e)
        {
            CodeSetup.AgentRegister me = new CodeSetup.AgentRegister(1);
            me.Show(this);
        }

        private void btnMerchant1_Click(object sender, EventArgs e)
        {
            CodeSetup.AgentRegister me = new CodeSetup.AgentRegister(0);
            me.Show(this);
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Return.SaleReturn re = new Return.SaleReturn();
            re.Show(this);
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainStore.StoreToSale sp = new MainStore.StoreToSale();
            sp.Show(this);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            CodeSetup.Product pd = new CodeSetup.Product();
            pd.Show(this);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CodeSetup.Customer cus = new CodeSetup.Customer();
            cus.Show(this);
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            CodeSetup.Supplier su = new CodeSetup.Supplier();
            su.Show(this);
        }

        private void viewReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainStore.StoreRecord sr = new MainStore.StoreRecord();
            sr.Show(this);
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            MainStore.StoreToSale sp = new MainStore.StoreToSale();
            sp.Show(this);
        }

        private void profitRatingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeSetup.ProfitRate pr = new CodeSetup.ProfitRate();
            pr.Show(this);
        }

        private void btnProfitrate_Click(object sender, EventArgs e)
        {
            CodeSetup.ProfitRate pr = new CodeSetup.ProfitRate();
            pr.Show(this);
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeSetup.Customer cu = new CodeSetup.Customer();
            cu.Show(this);
        }

        private void searchInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleReturnReport.SearchInvoice sc = new SaleReturnReport.SearchInvoice();
            sc.Show(this);
        }

        private void btnReportings_Click(object sender, EventArgs e)
        {
           
        }

        private void bonusViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commession.Commession_View cm = new Commession.Commession_View();
            cm.Show(this);
            //ProductSale.Bonus_View bv = new ProductSale.Bonus_View();
            //bv.Show(this);
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            Utility.CenterMyControl(lblTitle);
            Utility.CenterMyControl(myLogo);
            Utility.CenterMyControl(label1);
        }

        private void todayReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainStore.StoreToSaleReport str = new MainStore.StoreToSaleReport();
            str.ShowDialog(this);
        }

        private void detailReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void reportViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainStore.ReportView rv = new MainStore.ReportView();
            rv.ShowDialog(this);
        }

        private void storeCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainStore.StoerCategory sc = new MainStore.StoerCategory();
            sc.Show(this);
        }

        private void bonusReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ProductSale.BonusReport br = new ProductSale.BonusReport();
            //br.Show(this);
            SaleReturnReport.Bonus_View bv = new SaleReturnReport.Bonus_View();
            bv.Show(this);
        }

        private void commissionRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeSetup.ProfitRate pf = new CodeSetup.ProfitRate();
            pf.ShowDialog(this);
        }

        private void treeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.MerchantTreeView mtv = new Reporting.MerchantTreeView(null,null);
            mtv.Show(this);
        }

        private void btnMainStore_Click(object sender, EventArgs e)
        {
            MainStore.MainStoreRecord ms = new MainStore.MainStoreRecord();
            ms.Show(this);
        }
        private void storeRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainStore.MainStoreRecord msr=new MainStore.MainStoreRecord();
            msr.Show();
        }

        private void toSubStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainStore.MainStoreToSubStore mst = new MainStore.MainStoreToSubStore();
            mst.Show();
        }

        private void testConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connection.NetworkConnection nc = new Connection.NetworkConnection();
            nc.ShowDialog(this);
        }

        private void saleProductSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.SaleProductSummaryReport sm = new Reporting.SaleProductSummaryReport();
            sm.Show();
        }

        private void summaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void productToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CodeSetup.Product pd = new CodeSetup.Product();
            pd.Show(this);
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleReturnReport.ReportInvoice ri = new ReportInvoice(null);
            ri.Show(this);
        }

        private void storeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainStore.StoreToSaleReport str = new MainStore.StoreToSaleReport();
            str.Show();
        }

        private void saleReturnInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleReturnReport.SaleReturnInvoice sc = new SaleReturnReport.SaleReturnInvoice();
            sc.Show(this);
        }

        private void mainStoreSummeryToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void saleStoreSummeryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void subStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainStore.SubStoreSummery st = new MainStore.SubStoreSummery();
            st.Show();
        }

        private void saleStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainStore.SaleStoreSummery st = new MainStore.SaleStoreSummery();
            st.Show();
        }

        private void mainStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainStore.MainStoreSummery ms = new MainStore.MainStoreSummery();
            ms.Show();
        }

      
    }
}
