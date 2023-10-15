namespace BSSSoftware.Reporting
{
    partial class testReport
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
            this.xsdSaleReportBindingSource.DataSource = this.xsdSaleReport;
            this.xsdSaleReportBindingSource.Position = 0;
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
            this.reportViewer.Size = new System.Drawing.Size(1060, 525);
            this.reportViewer.TabIndex = 0;
            // 
            // xsdSaleReport
            // 
            this.xsdSaleReport.DataSetName = "xsdSaleReport";
            this.xsdSaleReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // testReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 525);
            this.Controls.Add(this.reportViewer);
            this.Name = "testReport";
            this.Text = "testReport";
            this.Load += new System.EventHandler(this.testReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xsdSaleReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsdSaleReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource xsdSaleReportBindingSource;
        private BSSInfo.xsdSaleReport xsdSaleReport;
    }
}