using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BSSBussinessLogic.FourStepsControls;
using BSSInfo;
using BSSCommon;
namespace BSSSoftware.Reporting
{
    public partial class MerchantTreeView : Form
    {
        #region Variables
        private MerchantControl m_controller = null;
        private SMerchantControl sm_controller = null;
        private WholesaleControl w_controller = null;
        private RetailerControl r_controller = null;
 
        TreeNode MerchantNode = null;
        TreeNode SmerchantNode = null;
        TreeNode WsaleNode = null;
        TreeNode RetailerNode = null;

        string MerchantId;
        string Rank;
        string Id;
        #endregion

        public MerchantTreeView(string _Id, string _Rank)
        {
            InitializeComponent();
            Rank = _Rank;
            Id = _Id;
            Initalizing();
           
        }

        private void Initalizing()
        {
            m_controller = new MerchantControl();
            sm_controller = new SMerchantControl();
            w_controller = new WholesaleControl();
            r_controller = new RetailerControl();

            StartView();
            //myTreeView.ExpandAll();
        }

        #region Adding Level Tree
        private void StartView()
        {
            switch (Rank)
            {
                case "Merchant": MerchantLevelById(); break;
                case "Small Merchant": SmallMerchantLevelId(); break;
                case "Wholesale": WholesaleLevelId(); break;
                case "Retailer": RetailerLevelId(); break;
                default : MerchantLevel(); break;
            }
        }
        private void MerchantLevel()
        {
            xsdRegister.MerchantDataTable m_dt = m_controller.SelectAll();

            foreach (DataRow dr in m_dt)
            {
                MerchantNode = myTreeView.Nodes.Add(dr["MerchantName"].ToString() + "     " + dr["MerchantCode"].ToString() + "     " + dr["MerchantRate"].ToString() + "     " + dr["Address"].ToString());

                SmallMerchantLevel(dr["MerchantId"].ToString(), MerchantNode);
            }
           
        }
        #region ByLevel
        private void MerchantLevelById()
        {
            xsdRegister.MerchantRow dr = m_controller.SelectByKey(Id);

            MerchantNode = myTreeView.Nodes.Add(dr["MerchantName"].ToString() + "     " + dr["MerchantCode"].ToString() + "     " + dr["MerchantRate"].ToString() + "     " + dr["Address"].ToString());

            SmallMerchantLevel(dr["MerchantId"].ToString(), MerchantNode);
        }
        private void SmallMerchantLevelId()
        {
            xsdRegister.SmallMerchantRow dr = sm_controller.SelectByKey(Id);

            SmerchantNode = myTreeView.Nodes.Add(dr["SmerchantName"].ToString() + "     " + dr["SmerchantCode"].ToString() + "     " + dr["SmerchantRate"].ToString() + "     " + dr["Address"].ToString());
            WholesaleLevel(dr["SmerchantId"].ToString(), SmerchantNode);
        }
        private void WholesaleLevelId()
        {
            xsdRegister.WholesaleRow dr = w_controller.SelectByKey(Id);
            WsaleNode = myTreeView.Nodes.Add(dr["WsaleName"].ToString() + "     " + dr["WsaleCode"].ToString() + "     " + dr["WsaleRate"].ToString() + "     " + dr["Address"].ToString());
            RetailerLevel(dr["WsaleId"].ToString(), WsaleNode);

        }
        private void RetailerLevelId()
        {
            xsdRegister.RetailerRow dr = r_controller.SelectByKey(Id);
            RetailerNode = myTreeView.Nodes.Add(dr["RetailerName"].ToString() + "     " + dr["RetailerCode"].ToString() + "     " + dr["RetailerRate"].ToString() + "     " + dr["Address"].ToString());

        } 
        #endregion

        private void SmallMerchantLevel(string MerchantId, TreeNode MerchantNode)
        {
            xsdRegister.SmallMerchantDataTable sm_dt = sm_controller.SelectByUpperId(MerchantId);

            foreach (DataRow dr in sm_dt)
            {
                if (MerchantNode == null)
                    SmerchantNode = myTreeView.Nodes.Add(dr["SmerchantName"].ToString() + "     " + dr["SmerchantCode"].ToString() + "     " + dr["SmerchantRate"].ToString() + "     " + dr["Address"].ToString());
                else
                    SmerchantNode = MerchantNode.Nodes.Add(dr["SmerchantName"].ToString() + "     " + dr["SmerchantCode"].ToString() + "     " + dr["SmerchantRate"].ToString() + "     " + dr["Address"].ToString());
                WholesaleLevel(dr["SmerchantId"].ToString(), SmerchantNode);
            }

            //myTreeView.ExpandAll();
        }

        private void WholesaleLevel(string SmerchantId, TreeNode SmerchantNode)
        {
            xsdRegister.WholesaleDataTable w_dt = w_controller.SelectByUpperId(SmerchantId);

            foreach (DataRow dr in w_dt)
            {
                if (SmerchantNode == null)
                    WsaleNode = myTreeView.Nodes.Add(dr["WsaleName"].ToString() + "     " + dr["WsaleCode"].ToString() + "     " + dr["WsaleRate"].ToString() + "     " + dr["Address"].ToString());
                else
                    WsaleNode = SmerchantNode.Nodes.Add(dr["WsaleName"].ToString() + "     " + dr["WsaleCode"].ToString() + "     " + dr["WsaleRate"].ToString() + "     " + dr["Address"].ToString());
               
                RetailerLevel(dr["WsaleId"].ToString(), WsaleNode);
            }

            //myTreeView.ExpandAll();
        }

        private void RetailerLevel(string WsaleId, TreeNode WsaleNode)
        {
            xsdRegister.RetailerDataTable r_dt = r_controller.SelectByUpperId(WsaleId);

            foreach (DataRow dr in r_dt)
            {
                if (WsaleNode == null)
                    RetailerNode = myTreeView.Nodes.Add(dr["RetailerName"].ToString() + "     " + dr["RetailerCode"].ToString() + "     " + dr["RetailerRate"].ToString() + "     " + dr["Address"].ToString());
                else
                    RetailerNode = WsaleNode.Nodes.Add(dr["RetailerName"].ToString() + "     " + dr["RetailerCode"].ToString() + "     " + dr["RetailerRate"].ToString() + "     " + dr["Address"].ToString());
            }

           // myTreeView.ExpandAll();
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch(Rank)
            {
                case "Merchant": MerchantLevel(); break;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            myTreeView.Refresh();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myTreeView.Refresh();
           // MerchantLevel();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                myTreeView.Font = fd.Font;
            }
        }
        private void MerchantTreeView_SizeChanged(object sender, EventArgs e)
        {
            Utility.CenterMyControl(label1);
        }

    }
}
