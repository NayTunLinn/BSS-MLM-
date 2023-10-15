namespace BSSSoftware.Commession
{
    partial class CommessionDetailWithAmout_report
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
            this.xsdCommessionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.myReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.xsdCommessionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // xsdCommessionBindingSource
            // 
            this.xsdCommessionBindingSource.DataMember = "BonusDetail";
            this.xsdCommessionBindingSource.DataSource = typeof(BSSInfo.xsdCommession);
            // 
            // myReportViewer
            // 
            this.myReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "BonusDetail";
            reportDataSource1.Value = this.xsdCommessionBindingSource;
            this.myReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.myReportViewer.LocalReport.ReportEmbeddedResource = "BSSSoftware.CommessionAmount.commessionDetailWithAmount.rdlc";
            this.myReportViewer.Location = new System.Drawing.Point(0, 0);
            this.myReportViewer.Name = "myReportViewer";
            this.myReportViewer.Size = new System.Drawing.Size(1027, 395);
            this.myReportViewer.TabIndex = 0;
            this.myReportViewer.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.myReportViewer_RenderingComplete);
            // 
            // CommessionDetailWithAmout_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 395);
            this.Controls.Add(this.myReportViewer);
            this.Name = "CommessionDetailWithAmout_report";
            this.Text = "CommessionDetail_report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CommessionDetail_report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xsdCommessionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource xsdCommessionBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer myReportViewer;
    }
}