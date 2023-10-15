namespace BSSSoftware.MainStore
{
    partial class MainStoreToSubStoreReport
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
            this.MainStoreInvoiceDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.dtpInvDate = new System.Windows.Forms.DateTimePicker();
            this.MainStoreInvoiceHeader = new Microsoft.Reporting.WinForms.ReportViewer();
            this.xsdMainstore = new BSSInfo.xsdMainstore();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpkInvMnth = new System.Windows.Forms.DateTimePicker();
            this.cboGroup = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainStoreInvoiceDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsdMainstore)).BeginInit();
            this.SuspendLayout();
            // 
            // MainStoreInvoiceDataTableBindingSource
            // 
            this.MainStoreInvoiceDataTableBindingSource.DataSource = typeof(BSSInfo.xsdMainstore.MainStoreInvoiceDataTable);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1093, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 121;
            this.label1.Text = "Invoice No";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.Location = new System.Drawing.Point(1035, 33);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(220, 26);
            this.txtInvoiceNo.TabIndex = 117;
            this.txtInvoiceNo.TextChanged += new System.EventHandler(this.txtInvoiceNo_TextChanged);
            // 
            // dtpInvDate
            // 
            this.dtpInvDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpInvDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInvDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvDate.Location = new System.Drawing.Point(1097, 81);
            this.dtpInvDate.Name = "dtpInvDate";
            this.dtpInvDate.Size = new System.Drawing.Size(158, 26);
            this.dtpInvDate.TabIndex = 116;
            this.dtpInvDate.ValueChanged += new System.EventHandler(this.dtpInvDate_ValueChanged);
            // 
            // MainStoreInvoiceHeader
            // 
            this.MainStoreInvoiceHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "MainstoreToSubStoreInvoiceHeader";
            reportDataSource1.Value = this.MainStoreInvoiceDataTableBindingSource;
            this.MainStoreInvoiceHeader.LocalReport.DataSources.Add(reportDataSource1);
            this.MainStoreInvoiceHeader.LocalReport.ReportEmbeddedResource = "BSSSoftware.MainStore.rdlcMainStoreToSubStoreReport.rdlc";
            this.MainStoreInvoiceHeader.Location = new System.Drawing.Point(1, 0);
            this.MainStoreInvoiceHeader.Name = "MainStoreInvoiceHeader";
            this.MainStoreInvoiceHeader.Size = new System.Drawing.Size(1013, 536);
            this.MainStoreInvoiceHeader.TabIndex = 115;
            // 
            // xsdMainstore
            // 
            this.xsdMainstore.DataSetName = "xsdMainstore";
            this.xsdMainstore.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1054, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 122;
            this.label2.Text = "Day";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1037, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 124;
            this.label3.Text = "Month";
            // 
            // dtpkInvMnth
            // 
            this.dtpkInvMnth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpkInvMnth.CustomFormat = "MMMM";
            this.dtpkInvMnth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkInvMnth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkInvMnth.Location = new System.Drawing.Point(1097, 126);
            this.dtpkInvMnth.Name = "dtpkInvMnth";
            this.dtpkInvMnth.Size = new System.Drawing.Size(158, 26);
            this.dtpkInvMnth.TabIndex = 123;
            this.dtpkInvMnth.ValueChanged += new System.EventHandler(this.dtpkInvMnth_ValueChanged);
            // 
            // cboGroup
            // 
            this.cboGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGroup.AutoSize = true;
            this.cboGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGroup.ForeColor = System.Drawing.Color.White;
            this.cboGroup.Location = new System.Drawing.Point(1084, 174);
            this.cboGroup.Name = "cboGroup";
            this.cboGroup.Size = new System.Drawing.Size(78, 24);
            this.cboGroup.TabIndex = 125;
            this.cboGroup.Text = "Group";
            this.cboGroup.UseVisualStyleBackColor = true;
            this.cboGroup.CheckedChanged += new System.EventHandler(this.cboGroup_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(1180, 175);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 126;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // MainStoreToSubStoreReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.ClientSize = new System.Drawing.Size(1267, 537);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cboGroup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpkInvMnth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.dtpInvDate);
            this.Controls.Add(this.MainStoreInvoiceHeader);
            this.Name = "MainStoreToSubStoreReport";
            this.Text = "MainStoreToSubStoreReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainStoreToSubStoreReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainStoreInvoiceDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsdMainstore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.DateTimePicker dtpInvDate;
        private Microsoft.Reporting.WinForms.ReportViewer MainStoreInvoiceHeader;
        private System.Windows.Forms.BindingSource MainStoreInvoiceDataTableBindingSource;
        private BSSInfo.xsdMainstore xsdMainstore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpkInvMnth;
        private System.Windows.Forms.CheckBox cboGroup;
        private System.Windows.Forms.Button btnRefresh;
    }
}