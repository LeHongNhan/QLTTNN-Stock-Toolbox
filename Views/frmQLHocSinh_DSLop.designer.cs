namespace Views
{
    partial class frmQLHocSinh_DSLop
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDSHocSinh = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHocSinh)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(629, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách học sinh";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvDSHocSinh
            // 
            this.dgvDSHocSinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSHocSinh.Location = new System.Drawing.Point(12, 77);
            this.dgvDSHocSinh.Name = "dgvDSHocSinh";
            this.dgvDSHocSinh.RowHeadersWidth = 51;
            this.dgvDSHocSinh.RowTemplate.Height = 24;
            this.dgvDSHocSinh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDSHocSinh.Size = new System.Drawing.Size(605, 362);
            this.dgvDSHocSinh.TabIndex = 1;
            this.dgvDSHocSinh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSHocSinh_CellClick);
            this.dgvDSHocSinh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSHocSinh_CellContentClick);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 445);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(605, 58);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // frmQLHocSinh_DSLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 539);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvDSHocSinh);
            this.Controls.Add(this.label1);
            this.Name = "frmQLHocSinh_DSLop";
            this.Text = "Quản lý học sinh";
            this.Load += new System.EventHandler(this.frmQLHocSinh_DSLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHocSinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDSHocSinh;
        private System.Windows.Forms.Button btnThem;
    }
}