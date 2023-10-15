namespace BSSSoftware.SaleReturnReport
{
    partial class BonusReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.BonusViewDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BonusReportView = new Microsoft.Reporting.WinForms.ReportViewer();
            this.xsdSale = new BSSInfo.xsdSale();
            ((System.ComponentModel.ISupportInitialize)(this.BonusViewDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsdSale)).BeginInit();
            this.SuspendLayout();
            // 
            // BonusViewDataTableBindingSource
            // 
            this.BonusViewDataTableBindingSource.DataSource = typeof(BSSInfo.xsdSale.BonusViewDataTable);
            // 
            // BonusReportView
            // 
            this.BonusReportView.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "BonusViewReport";
            reportDataSource1.Value = this.BonusViewDataTableBindingSource;
            this.BonusReportView.LocalReport.DataSources.Add(reportDataSource1);
            this.BonusReportView.LocalReport.ReportEmbeddedResource = "BSSSoftware.ProductSale.rdlcBonusReport.rdlc";
            this.BonusReportView.Location = new System.Drawing.Point(0, 0);
            this.BonusReportView.Name = "BonusReportView";
            this.BonusReportView.Size = new System.Drawing.Size(1251, 520);
            this.BonusReportView.TabIndex = 61;
            // 
            // xsdSale
            // 
            this.xsdSale.DataSetName = "xsdSale";
            this.xsdSale.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BonusReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.ClientSize = new System.Drawing.Size(1251, 520);
            this.Controls.Add(this.BonusReportView);
            this.Name = "BonusReport";
            this.Text = "BonusReport";
            this.Load += new System.EventHandler(this.BonusReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BonusViewDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsdSale)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer BonusReportView;
        private BSSInfo.xsdSale xsdSale;
        private System.Windows.Forms.BindingSource BonusViewDataTableBindingSource;
    }
}