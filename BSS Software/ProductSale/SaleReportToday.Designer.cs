namespace BSSSoftware.SaleReturnReport
{
    partial class SaleReportToday
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSale = new System.Windows.Forms.DataGridView();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpperDistId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCusCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpperDistCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpperdistName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSale)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSale
            // 
            this.dgvSale.AllowUserToAddRows = false;
            this.dgvSale.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Honeydew;
            this.dgvSale.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSale.BackgroundColor = System.Drawing.Color.White;
            this.dgvSale.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSale.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSale.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSale.ColumnHeadersHeight = 30;
            this.dgvSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSale.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductId,
            this.colCustomerId,
            this.colUpperDistId,
            this.colInvId,
            this.colInvNo,
            this.colCusCode,
            this.cusName,
            this.colUpperDistCode,
            this.colUpperdistName,
            this.colInvDate,
            this.colTitle,
            this.colTotalAmount});
            this.dgvSale.EnableHeadersVisualStyles = false;
            this.dgvSale.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvSale.Location = new System.Drawing.Point(0, 43);
            this.dgvSale.MultiSelect = false;
            this.dgvSale.Name = "dgvSale";
            this.dgvSale.ReadOnly = true;
            this.dgvSale.RowHeadersWidth = 30;
            this.dgvSale.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSale.Size = new System.Drawing.Size(1161, 503);
            this.dgvSale.TabIndex = 2;
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
            this.colCustomerId.HeaderText = "Customer Id";
            this.colCustomerId.Name = "colCustomerId";
            this.colCustomerId.ReadOnly = true;
            this.colCustomerId.Visible = false;
            // 
            // colUpperDistId
            // 
            this.colUpperDistId.HeaderText = "Upper Dist Id";
            this.colUpperDistId.Name = "colUpperDistId";
            this.colUpperDistId.ReadOnly = true;
            // 
            // colInvId
            // 
            this.colInvId.HeaderText = "InvId";
            this.colInvId.Name = "colInvId";
            this.colInvId.ReadOnly = true;
            this.colInvId.Visible = false;
            // 
            // colInvNo
            // 
            this.colInvNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colInvNo.HeaderText = "Inv No";
            this.colInvNo.Name = "colInvNo";
            this.colInvNo.ReadOnly = true;
            // 
            // colCusCode
            // 
            this.colCusCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCusCode.HeaderText = "Customer Code";
            this.colCusCode.Name = "colCusCode";
            this.colCusCode.ReadOnly = true;
            // 
            // cusName
            // 
            this.cusName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cusName.HeaderText = "Customer Name";
            this.cusName.Name = "cusName";
            this.cusName.ReadOnly = true;
            // 
            // colUpperDistCode
            // 
            this.colUpperDistCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUpperDistCode.HeaderText = "UpperdistCode";
            this.colUpperDistCode.Name = "colUpperDistCode";
            this.colUpperDistCode.ReadOnly = true;
            // 
            // colUpperdistName
            // 
            this.colUpperdistName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUpperdistName.HeaderText = "UpperdistName";
            this.colUpperdistName.Name = "colUpperdistName";
            this.colUpperdistName.ReadOnly = true;
            // 
            // colInvDate
            // 
            this.colInvDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colInvDate.HeaderText = "Inv Date";
            this.colInvDate.Name = "colInvDate";
            this.colInvDate.ReadOnly = true;
            // 
            // colTitle
            // 
            this.colTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTitle.HeaderText = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTotalAmount.HeaderText = "Total Amount";
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.ReadOnly = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(140, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(135, 20);
            this.textBox1.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(360, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(113, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Invoice No";
            // 
            // SaleReportToday
            // 
            this.ClientSize = new System.Drawing.Size(1160, 531);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgvSale);
            this.Name = "SaleReportToday";
            this.Load += new System.EventHandler(this.SaleReportToday_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSale;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpperDistId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpperDistCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpperdistName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;

    }
}