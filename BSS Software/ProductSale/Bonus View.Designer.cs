namespace BSSSoftware.SaleReturnReport
{
    partial class Bonus_View
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.cboTarget = new System.Windows.Forms.CheckBox();
            this.txtInvNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTotal = new System.Windows.Forms.CheckBox();
            this.cboFromTo = new System.Windows.Forms.CheckBox();
            this.cboDay = new System.Windows.Forms.CheckBox();
            this.cboMonth = new System.Windows.Forms.CheckBox();
            this.dtpkMonth = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpkDay = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpkTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpkFrom = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnsearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvBonusView = new System.Windows.Forms.DataGridView();
            this.colBonusId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPersonId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvDetailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPersonCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPersonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonusView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.cboTarget);
            this.panel1.Controls.Add(this.txtInvNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboTotal);
            this.panel1.Controls.Add(this.cboFromTo);
            this.panel1.Controls.Add(this.cboDay);
            this.panel1.Controls.Add(this.cboMonth);
            this.panel1.Controls.Add(this.dtpkMonth);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtpkDay);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dtpkTo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpkFrom);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnsearch);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1229, 140);
            this.panel1.TabIndex = 59;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(825, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 38);
            this.button2.TabIndex = 71;
            this.button2.Text = "Bonus Detail";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cboTarget
            // 
            this.cboTarget.AutoSize = true;
            this.cboTarget.Font = new System.Drawing.Font("PoetsenOne", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTarget.Location = new System.Drawing.Point(957, 15);
            this.cboTarget.Name = "cboTarget";
            this.cboTarget.Size = new System.Drawing.Size(169, 23);
            this.cboTarget.TabIndex = 70;
            this.cboTarget.Text = "Over Target Points";
            this.cboTarget.UseVisualStyleBackColor = true;
            this.cboTarget.CheckedChanged += new System.EventHandler(this.cboTarget_CheckedChanged);
            // 
            // txtInvNo
            // 
            this.txtInvNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtInvNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtInvNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtInvNo.Location = new System.Drawing.Point(108, 25);
            this.txtInvNo.Name = "txtInvNo";
            this.txtInvNo.Size = new System.Drawing.Size(274, 26);
            this.txtInvNo.TabIndex = 69;
            this.txtInvNo.TextChanged += new System.EventHandler(this.txtInvNo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(39, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 68;
            this.label1.Text = "Inv No";
            // 
            // cboTotal
            // 
            this.cboTotal.AutoSize = true;
            this.cboTotal.Checked = true;
            this.cboTotal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboTotal.Font = new System.Drawing.Font("PoetsenOne", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTotal.Location = new System.Drawing.Point(825, 15);
            this.cboTotal.Name = "cboTotal";
            this.cboTotal.Size = new System.Drawing.Size(111, 23);
            this.cboTotal.TabIndex = 67;
            this.cboTotal.Text = "Show Total";
            this.cboTotal.UseVisualStyleBackColor = true;
            this.cboTotal.CheckedChanged += new System.EventHandler(this.cboTotal_CheckedChanged);
            // 
            // cboFromTo
            // 
            this.cboFromTo.AutoSize = true;
            this.cboFromTo.Location = new System.Drawing.Point(731, 76);
            this.cboFromTo.Name = "cboFromTo";
            this.cboFromTo.Size = new System.Drawing.Size(15, 14);
            this.cboFromTo.TabIndex = 64;
            this.cboFromTo.UseVisualStyleBackColor = true;
            this.cboFromTo.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // cboDay
            // 
            this.cboDay.AutoSize = true;
            this.cboDay.Location = new System.Drawing.Point(731, 47);
            this.cboDay.Name = "cboDay";
            this.cboDay.Size = new System.Drawing.Size(15, 14);
            this.cboDay.TabIndex = 65;
            this.cboDay.UseVisualStyleBackColor = true;
            this.cboDay.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // cboMonth
            // 
            this.cboMonth.AutoSize = true;
            this.cboMonth.Location = new System.Drawing.Point(731, 18);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(15, 14);
            this.cboMonth.TabIndex = 66;
            this.cboMonth.UseVisualStyleBackColor = true;
            this.cboMonth.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // dtpkMonth
            // 
            this.dtpkMonth.CustomFormat = "MMMM";
            this.dtpkMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkMonth.Location = new System.Drawing.Point(539, 15);
            this.dtpkMonth.Name = "dtpkMonth";
            this.dtpkMonth.Size = new System.Drawing.Size(186, 23);
            this.dtpkMonth.TabIndex = 63;
            this.dtpkMonth.ValueChanged += new System.EventHandler(this.dtpkMonth_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("PoetsenOne", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Yellow;
            this.label6.Location = new System.Drawing.Point(482, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 62;
            this.label6.Text = "Month";
            // 
            // dtpkDay
            // 
            this.dtpkDay.CustomFormat = "dd - MMMM - yyyy";
            this.dtpkDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkDay.Location = new System.Drawing.Point(539, 44);
            this.dtpkDay.Name = "dtpkDay";
            this.dtpkDay.Size = new System.Drawing.Size(186, 23);
            this.dtpkDay.TabIndex = 61;
            this.dtpkDay.ValueChanged += new System.EventHandler(this.dtpkDay_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("PoetsenOne", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(501, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 17);
            this.label5.TabIndex = 60;
            this.label5.Text = "Day";
            // 
            // dtpkTo
            // 
            this.dtpkTo.CustomFormat = "dd - MMMM - yyyy";
            this.dtpkTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkTo.Location = new System.Drawing.Point(539, 102);
            this.dtpkTo.Name = "dtpkTo";
            this.dtpkTo.Size = new System.Drawing.Size(186, 23);
            this.dtpkTo.TabIndex = 58;
            this.dtpkTo.ValueChanged += new System.EventHandler(this.dtpkTo_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("PoetsenOne", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Cyan;
            this.label4.Location = new System.Drawing.Point(512, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 17);
            this.label4.TabIndex = 56;
            this.label4.Text = "To";
            // 
            // dtpkFrom
            // 
            this.dtpkFrom.CustomFormat = "dd - MMMM - yyyy";
            this.dtpkFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkFrom.Location = new System.Drawing.Point(539, 73);
            this.dtpkFrom.Name = "dtpkFrom";
            this.dtpkFrom.Size = new System.Drawing.Size(186, 23);
            this.dtpkFrom.TabIndex = 59;
            this.dtpkFrom.ValueChanged += new System.EventHandler(this.dtpkFrom_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("PoetsenOne", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Cyan;
            this.label7.Location = new System.Drawing.Point(492, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 17);
            this.label7.TabIndex = 57;
            this.label7.Text = "From";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(921, 52);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 38);
            this.btnPrint.TabIndex = 55;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtName
            // 
            this.txtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtName.Location = new System.Drawing.Point(108, 89);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(274, 26);
            this.txtName.TabIndex = 54;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(44, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 53;
            this.label3.Text = "Name";
            // 
            // txtCode
            // 
            this.txtCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCode.Location = new System.Drawing.Point(108, 57);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(274, 26);
            this.txtCode.TabIndex = 52;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(48, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 51;
            this.label2.Text = "Code";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(1017, 51);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 38);
            this.btnRefresh.TabIndex = 50;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnsearch
            // 
            this.btnsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.Location = new System.Drawing.Point(825, 52);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(90, 38);
            this.btnsearch.TabIndex = 49;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1113, 51);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 38);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(-78, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 46;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dgvBonusView);
            this.panel2.Location = new System.Drawing.Point(2, 141);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1229, 386);
            this.panel2.TabIndex = 60;
            // 
            // dgvBonusView
            // 
            this.dgvBonusView.AllowUserToAddRows = false;
            this.dgvBonusView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Honeydew;
            this.dgvBonusView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBonusView.BackgroundColor = System.Drawing.Color.White;
            this.dgvBonusView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBonusView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBonusView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBonusView.ColumnHeadersHeight = 40;
            this.dgvBonusView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBonusView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBonusId,
            this.InvId,
            this.colPersonId,
            this.colInvDetailId,
            this.colPersonCode,
            this.colPersonName,
            this.ProductName,
            this.Qty,
            this.colBonus,
            this.colRank,
            this.colDate,
            this.colDesp});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBonusView.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBonusView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBonusView.EnableHeadersVisualStyles = false;
            this.dgvBonusView.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvBonusView.Location = new System.Drawing.Point(0, 0);
            this.dgvBonusView.MultiSelect = false;
            this.dgvBonusView.Name = "dgvBonusView";
            this.dgvBonusView.ReadOnly = true;
            this.dgvBonusView.RowHeadersWidth = 30;
            this.dgvBonusView.RowTemplate.Height = 30;
            this.dgvBonusView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBonusView.Size = new System.Drawing.Size(1229, 386);
            this.dgvBonusView.TabIndex = 46;
            this.dgvBonusView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_DataBindingComplete);
            // 
            // colBonusId
            // 
            this.colBonusId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBonusId.DataPropertyName = "BonusId";
            this.colBonusId.HeaderText = "BonusId";
            this.colBonusId.Name = "colBonusId";
            this.colBonusId.ReadOnly = true;
            this.colBonusId.Visible = false;
            // 
            // InvId
            // 
            this.InvId.DataPropertyName = "Invid";
            this.InvId.HeaderText = "InvId";
            this.InvId.Name = "InvId";
            this.InvId.ReadOnly = true;
            this.InvId.Visible = false;
            // 
            // colPersonId
            // 
            this.colPersonId.DataPropertyName = "PersonId";
            this.colPersonId.HeaderText = "PersonId";
            this.colPersonId.Name = "colPersonId";
            this.colPersonId.ReadOnly = true;
            this.colPersonId.Visible = false;
            this.colPersonId.Width = 200;
            // 
            // colInvDetailId
            // 
            this.colInvDetailId.DataPropertyName = "InvDetailId";
            this.colInvDetailId.HeaderText = "InvDetailId";
            this.colInvDetailId.Name = "colInvDetailId";
            this.colInvDetailId.ReadOnly = true;
            this.colInvDetailId.Visible = false;
            // 
            // colPersonCode
            // 
            this.colPersonCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPersonCode.DataPropertyName = "PersonCode";
            this.colPersonCode.HeaderText = "Person Code";
            this.colPersonCode.Name = "colPersonCode";
            this.colPersonCode.ReadOnly = true;
            // 
            // colPersonName
            // 
            this.colPersonName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPersonName.DataPropertyName = "PersonName";
            this.colPersonName.HeaderText = "Person Name";
            this.colPersonName.Name = "colPersonName";
            this.colPersonName.ReadOnly = true;
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "ProductQty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Qty.DefaultCellStyle = dataGridViewCellStyle3;
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // colBonus
            // 
            this.colBonus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBonus.DataPropertyName = "Bonus";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colBonus.DefaultCellStyle = dataGridViewCellStyle4;
            this.colBonus.HeaderText = "Bonus";
            this.colBonus.Name = "colBonus";
            this.colBonus.ReadOnly = true;
            // 
            // colRank
            // 
            this.colRank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRank.DataPropertyName = "Rank";
            this.colRank.HeaderText = "Rank";
            this.colRank.Name = "colRank";
            this.colRank.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDate.DataPropertyName = "Date";
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colDesp
            // 
            this.colDesp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDesp.DataPropertyName = "Desp";
            this.colDesp.HeaderText = "Desp";
            this.colDesp.Name = "colDesp";
            this.colDesp.ReadOnly = true;
            // 
            // Bonus_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 527);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Bonus_View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bonus_View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonusView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.DataGridView dgvBonusView;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.CheckBox cboFromTo;
        private System.Windows.Forms.CheckBox cboDay;
        private System.Windows.Forms.CheckBox cboMonth;
        private System.Windows.Forms.DateTimePicker dtpkMonth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpkDay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpkTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpkFrom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cboTotal;
        private System.Windows.Forms.CheckBox cboTarget;
        private System.Windows.Forms.TextBox txtInvNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBonusId;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPersonId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvDetailId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPersonCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPersonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesp;
        private System.Windows.Forms.Button button2;
    }
}