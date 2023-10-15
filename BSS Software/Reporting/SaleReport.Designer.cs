namespace BSSSoftware.Reporting
{
    partial class SaleReport
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
            this.xsdSaleReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.xsdSaleReport = new BSSInfo.xsdSaleReport();
            ((System.ComponentModel.ISupportInitialize)(this.xsdSaleReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsdSaleReport)).BeginInit();
            this.SuspendLayout();
            // 
            // xsdSaleReportBindingSource
            // 
            this.xsdSaleReportBindingSource.DataMember = "InvoiceDetails_Report";
            this.xsdSaleReportBindingSource.DataSource = typeof(BSSInfo.xsdSaleReport);
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "myReceipt";
            reportDataSource1.Value = this.xsdSaleReportBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "BSSSoftware.Reporting.ReceiptReport.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(972, 488);
            this.reportViewer.TabIndex = 0;
            this.reportViewer.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer_RenderingComplete);
            // 
            // xsdSaleReport
            // 
            this.xsdSaleReport.DataSetName = "xsdSaleReport";
            this.xsdSaleReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SaleReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 488);
            this.Controls.Add(this.reportViewer);
            this.Name = "SaleReport";
            this.Text = "SaleReport";
            this.Load += new System.EventHandler(this.SaleReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xsdSaleReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsdSaleReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        public BSSInfo.xsdSaleReport xsdSaleReport;
        public System.Windows.Forms.BindingSource xsdSaleReportBindingSource;





    }
}