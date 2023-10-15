namespace BSSSoftware.SaleReturnReport
{
    partial class SaleReturnReporting
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
            this.rptSaleReturn = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnReceipt = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cboFromTo = new System.Windows.Forms.CheckBox();
            this.cboDay = new System.Windows.Forms.CheckBox();
            this.cboMonth = new System.Windows.Forms.CheckBox();
            this.dtpkMonth = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpkDay = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpkTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpkFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMerchantCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtinvoiceno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rptSaleReturn
            // 
            this.rptSaleReturn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptSaleReturn.Location = new System.Drawing.Point(0, 0);
            this.rptSaleReturn.Name = "rptSaleReturn";
            this.rptSaleReturn.Size = new System.Drawing.Size(1207, 351);
            this.rptSaleReturn.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.panel1.Controls.Add(this.btnReport);
            this.panel1.Controls.Add(this.btnReceipt);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.cboFromTo);
            this.panel1.Controls.Add(this.cboDay);
            this.panel1.Controls.Add(this.cboMonth);
            this.panel1.Controls.Add(this.dtpkMonth);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtpkDay);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dtpkTo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpkFrom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtMerchantCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtinvoiceno);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1584, 146);
            this.panel1.TabIndex = 1;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(1055, 60);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 33);
            this.btnReport.TabIndex = 12;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            // 
            // btnReceipt
            // 
            this.btnReceipt.Location = new System.Drawing.Point(974, 60);
            this.btnReceipt.Name = "btnReceipt";
            this.btnReceipt.Size = new System.Drawing.Size(75, 33);
            this.btnReceipt.TabIndex = 11;
            this.btnReceipt.Text = "Receipt";
            this.btnReceipt.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(893, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 33);
            this.button1.TabIndex = 10;
            this.button1.Text = "Details View";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cboFromTo
            // 
            this.cboFromTo.AutoSize = true;
            this.cboFromTo.Location = new System.Drawing.Point(657, 79);
            this.cboFromTo.Name = "cboFromTo";
            this.cboFromTo.Size = new System.Drawing.Size(15, 14);
            this.cboFromTo.TabIndex = 9;
            this.cboFromTo.UseVisualStyleBackColor = true;
            // 
            // cboDay
            // 
            this.cboDay.AutoSize = true;
            this.cboDay.Location = new System.Drawing.Point(657, 50);
            this.cboDay.Name = "cboDay";
            this.cboDay.Size = new System.Drawing.Size(15, 14);
            this.cboDay.TabIndex = 9;
            this.cboDay.UseVisualStyleBackColor = true;
            // 
            // cboMonth
            // 
            this.cboMonth.AutoSize = true;
            this.cboMonth.Location = new System.Drawing.Point(657, 21);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(15, 14);
            this.cboMonth.TabIndex = 9;
            this.cboMonth.UseVisualStyleBackColor = true;
            // 
            // dtpkMonth
            // 
            this.dtpkMonth.CustomFormat = "MMMM";
            this.dtpkMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkMonth.Location = new System.Drawing.Point(465, 18);
            this.dtpkMonth.Name = "dtpkMonth";
            this.dtpkMonth.Size = new System.Drawing.Size(186, 23);
            this.dtpkMonth.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("PoetsenOne", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Yellow;
            this.label6.Location = new System.Drawing.Point(408, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Month";
            // 
            // dtpkDay
            // 
            this.dtpkDay.CustomFormat = "dd - MMMM - yyyy";
            this.dtpkDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkDay.Location = new System.Drawing.Point(465, 47);
            this.dtpkDay.Name = "dtpkDay";
            this.dtpkDay.Size = new System.Drawing.Size(186, 23);
            this.dtpkDay.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("PoetsenOne", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(427, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Day";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(812, 60);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 33);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(731, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 33);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // dtpkTo
            // 
            this.dtpkTo.CustomFormat = "dd - MMMM - yyyy";
            this.dtpkTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkTo.Location = new System.Drawing.Point(465, 105);
            this.dtpkTo.Name = "dtpkTo";
            this.dtpkTo.Size = new System.Drawing.Size(186, 23);
            this.dtpkTo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("PoetsenOne", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Cyan;
            this.label4.Location = new System.Drawing.Point(438, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "To";
            // 
            // dtpkFrom
            // 
            this.dtpkFrom.CustomFormat = "dd - MMMM - yyyy";
            this.dtpkFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkFrom.Location = new System.Drawing.Point(465, 76);
            this.dtpkFrom.Name = "dtpkFrom";
            this.dtpkFrom.Size = new System.Drawing.Size(186, 23);
            this.dtpkFrom.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("PoetsenOne", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Cyan;
            this.label3.Location = new System.Drawing.Point(418, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "From";
            // 
            // txtMerchantCode
            // 
            this.txtMerchantCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtMerchantCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtMerchantCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMerchantCode.Location = new System.Drawing.Point(164, 76);
            this.txtMerchantCode.Name = "txtMerchantCode";
            this.txtMerchantCode.Size = new System.Drawing.Size(221, 23);
            this.txtMerchantCode.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PoetsenOne", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(43, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Distributor Code";
            // 
            // txtinvoiceno
            // 
            this.txtinvoiceno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtinvoiceno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtinvoiceno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtinvoiceno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtinvoiceno.Location = new System.Drawing.Point(164, 47);
            this.txtinvoiceno.Name = "txtinvoiceno";
            this.txtinvoiceno.Size = new System.Drawing.Size(221, 23);
            this.txtinvoiceno.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PoetsenOne", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(85, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invoice No";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.rptSaleReturn);
            this.panel2.Location = new System.Drawing.Point(0, 150);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1207, 351);
            this.panel2.TabIndex = 2;
            // 
            // SaleReturnReporting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 502);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SaleReturnReporting";
            this.Text = "Sale Return Report";
            this.Load += new System.EventHandler(this.SaleReturnReporting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptSaleReturn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnReceipt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cboFromTo;
        private System.Windows.Forms.CheckBox cboDay;
        private System.Windows.Forms.CheckBox cboMonth;
        private System.Windows.Forms.DateTimePicker dtpkMonth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpkDay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpkTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpkFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMerchantCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtinvoiceno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
    }
}