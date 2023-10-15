namespace BSSSoftware.MainStore
{
    partial class BalanceProduct
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
            this.StoreRecordReprot = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // StoreRecordReprot
            // 
            this.StoreRecordReprot.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "StoreReport";
            reportDataSource2.Value = null;
            this.StoreRecordReprot.LocalReport.DataSources.Add(reportDataSource2);
            this.StoreRecordReprot.LocalReport.ReportEmbeddedResource = "BSSSoftware.MainStore.rdlcStoreReport.rdlc";
            this.StoreRecordReprot.Location = new System.Drawing.Point(0, 0);
            this.StoreRecordReprot.Name = "StoreRecordReprot";
            this.StoreRecordReprot.Size = new System.Drawing.Size(1017, 511);
            this.StoreRecordReprot.TabIndex = 1;
            // 
            // BalanceProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 511);
            this.Controls.Add(this.StoreRecordReprot);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BalanceProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BalanceProduct";
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer StoreRecordReprot;
    }
}