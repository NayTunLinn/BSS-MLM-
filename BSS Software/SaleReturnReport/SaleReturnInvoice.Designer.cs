namespace BSSSoftware.SaleReturnReport
{
    partial class SaleReturnInvoice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnReceipt = new System.Windows.Forms.Button();
            this.btnDetailView = new System.Windows.Forms.Button();
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
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvDetailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvInvoiceDetails = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvInvoiceView = new System.Windows.Forms.DataGridView();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpperDistId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCusCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpperDistCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpperdistName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetails)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceView)).BeginInit();
            this.SuspendLayout();
            // 
            // Amount
            // 
            this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "##,##0";
            dataGridViewCellStyle1.NullValue = null;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle1;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.panel1.Controls.Add(this.btnReport);
            this.panel1.Controls.Add(this.btnReceipt);
            this.panel1.Controls.Add(this.btnDetailView);
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
            this.panel1.Size = new System.Drawing.Size(1363, 146);
            this.panel1.TabIndex = 2;
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
            this.btnReceipt.Click += new System.EventHandler(this.btnReceipt_Click);
            // 
            // btnDetailView
            // 
            this.btnDetailView.Location = new System.Drawing.Point(893, 60);
            this.btnDetailView.Name = "btnDetailView";
            this.btnDetailView.Size = new System.Drawing.Size(75, 33);
            this.btnDetailView.TabIndex = 10;
            this.btnDetailView.Text = "Details View";
            this.btnDetailView.UseVisualStyleBackColor = true;
            // 
            // cboFromTo
            // 
            this.cboFromTo.AutoSize = true;
            this.cboFromTo.Location = new System.Drawing.Point(657, 79);
            this.cboFromTo.Name = "cboFromTo";
            this.cboFromTo.Size = new System.Drawing.Size(15, 14);
            this.cboFromTo.TabIndex = 9;
            this.cboFromTo.UseVisualStyleBackColor = true;
            this.cboFromTo.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // cboDay
            // 
            this.cboDay.AutoSize = true;
            this.cboDay.Location = new System.Drawing.Point(657, 50);
            this.cboDay.Name = "cboDay";
            this.cboDay.Size = new System.Drawing.Size(15, 14);
            this.cboDay.TabIndex = 9;
            this.cboDay.UseVisualStyleBackColor = true;
            this.cboDay.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // cboMonth
            // 
            this.cboMonth.AutoSize = true;
            this.cboMonth.Location = new System.Drawing.Point(657, 21);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(15, 14);
            this.cboMonth.TabIndex = 9;
            this.cboMonth.UseVisualStyleBackColor = true;
            this.cboMonth.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
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
            this.dtpkMonth.ValueChanged += new System.EventHandler(this.dtpkMonth_ValueChanged);
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
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(731, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 33);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.dtpkTo.ValueChanged += new System.EventHandler(this.dtpkTo_ValueChanged);
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
            this.dtpkFrom.ValueChanged += new System.EventHandler(this.dtpkFrom_ValueChanged);
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
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Desp";
            this.dataGridViewTextBoxColumn12.HeaderText = "Description";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // ProductQty
            // 
            this.ProductQty.DataPropertyName = "ProductQty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "#,##0";
            this.ProductQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.ProductQty.HeaderText = "Qty";
            this.ProductQty.Name = "ProductQty";
            this.ProductQty.ReadOnly = true;
            this.ProductQty.Width = 80;
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Price.DataPropertyName = "Price";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "#,##0";
            this.Price.DefaultCellStyle = dataGridViewCellStyle3;
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "InvId";
            this.dataGridViewTextBoxColumn4.HeaderText = "InvId";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "Product Name ";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // InvDetailId
            // 
            this.InvDetailId.DataPropertyName = "InvDetailId";
            this.InvDetailId.HeaderText = "InvDetailId";
            this.InvDetailId.Name = "InvDetailId";
            this.InvDetailId.ReadOnly = true;
            this.InvDetailId.Visible = false;
            // 
            // ProductCode
            // 
            this.ProductCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductCode.DataPropertyName = "ProductCode";
            this.ProductCode.HeaderText = "Product Code";
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ProductId";
            this.dataGridViewTextBoxColumn1.HeaderText = "ProductId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dgvInvoiceDetails
            // 
            this.dgvInvoiceDetails.AllowUserToAddRows = false;
            this.dgvInvoiceDetails.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Honeydew;
            this.dgvInvoiceDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInvoiceDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInvoiceDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvInvoiceDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInvoiceDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(17)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("PoetsenOne", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvInvoiceDetails.ColumnHeadersHeight = 40;
            this.dgvInvoiceDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInvoiceDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn4,
            this.InvDetailId,
            this.ProductCode,
            this.ProductName,
            this.Price,
            this.ProductQty,
            this.Amount,
            this.dataGridViewTextBoxColumn12});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInvoiceDetails.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvInvoiceDetails.EnableHeadersVisualStyles = false;
            this.dgvInvoiceDetails.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvInvoiceDetails.Location = new System.Drawing.Point(836, 0);
            this.dgvInvoiceDetails.MultiSelect = false;
            this.dgvInvoiceDetails.Name = "dgvInvoiceDetails";
            this.dgvInvoiceDetails.ReadOnly = true;
            this.dgvInvoiceDetails.RowHeadersWidth = 30;
            this.dgvInvoiceDetails.RowTemplate.Height = 30;
            this.dgvInvoiceDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoiceDetails.Size = new System.Drawing.Size(524, 415);
            this.dgvInvoiceDetails.TabIndex = 1;
            this.dgvInvoiceDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_DataBindingComplete);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dgvInvoiceDetails);
            this.panel2.Controls.Add(this.dgvInvoiceView);
            this.panel2.Location = new System.Drawing.Point(0, 153);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1363, 418);
            this.panel2.TabIndex = 1;
            // 
            // dgvInvoiceView
            // 
            this.dgvInvoiceView.AllowUserToAddRows = false;
            this.dgvInvoiceView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Honeydew;
            this.dgvInvoiceView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvInvoiceView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInvoiceView.BackgroundColor = System.Drawing.Color.White;
            this.dgvInvoiceView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInvoiceView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("PoetsenOne", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvInvoiceView.ColumnHeadersHeight = 40;
            this.dgvInvoiceView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInvoiceView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductId,
            this.colCustomerId,
            this.colUpperDistId,
            this.colInvId,
            this.colCusCode,
            this.cusName,
            this.colInvNo,
            this.colUpperDistCode,
            this.colUpperdistName,
            this.colTotalAmount,
            this.colInvDate,
            this.Desp,
            this.colTitle});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInvoiceView.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvInvoiceView.EnableHeadersVisualStyles = false;
            this.dgvInvoiceView.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvInvoiceView.Location = new System.Drawing.Point(0, 0);
            this.dgvInvoiceView.MultiSelect = false;
            this.dgvInvoiceView.Name = "dgvInvoiceView";
            this.dgvInvoiceView.ReadOnly = true;
            this.dgvInvoiceView.RowHeadersWidth = 30;
            this.dgvInvoiceView.RowTemplate.Height = 30;
            this.dgvInvoiceView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoiceView.Size = new System.Drawing.Size(835, 415);
            this.dgvInvoiceView.TabIndex = 1;
            this.dgvInvoiceView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoiceView_CellDoubleClick);
            this.dgvInvoiceView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_DataBindingComplete);
            this.dgvInvoiceView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_RowsAdded);
            // 
            // colProductId
            // 
            this.colProductId.DataPropertyName = "ProductId";
            this.colProductId.HeaderText = "ProductId";
            this.colProductId.Name = "colProductId";
            this.colProductId.ReadOnly = true;
            this.colProductId.Visible = false;
            // 
            // colCustomerId
            // 
            this.colCustomerId.DataPropertyName = "CustomerId";
            this.colCustomerId.HeaderText = "Customer Id";
            this.colCustomerId.Name = "colCustomerId";
            this.colCustomerId.ReadOnly = true;
            this.colCustomerId.Visible = false;
            // 
            // colUpperDistId
            // 
            this.colUpperDistId.DataPropertyName = "UpperDistributerId";
            this.colUpperDistId.HeaderText = "Upper Dist Id";
            this.colUpperDistId.Name = "colUpperDistId";
            this.colUpperDistId.ReadOnly = true;
            this.colUpperDistId.Visible = false;
            // 
            // colInvId
            // 
            this.colInvId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colInvId.DataPropertyName = "InvId";
            this.colInvId.HeaderText = "InvId";
            this.colInvId.Name = "colInvId";
            this.colInvId.ReadOnly = true;
            this.colInvId.Visible = false;
            // 
            // colCusCode
            // 
            this.colCusCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCusCode.DataPropertyName = "CustomerCode";
            this.colCusCode.HeaderText = "Customer Code";
            this.colCusCode.Name = "colCusCode";
            this.colCusCode.ReadOnly = true;
            this.colCusCode.Visible = false;
            // 
            // cusName
            // 
            this.cusName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cusName.DataPropertyName = "CustomerName";
            this.cusName.HeaderText = "Customer Name";
            this.cusName.Name = "cusName";
            this.cusName.ReadOnly = true;
            this.cusName.Visible = false;
            // 
            // colInvNo
            // 
            this.colInvNo.DataPropertyName = "InvNo";
            this.colInvNo.HeaderText = "Inv No";
            this.colInvNo.Name = "colInvNo";
            this.colInvNo.ReadOnly = true;
            // 
            // colUpperDistCode
            // 
            this.colUpperDistCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUpperDistCode.DataPropertyName = "UpperDistCode";
            this.colUpperDistCode.HeaderText = "Distributor Code";
            this.colUpperDistCode.Name = "colUpperDistCode";
            this.colUpperDistCode.ReadOnly = true;
            // 
            // colUpperdistName
            // 
            this.colUpperdistName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUpperdistName.DataPropertyName = "UpperDistName";
            this.colUpperdistName.HeaderText = "Distributor Name";
            this.colUpperdistName.Name = "colUpperdistName";
            this.colUpperdistName.ReadOnly = true;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.DataPropertyName = "TotalAmount";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "#,##0";
            this.colTotalAmount.DefaultCellStyle = dataGridViewCellStyle9;
            this.colTotalAmount.HeaderText = "Total Amount";
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.ReadOnly = true;
            this.colTotalAmount.Width = 120;
            // 
            // colInvDate
            // 
            this.colInvDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colInvDate.DataPropertyName = "InvDate";
            this.colInvDate.HeaderText = "Inv Date";
            this.colInvDate.Name = "colInvDate";
            this.colInvDate.ReadOnly = true;
            // 
            // Desp
            // 
            this.Desp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Desp.DataPropertyName = "Desp";
            this.Desp.HeaderText = "Desp";
            this.Desp.Name = "Desp";
            this.Desp.ReadOnly = true;
            // 
            // colTitle
            // 
            this.colTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTitle.DataPropertyName = "Title";
            this.colTitle.HeaderText = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            this.colTitle.Visible = false;
            // 
            // SaleReturnInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 573);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "SaleReturnInvoice";
            this.Text = "SaleReturnInvoice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetails)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnReceipt;
        private System.Windows.Forms.Button btnDetailView;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvDetailId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView dgvInvoiceDetails;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvInvoiceView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpperDistId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpperDistCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpperdistName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
    }
}