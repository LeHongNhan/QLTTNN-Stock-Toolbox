namespace Views
{
    partial class frmXepLichHoc
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
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboThoiGian = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboThu = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnXoaLich = new System.Windows.Forms.Button();
            this.btnXeplich = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvTKB = new System.Windows.Forms.DataGridView();
            this.btnIn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKB)).BeginInit();
            this.SuspendLayout();
            // 
            // cboLop
            // 
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(13, 43);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(189, 24);
            this.cboLop.TabIndex = 0;
            this.cboLop.SelectedIndexChanged += new System.EventHandler(this.cboLop_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(873, 70);
            this.label1.TabIndex = 1;
            this.label1.Text = "Xếp lịch học";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chọn lớp";
            // 
            // cboThoiGian
            // 
            this.cboThoiGian.FormattingEnabled = true;
            this.cboThoiGian.Location = new System.Drawing.Point(13, 92);
            this.cboThoiGian.Name = "cboThoiGian";
            this.cboThoiGian.Size = new System.Drawing.Size(189, 24);
            this.cboThoiGian.TabIndex = 0;
            this.cboThoiGian.SelectedIndexChanged += new System.EventHandler(this.cboThoiGian_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Thời gian";
            // 
            // cboThu
            // 
            this.cboThu.FormattingEnabled = true;
            this.cboThu.Location = new System.Drawing.Point(13, 141);
            this.cboThu.Name = "cboThu";
            this.cboThu.Size = new System.Drawing.Size(189, 24);
            this.cboThu.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Thứ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnIn);
            this.groupBox1.Controls.Add(this.btnXoaLich);
            this.groupBox1.Controls.Add(this.btnXeplich);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboLop);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboThoiGian);
            this.groupBox1.Controls.Add(this.cboThu);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 433);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lựa chọn";
            // 
            // btnXoaLich
            // 
            this.btnXoaLich.Location = new System.Drawing.Point(12, 246);
            this.btnXoaLich.Name = "btnXoaLich";
            this.btnXoaLich.Size = new System.Drawing.Size(189, 42);
            this.btnXoaLich.TabIndex = 3;
            this.btnXoaLich.Text = "Xóa lịch";
            this.btnXoaLich.UseVisualStyleBackColor = true;
            this.btnXoaLich.Click += new System.EventHandler(this.btnXoaLich_Click);
            // 
            // btnXeplich
            // 
            this.btnXeplich.Location = new System.Drawing.Point(13, 198);
            this.btnXeplich.Name = "btnXeplich";
            this.btnXeplich.Size = new System.Drawing.Size(189, 42);
            this.btnXeplich.TabIndex = 3;
            this.btnXeplich.Text = "Xếp lịch";
            this.btnXeplich.UseVisualStyleBackColor = true;
            this.btnXeplich.Click += new System.EventHandler(this.btnXeplich_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvTKB);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(246, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(627, 433);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thời khóa biểu";
            // 
            // dgvTKB
            // 
            this.dgvTKB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTKB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTKB.Location = new System.Drawing.Point(3, 18);
            this.dgvTKB.Name = "dgvTKB";
            this.dgvTKB.RowHeadersWidth = 51;
            this.dgvTKB.RowTemplate.Height = 24;
            this.dgvTKB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTKB.Size = new System.Drawing.Size(621, 412);
            this.dgvTKB.TabIndex = 0;
            this.dgvTKB.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTKB_CellClick);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(17, 294);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(184, 116);
            this.btnIn.TabIndex = 4;
            this.btnIn.Text = "In lịch";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // frmXepLichHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 503);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmXepLichHoc";
            this.Text = "Xếp lịch học";
            this.Load += new System.EventHandler(this.frmXepLichHoc_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboThoiGian;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboThu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnXeplich;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvTKB;
        private System.Windows.Forms.Button btnXoaLich;
        private System.Windows.Forms.Button btnIn;
    }
}