﻿namespace BSSSoftware.CodeSetup
{
    partial class Religion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEntry = new System.Windows.Forms.Panel();
            this.txtDesp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtReligion = new System.Windows.Forms.TextBox();
            this.dgvReligion = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.colReligionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReligion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReligion)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEntry
            // 
            this.panelEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.panelEntry.Controls.Add(this.txtDesp);
            this.panelEntry.Controls.Add(this.label7);
            this.panelEntry.Controls.Add(this.label8);
            this.panelEntry.Controls.Add(this.txtReligion);
            this.panelEntry.Location = new System.Drawing.Point(73, 51);
            this.panelEntry.Name = "panelEntry";
            this.panelEntry.Size = new System.Drawing.Size(476, 181);
            this.panelEntry.TabIndex = 0;
            this.panelEntry.Visible = false;
            // 
            // txtDesp
            // 
            this.txtDesp.Location = new System.Drawing.Point(138, 65);
            this.txtDesp.Multiline = true;
            this.txtDesp.Name = "txtDesp";
            this.txtDesp.Size = new System.Drawing.Size(286, 57);
            this.txtDesp.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("PoetsenOne", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(42, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 18);
            this.label7.TabIndex = 2;
            this.label7.Text = "Description";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("PoetsenOne", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(68, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 18);
            this.label8.TabIndex = 2;
            this.label8.Text = "Religion";
            // 
            // txtReligion
            // 
            this.txtReligion.Location = new System.Drawing.Point(138, 39);
            this.txtReligion.Name = "txtReligion";
            this.txtReligion.Size = new System.Drawing.Size(199, 20);
            this.txtReligion.TabIndex = 1;
            // 
            // dgvReligion
            // 
            this.dgvReligion.AllowUserToAddRows = false;
            this.dgvReligion.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Honeydew;
            this.dgvReligion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvReligion.BackgroundColor = System.Drawing.Color.White;
            this.dgvReligion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReligion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReligion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvReligion.ColumnHeadersHeight = 30;
            this.dgvReligion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReligion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colReligionId,
            this.colReligion,
            this.colDesp});
            this.dgvReligion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReligion.EnableHeadersVisualStyles = false;
            this.dgvReligion.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvReligion.Location = new System.Drawing.Point(0, 0);
            this.dgvReligion.MultiSelect = false;
            this.dgvReligion.Name = "dgvReligion";
            this.dgvReligion.ReadOnly = true;
            this.dgvReligion.RowHeadersWidth = 30;
            this.dgvReligion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReligion.Size = new System.Drawing.Size(600, 444);
            this.dgvReligion.TabIndex = 45;
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
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(91, 15);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 46;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(605, 53);
            this.panel1.TabIndex = 57;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(10, 15);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 46;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(519, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(172, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 46;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.panelEntry);
            this.panel2.Controls.Add(this.dgvReligion);
            this.panel2.Location = new System.Drawing.Point(2, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 444);
            this.panel2.TabIndex = 58;
            // 
            // colReligionId
            // 
            this.colReligionId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colReligionId.DataPropertyName = "ReligionId";
            this.colReligionId.HeaderText = "ReligionId";
            this.colReligionId.Name = "colReligionId";
            this.colReligionId.ReadOnly = true;
            this.colReligionId.Visible = false;
            // 
            // colReligion
            // 
            this.colReligion.DataPropertyName = "Religion";
            this.colReligion.HeaderText = "Religion";
            this.colReligion.Name = "colReligion";
            this.colReligion.ReadOnly = true;
            this.colReligion.Width = 200;
            // 
            // colDesp
            // 
            this.colDesp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDesp.DataPropertyName = "Desp";
            this.colDesp.HeaderText = "Desp";
            this.colDesp.Name = "colDesp";
            this.colDesp.ReadOnly = true;
            // 
            // Religion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 507);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MinimizeBox = false;
            this.Name = "Religion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Religion";
            this.panelEntry.ResumeLayout(false);
            this.panelEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReligion)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelEntry;
        private System.Windows.Forms.TextBox txtDesp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtReligion;
        private System.Windows.Forms.DataGridView dgvReligion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReligionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReligion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel2;
    }
}