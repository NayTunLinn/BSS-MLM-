namespace BSSSoftware.MainStore
{
    partial class MainStoreBalance
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
            this.MainStoreProductDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvMainStoreBalance = new Microsoft.Reporting.WinForms.ReportViewer();
            this.xsdMainstore = new BSSInfo.xsdMainstore();
            ((System.ComponentModel.ISupportInitialize)(this.MainStoreProductDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsdMainstore)).BeginInit();
            this.SuspendLayout();
            // 
            // MainStoreProductDataTableBindingSource
            // 
            this.MainStoreProductDataTableBindingSource.DataSource = typeof(BSSInfo.xsdMainstore.MainStoreProductDataTable);
            // 
            // rpvMainStoreBalance
            // 
            this.rpvMainStoreBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "MainStoreBalance";
            reportDataSource1.Value = this.MainStoreProductDataTableBindingSource;
            this.rpvMainStoreBalance.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvMainStoreBalance.LocalReport.ReportEmbeddedResource = "BSSSoftware.MainStore.rdlcMainStoreBalance.rdlc";
            this.rpvMainStoreBalance.Location = new System.Drawing.Point(0, 0);
            this.rpvMainStoreBalance.Name = "rpvMainStoreBalance";
            this.rpvMainStoreBalance.Size = new System.Drawing.Size(899, 437);
            this.rpvMainStoreBalance.TabIndex = 0;
            // 
            // xsdMainstore
            // 
            this.xsdMainstore.DataSetName = "xsdMainstore";
            this.xsdMainstore.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // MainStoreBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 437);
            this.Controls.Add(this.rpvMainStoreBalance);
            this.Name = "MainStoreBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainStoreBalance Preview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainStoreBalance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainStoreProductDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsdMainstore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvMainStoreBalance;
        private System.Windows.Forms.BindingSource MainStoreProductDataTableBindingSource;
        private BSSInfo.xsdMainstore xsdMainstore;
    }
}