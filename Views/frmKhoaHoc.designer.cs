namespace Views
{
    partial class frmKhoaHoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhoaHoc));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvThongTin = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.iconList = new System.Windows.Forms.ImageList(this.components);
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCapDo = new System.Windows.Forms.Button();
            this.btnDoTuoi = new System.Windows.Forms.Button();
            this.txtTenKhoa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongTin)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvThongTin);
            this.groupBox4.Location = new System.Drawing.Point(361, 108);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(671, 423);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Danh sách khóa học";
            // 
            // dgvThongTin
            // 
            this.dgvThongTin.AllowUserToAddRows = false;
            this.dgvThongTin.AllowUserToDeleteRows = false;
            this.dgvThongTin.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongTin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongTin.Location = new System.Drawing.Point(22, 31);
            this.dgvThongTin.Name = "dgvThongTin";
            this.dgvThongTin.ReadOnly = true;
            this.dgvThongTin.RowHeadersWidth = 51;
            this.dgvThongTin.RowTemplate.Height = 24;
            this.dgvThongTin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongTin.Size = new System.Drawing.Size(639, 386);
            this.dgvThongTin.TabIndex = 0;
            this.dgvThongTin.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThongTin_CellClick);
            this.dgvThongTin.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThongTin_CellContentClick);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1028, 105);
            this.label5.TabIndex = 18;
            this.label5.Text = "DANH SÁCH KHÓA HỌC";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.White;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.ImageIndex = 1;
            this.btnThem.ImageList = this.iconList;
            this.btnThem.Location = new System.Drawing.Point(15, 153);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(96, 34);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // iconList
            // 
            this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
            this.iconList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconList.Images.SetKeyName(0, "Sua.png");
            this.iconList.Images.SetKeyName(1, "Them.png");
            this.iconList.Images.SetKeyName(2, "Xoa.png");
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.BackColor = System.Drawing.Color.White;
            this.btnCapNhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapNhat.ImageIndex = 0;
            this.btnCapNhat.ImageList = this.iconList;
            this.btnCapNhat.Location = new System.Drawing.Point(120, 153);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(94, 34);
            this.btnCapNhat.TabIndex = 6;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCapDo);
            this.groupBox2.Controls.Add(this.btnDoTuoi);
            this.groupBox2.Controls.Add(this.txtTenKhoa);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnCapNhat);
            this.groupBox2.Controls.Add(this.btnThem);
            this.groupBox2.Location = new System.Drawing.Point(-3, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 193);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin";
            // 
            // btnCapDo
            // 
            this.btnCapDo.Location = new System.Drawing.Point(15, 100);
            this.btnCapDo.Name = "btnCapDo";
            this.btnCapDo.Size = new System.Drawing.Size(313, 33);
            this.btnCapDo.TabIndex = 11;
            this.btnCapDo.Text = "Chọn Cấp Độ";
            this.btnCapDo.UseVisualStyleBackColor = true;
            this.btnCapDo.Click += new System.EventHandler(this.btnCapDo_Click);
            // 
            // btnDoTuoi
            // 
            this.btnDoTuoi.Location = new System.Drawing.Point(14, 61);
            this.btnDoTuoi.Name = "btnDoTuoi";
            this.btnDoTuoi.Size = new System.Drawing.Size(313, 33);
            this.btnDoTuoi.TabIndex = 11;
            this.btnDoTuoi.Text = "Chọn Độ Tuổi";
            this.btnDoTuoi.UseVisualStyleBackColor = true;
            this.btnDoTuoi.Click += new System.EventHandler(this.btnDoTuoi_Click);
            // 
            // txtTenKhoa
            // 
            this.txtTenKhoa.Location = new System.Drawing.Point(72, 31);
            this.txtTenKhoa.Multiline = true;
            this.txtTenKhoa.Name = "txtTenKhoa";
            this.txtTenKhoa.Size = new System.Drawing.Size(255, 24);
            this.txtTenKhoa.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(15, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mô tả";
            // 
            // frmKhoaHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 531);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmKhoaHoc";
            this.Text = "frmKhoaHoc";
            this.Load += new System.EventHandler(this.frmKhoaHoc_Load);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongTin)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvThongTin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ImageList iconList;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCapDo;
        private System.Windows.Forms.Button btnDoTuoi;
        private System.Windows.Forms.TextBox txtTenKhoa;
        private System.Windows.Forms.Label label4;
    }
}