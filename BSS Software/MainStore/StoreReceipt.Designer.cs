namespace BSSSoftware.MainStore
{
    partial class StoreReceipt
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.StoreReceiptView = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // StoreReceiptView
            // 
            this.StoreReceiptView.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "myReceipt";
            reportDataSource2.Value = null;
            this.StoreReceiptView.LocalReport.DataSources.Add(reportDataSource2);
            this.StoreReceiptView.LocalReport.ReportEmbeddedResource = "BSSSoftware.Reporting.ReceiptReport.rdlc";
            this.StoreReceiptView.Location = new System.Drawing.Point(0, 0);
            this.StoreReceiptView.Name = "StoreReceiptView";
            this.StoreReceiptView.Size = new System.Drawing.Size(763, 487);
            this.StoreReceiptView.TabIndex = 1;
            // 
            // StoreReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 487);
            this.Controls.Add(this.StoreReceiptView);
            this.Name = "StoreReceipt";
            this.Text = "StoreReceipt";
            this.Load += new System.EventHandler(this.StoreReceipt_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer StoreReceiptView;
    }
}