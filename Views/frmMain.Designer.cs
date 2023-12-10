namespace Views
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.IconList = new System.Windows.Forms.ImageList(this.components);
            this.tsLichHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTaoHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.kếtQuảHọcTậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsGiangVien = new System.Windows.Forms.ToolStripMenuItem();
            this.tsHocVien = new System.Windows.Forms.ToolStripMenuItem();
            this.tsQuanLy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDanhSachLop = new System.Windows.Forms.ToolStripMenuItem();
            this.tsHocVienTrongLop = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLop = new System.Windows.Forms.ToolStripMenuItem();
            this.tsThuVienSach = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.tsQLNguoiDung = new System.Windows.Forms.ToolStripMenuItem();
            this.tsThongTinTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.tsHethong = new System.Windows.Forms.ToolStripMenuItem();
            this.đổiMậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnsTrangChu = new System.Windows.Forms.MenuStrip();
            this.liênHệToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khóaHọcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsTrangChu.SuspendLayout();
            this.SuspendLayout();
            // 
            // IconList
            // 
            this.IconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IconList.ImageStream")));
            this.IconList.TransparentColor = System.Drawing.Color.Transparent;
            this.IconList.Images.SetKeyName(0, "DanhMuc.png");
            this.IconList.Images.SetKeyName(1, "HeThong.png");
            this.IconList.Images.SetKeyName(2, "HocVien.png");
            this.IconList.Images.SetKeyName(3, "LienHe.png");
            this.IconList.Images.SetKeyName(4, "Lop.png");
            this.IconList.Images.SetKeyName(5, "LopHocVien.png");
            this.IconList.Images.SetKeyName(6, "NhanVien.png");
            this.IconList.Images.SetKeyName(7, "QuanLy.png");
            this.IconList.Images.SetKeyName(8, "teacher.png");
            this.IconList.Images.SetKeyName(9, "ThuVien.png");
            this.IconList.Images.SetKeyName(10, "TimKiem.png");
            // 
            // tsLichHoc
            // 
            this.tsLichHoc.Name = "tsLichHoc";
            this.tsLichHoc.Size = new System.Drawing.Size(197, 26);
            this.tsLichHoc.Text = "Xem lịch học";
            this.tsLichHoc.Click += new System.EventHandler(this.tsLichHoc_Click);
            // 
            // tsThongKe
            // 
            this.tsThongKe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsTaoHoaDon,
            this.tsLichHoc,
            this.kếtQuảHọcTậpToolStripMenuItem});
            this.tsThongKe.Name = "tsThongKe";
            this.tsThongKe.Size = new System.Drawing.Size(86, 24);
            this.tsThongKe.Text = "Thống Kê";
            // 
            // tsTaoHoaDon
            // 
            this.tsTaoHoaDon.Name = "tsTaoHoaDon";
            this.tsTaoHoaDon.Size = new System.Drawing.Size(197, 26);
            this.tsTaoHoaDon.Text = "Tạo hoá đơn";
            this.tsTaoHoaDon.Click += new System.EventHandler(this.taojToolStripMenuItem_Click);
            // 
            // kếtQuảHọcTậpToolStripMenuItem
            // 
            this.kếtQuảHọcTậpToolStripMenuItem.Name = "kếtQuảHọcTậpToolStripMenuItem";
            this.kếtQuảHọcTậpToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.kếtQuảHọcTậpToolStripMenuItem.Text = "Kết quả học tập";
            this.kếtQuảHọcTậpToolStripMenuItem.Click += new System.EventHandler(this.kếtQuảHọcTậpToolStripMenuItem_Click);
            // 
            // tsGiangVien
            // 
            this.tsGiangVien.Image = ((System.Drawing.Image)(resources.GetObject("tsGiangVien.Image")));
            this.tsGiangVien.Name = "tsGiangVien";
            this.tsGiangVien.Size = new System.Drawing.Size(224, 26);
            this.tsGiangVien.Text = "Giáo viên";
            this.tsGiangVien.Click += new System.EventHandler(this.tsGiangVien_Click);
            // 
            // tsHocVien
            // 
            this.tsHocVien.Image = ((System.Drawing.Image)(resources.GetObject("tsHocVien.Image")));
            this.tsHocVien.Name = "tsHocVien";
            this.tsHocVien.Size = new System.Drawing.Size(224, 26);
            this.tsHocVien.Text = "Học Viên";
            this.tsHocVien.Click += new System.EventHandler(this.tsHocVien_Click);
            // 
            // tsQuanLy
            // 
            this.tsQuanLy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsHocVien,
            this.tsGiangVien,
            this.khóaHọcToolStripMenuItem});
            this.tsQuanLy.Image = ((System.Drawing.Image)(resources.GetObject("tsQuanLy.Image")));
            this.tsQuanLy.Name = "tsQuanLy";
            this.tsQuanLy.Size = new System.Drawing.Size(224, 26);
            this.tsQuanLy.Text = "Quản Lý";
            // 
            // tsDanhSachLop
            // 
            this.tsDanhSachLop.Name = "tsDanhSachLop";
            this.tsDanhSachLop.Size = new System.Drawing.Size(337, 26);
            this.tsDanhSachLop.Text = "Quản lý danh sách lớp";
            this.tsDanhSachLop.Click += new System.EventHandler(this.tsDanhSachLop_Click);
            // 
            // tsHocVienTrongLop
            // 
            this.tsHocVienTrongLop.Image = ((System.Drawing.Image)(resources.GetObject("tsHocVienTrongLop.Image")));
            this.tsHocVienTrongLop.Name = "tsHocVienTrongLop";
            this.tsHocVienTrongLop.Size = new System.Drawing.Size(337, 26);
            this.tsHocVienTrongLop.Text = "Quản lý danh sách học viên trong lớp";
            this.tsHocVienTrongLop.Click += new System.EventHandler(this.tsHocVienTrongLop_Click);
            // 
            // tsLop
            // 
            this.tsLop.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsHocVienTrongLop,
            this.tsDanhSachLop});
            this.tsLop.Image = ((System.Drawing.Image)(resources.GetObject("tsLop.Image")));
            this.tsLop.Name = "tsLop";
            this.tsLop.Size = new System.Drawing.Size(224, 26);
            this.tsLop.Text = "Lớp";
            this.tsLop.Click += new System.EventHandler(this.tsLop_Click);
            // 
            // tsThuVienSach
            // 
            this.tsThuVienSach.Image = ((System.Drawing.Image)(resources.GetObject("tsThuVienSach.Image")));
            this.tsThuVienSach.Name = "tsThuVienSach";
            this.tsThuVienSach.Size = new System.Drawing.Size(224, 26);
            this.tsThuVienSach.Text = "Thư Viện Sách";
            this.tsThuVienSach.Click += new System.EventHandler(this.tsThuVienSach_Click);
            // 
            // tsDanhMuc
            // 
            this.tsDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsThuVienSach,
            this.tsLop,
            this.tsQuanLy});
            this.tsDanhMuc.Image = ((System.Drawing.Image)(resources.GetObject("tsDanhMuc.Image")));
            this.tsDanhMuc.Name = "tsDanhMuc";
            this.tsDanhMuc.Size = new System.Drawing.Size(110, 26);
            this.tsDanhMuc.Text = "Danh Mục";
            // 
            // tsThoat
            // 
            this.tsThoat.Image = ((System.Drawing.Image)(resources.GetObject("tsThoat.Image")));
            this.tsThoat.Name = "tsThoat";
            this.tsThoat.Size = new System.Drawing.Size(224, 26);
            this.tsThoat.Text = "Thoát";
            // 
            // tsQLNguoiDung
            // 
            this.tsQLNguoiDung.Image = ((System.Drawing.Image)(resources.GetObject("tsQLNguoiDung.Image")));
            this.tsQLNguoiDung.Name = "tsQLNguoiDung";
            this.tsQLNguoiDung.Size = new System.Drawing.Size(224, 26);
            this.tsQLNguoiDung.Text = "Quản lý người dùng";
            this.tsQLNguoiDung.Click += new System.EventHandler(this.tsQLNguoiDung_Click);
            // 
            // tsThongTinTaiKhoan
            // 
            this.tsThongTinTaiKhoan.Image = ((System.Drawing.Image)(resources.GetObject("tsThongTinTaiKhoan.Image")));
            this.tsThongTinTaiKhoan.Name = "tsThongTinTaiKhoan";
            this.tsThongTinTaiKhoan.Size = new System.Drawing.Size(224, 26);
            this.tsThongTinTaiKhoan.Text = "Thông tin tài khoản";
            this.tsThongTinTaiKhoan.Click += new System.EventHandler(this.tsThongTinTaiKhoan_Click);
            // 
            // tsDangXuat
            // 
            this.tsDangXuat.Image = ((System.Drawing.Image)(resources.GetObject("tsDangXuat.Image")));
            this.tsDangXuat.Name = "tsDangXuat";
            this.tsDangXuat.Size = new System.Drawing.Size(224, 26);
            this.tsDangXuat.Text = "Đăng Xuất";
            this.tsDangXuat.Click += new System.EventHandler(this.tsDangXuat_Click);
            // 
            // tsHethong
            // 
            this.tsHethong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsThongTinTaiKhoan,
            this.tsQLNguoiDung,
            this.đổiMậtKhẩuToolStripMenuItem,
            this.toolStripSeparator1,
            this.tsDangXuat,
            this.tsThoat});
            this.tsHethong.Image = ((System.Drawing.Image)(resources.GetObject("tsHethong.Image")));
            this.tsHethong.Name = "tsHethong";
            this.tsHethong.Size = new System.Drawing.Size(108, 24);
            this.tsHethong.Text = "Hệ Thống";
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            this.đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            this.đổiMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.đổiMậtKhẩuToolStripMenuItem.Text = "Đổi mật khẩu";
            this.đổiMậtKhẩuToolStripMenuItem.Click += new System.EventHandler(this.tsDoiMK);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // mnsTrangChu
            // 
            this.mnsTrangChu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsTrangChu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsHethong,
            this.tsDanhMuc,
            this.tsThongKe,
            this.liênHệToolStripMenuItem});
            this.mnsTrangChu.Location = new System.Drawing.Point(0, 0);
            this.mnsTrangChu.Name = "mnsTrangChu";
            this.mnsTrangChu.Size = new System.Drawing.Size(964, 30);
            this.mnsTrangChu.TabIndex = 1;
            this.mnsTrangChu.Text = "menuStrip1";
            // 
            // liênHệToolStripMenuItem
            // 
            this.liênHệToolStripMenuItem.Name = "liênHệToolStripMenuItem";
            this.liênHệToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.liênHệToolStripMenuItem.Text = "Liên hệ";
            this.liênHệToolStripMenuItem.Click += new System.EventHandler(this.liênHệToolStripMenuItem_Click);
            // 
            // khóaHọcToolStripMenuItem
            // 
            this.khóaHọcToolStripMenuItem.Name = "khóaHọcToolStripMenuItem";
            this.khóaHọcToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.khóaHọcToolStripMenuItem.Text = "Khóa học";
            this.khóaHọcToolStripMenuItem.Click += new System.EventHandler(this.khóaHọcToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 535);
            this.Controls.Add(this.mnsTrangChu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Text = "QUẢN LÝ HỌC VIÊN TRUNG TÂM NGOẠI NGỮ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mnsTrangChu.ResumeLayout(false);
            this.mnsTrangChu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList IconList;
        private System.Windows.Forms.ToolStripMenuItem tsLichHoc;
        private System.Windows.Forms.ToolStripMenuItem tsThongKe;
        private System.Windows.Forms.ToolStripMenuItem tsGiangVien;
        private System.Windows.Forms.ToolStripMenuItem tsHocVien;
        private System.Windows.Forms.ToolStripMenuItem tsQuanLy;
        private System.Windows.Forms.ToolStripMenuItem tsDanhSachLop;
        private System.Windows.Forms.ToolStripMenuItem tsHocVienTrongLop;
        private System.Windows.Forms.ToolStripMenuItem tsLop;
        private System.Windows.Forms.ToolStripMenuItem tsThuVienSach;
        private System.Windows.Forms.ToolStripMenuItem tsDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem tsThoat;
        private System.Windows.Forms.ToolStripMenuItem tsQLNguoiDung;
        private System.Windows.Forms.ToolStripMenuItem tsThongTinTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem tsDangXuat;
        private System.Windows.Forms.ToolStripMenuItem tsHethong;
        private System.Windows.Forms.MenuStrip mnsTrangChu;
        private System.Windows.Forms.ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem kếtQuảHọcTậpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsTaoHoaDon;
        private System.Windows.Forms.ToolStripMenuItem liênHệToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khóaHọcToolStripMenuItem;
    }
}

