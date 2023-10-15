namespace BSSSoftware.MainStore
{
    partial class MainStoreToSubStoreReportDetail
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.MainStoreInvoiceDetail = new Microsoft.Reporting.WinForms.ReportViewer();
            this.MainStoreInvoiceDetailDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.xsdMainstore = new BSSInfo.xsdMainstore();
            ((System.ComponentModel.ISupportInitialize)(this.MainStoreInvoiceDetailDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsdMainstore)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 126;
            this.label1.Text = "Invoice No";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.Location = new System.Drawing.Point(107, 12);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(158, 26);
            this.txtInvoiceNo.TabIndex = 124;
            this.txtInvoiceNo.TextChanged += new System.EventHandler(this.txtInvoiceNo_TextChanged);
            // 
            // MainStoreInvoiceDetail
            // 
            this.MainStoreInvoiceDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource2.Name = "MstroeToSubStoreReportDetail";
            reportDataSource2.Value = this.MainStoreInvoiceDetailDataTableBindingSource;
            this.MainStoreInvoiceDetail.LocalReport.DataSources.Add(reportDataSource2);
            this.MainStoreInvoiceDetail.LocalReport.ReportEmbeddedResource = "BSSSoftware.MainStore.rdlcMainStoreToSubStoreReportDetail.rdlc";
            this.MainStoreInvoiceDetail.Location = new System.Drawing.Point(0, 44);
            this.MainStoreInvoiceDetail.Name = "MainStoreInvoiceDetail";
            this.MainStoreInvoiceDetail.Size = new System.Drawing.Size(1169, 493);
            this.MainStoreInvoiceDetail.TabIndex = 122;
            // 
            // MainStoreInvoiceDetailDataTableBindingSource
            // 
            this.MainStoreInvoiceDetailDataTableBindingSource.DataSource = typeof(BSSInfo.xsdMainstore.MainStoreInvoiceDetailDataTable);
            // 
            // xsdMainstore
            // 
            this.xsdMainstore.DataSetName = "xsdMainstore";
            this.xsdMainstore.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // MainStoreToSubStoreReportDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.ClientSize = new System.Drawing.Size(1170, 537);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.MainStoreInvoiceDetail);
            this.Name = "MainStoreToSubStoreReportDetail";
            this.Text = "MainStoreToSubStoreReportDetail";
            this.Load += new System.EventHandler(this.MainStoreToSubStoreReportDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainStoreInvoiceDetailDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsdMainstore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private Microsoft.Reporting.WinForms.ReportViewer MainStoreInvoiceDetail;
        private System.Windows.Forms.BindingSource MainStoreInvoiceDetailDataTableBindingSource;
        private BSSInfo.xsdMainstore xsdMainstore;
    }
}