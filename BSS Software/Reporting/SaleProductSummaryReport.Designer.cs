namespace BSSSoftware.Reporting
{
    partial class SaleProductSummaryReport
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
            this.xsdSummaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.cboFromTo = new System.Windows.Forms.CheckBox();
            this.dtpkFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMonth = new System.Windows.Forms.CheckBox();
            this.dtpkMonth = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.RepSaleProductSummary = new Microsoft.Reporting.WinForms.ReportViewer();
            this.xsdSummary = new BSSInfo.xsdSummary();
            ((System.ComponentModel.ISupportInitialize)(this.xsdSummaryBindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xsdSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // xsdSummaryBindingSource
            // 
            this.xsdSummaryBindingSource.DataMember = "SaleProductSummary";
            this.xsdSummaryBindingSource.DataSource = typeof(BSSInfo.xsdSummary);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cboFromTo);
            this.panel3.Controls.Add(this.dtpkFrom);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.cboMonth);
            this.panel3.Controls.Add(this.dtpkMonth);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1265, 83);
            this.panel3.TabIndex = 57;
            // 
            // cboFromTo
            // 
            this.cboFromTo.AutoSize = true;
            this.cboFromTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFromTo.Location = new System.Drawing.Point(888, 39);
            this.cboFromTo.Name = "cboFromTo";
            this.cboFromTo.Size = new System.Drawing.Size(15, 14);
            this.cboFromTo.TabIndex = 56;
            this.cboFromTo.UseVisualStyleBackColor = true;
            this.cboFromTo.CheckedChanged += new System.EventHandler(this.cboFromTo_CheckedChanged);
            // 
            // dtpkFrom
            // 
            this.dtpkFrom.CustomFormat = "dd - MMMM - yyyy";
            this.dtpkFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkFrom.Location = new System.Drawing.Point(696, 32);
            this.dtpkFrom.Name = "dtpkFrom";
            this.dtpkFrom.Size = new System.Drawing.Size(186, 26);
            this.dtpkFrom.TabIndex = 62;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Cyan;
            this.label3.Location = new System.Drawing.Point(622, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 60;
            this.label3.Text = "By Date";
            // 
            // cboMonth
            // 
            this.cboMonth.AutoSize = true;
            this.cboMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonth.Location = new System.Drawing.Point(549, 40);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(15, 14);
            this.cboMonth.TabIndex = 58;
            this.cboMonth.UseVisualStyleBackColor = true;
            this.cboMonth.CheckedChanged += new System.EventHandler(this.cboMonth_CheckedChanged);
            // 
            // dtpkMonth
            // 
            this.dtpkMonth.CustomFormat = "MMMM";
            this.dtpkMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkMonth.Location = new System.Drawing.Point(357, 32);
            this.dtpkMonth.Name = "dtpkMonth";
            this.dtpkMonth.Size = new System.Drawing.Size(186, 26);
            this.dtpkMonth.TabIndex = 57;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Yellow;
            this.label6.Location = new System.Drawing.Point(272, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 56;
            this.label6.Text = "By Month";
            // 
            // RepSaleProductSummary
            // 
            this.RepSaleProductSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RepSaleProductSummary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            reportDataSource1.Name = "SaleProductSummary";
            reportDataSource1.Value = this.xsdSummaryBindingSource;
            this.RepSaleProductSummary.LocalReport.DataSources.Add(reportDataSource1);
            this.RepSaleProductSummary.LocalReport.ReportEmbeddedResource = "BSSSoftware.Reporting.rdlcSaleProductSummary.rdlc";
            this.RepSaleProductSummary.Location = new System.Drawing.Point(0, 81);
            this.RepSaleProductSummary.Name = "RepSaleProductSummary";
            this.RepSaleProductSummary.Size = new System.Drawing.Size(1265, 473);
            this.RepSaleProductSummary.TabIndex = 58;
            // 
            // xsdSummary
            // 
            this.xsdSummary.DataSetName = "xsdSummary";
            this.xsdSummary.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SaleProductSummaryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 554);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.RepSaleProductSummary);
            this.Name = "SaleProductSummaryReport";
            this.Text = "SaleProductSummaryReport";
            ((System.ComponentModel.ISupportInitialize)(this.xsdSummaryBindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xsdSummary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource xsdSummaryBindingSource;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox cboFromTo;
        private System.Windows.Forms.DateTimePicker dtpkFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cboMonth;
        private System.Windows.Forms.DateTimePicker dtpkMonth;
        private System.Windows.Forms.Label label6;
        private Microsoft.Reporting.WinForms.ReportViewer RepSaleProductSummary;
        private BSSInfo.xsdSummary xsdSummary;

    }
}