namespace BSSSoftware.SaleReturnReport
{
    partial class InvoiceMasterDetailReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.HeaderDetailReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.headerDetailReport1 = new BSSInfo.HeaderDetailReport();
            this.myReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderDetailReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerDetailReport1)).BeginInit();
            this.SuspendLayout();
            // 
            // HeaderDetailReportBindingSource
            // 
            this.HeaderDetailReportBindingSource.DataMember = "InvoiceHeaderDetail";
            // 
            // headerDetailReport1
            // 
            this.headerDetailReport1.DataSetName = "HeaderDetailReport";
            this.headerDetailReport1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // myReportViewer
            // 
            this.myReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "HeaderDetail";
            reportDataSource2.Value = this.HeaderDetailReportBindingSource;
            this.myReportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.myReportViewer.LocalReport.ReportEmbeddedResource = "BSSSoftware.ProductSale.InvoiceMDreport.rdlc";
            this.myReportViewer.Location = new System.Drawing.Point(0, 0);
            this.myReportViewer.Name = "myReportViewer";
            this.myReportViewer.Size = new System.Drawing.Size(1246, 495);
            this.myReportViewer.TabIndex = 0;
            // 
            // InvoiceMasterDetailReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 495);
            this.Controls.Add(this.myReportViewer);
            this.Name = "InvoiceMasterDetailReport";
            this.Text = "InvoiceMasterDetailReport";
            this.Load += new System.EventHandler(this.InvoiceMasterDetailReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderDetailReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerDetailReport1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource HeaderDetailReportBindingSource;
        private BSSInfo.HeaderDetailReport headerDetailReport1;
        private Microsoft.Reporting.WinForms.ReportViewer myReportViewer;
    }
}