
USE master
CREATE DATABASE QLTrungTamNgoaiNgu
GO
USE QLTrungTamNgoaiNgu
GO
CREATE TABLE CapDo
(
	CapDoID INT NOT NULL PRIMARY KEY,
	TenCapDo CHAR(2) NOT NULL, -- Mức độ, ví dụ A1, A2, B1
);	
GO
CREATE TABLE DoTuoi --Bảng phân loại các khóa học theo nhóm tuổi
(
	DoTuoiID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	TenDoTuoi NVARCHAR(20) --“trẻ em”, “thanh niên”, “người lớn”, v.v.
);
GO
CREATE TABLE Khoa (
	KhoaID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	MoTa NVARCHAR(300) NOT NULL,
	CapDoID INT FOREIGN KEY REFERENCES CapDo(CapDoID),
	DoTuoiID INT FOREIGN KEY REFERENCES DoTuoi(DoTuoiID)
);
GO
CREATE TABLE HocSinh
(
	HocSinhID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	NgaySinh DATE,
	DiaChi NVARCHAR(150),
	Ho NVARCHAR(20),
	Ten NVARCHAR(20),
	email NVARCHAR(50),
	SoDienThoai NVARCHAR(15)
);
GO
CREATE TABLE GiaoVien
(
	GiaoVienID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	Mota NVARCHAR(300),
	Ho NVARCHAR(20),
	Ten NVARCHAR(20),
	email NVARCHAR(50),
	SoDienThoai NVARCHAR(15),
	SoNgayDay INT DEFAULT 0
);
GO
CREATE TABLE TaiKhoanNguoiDung
(
	TenDangNhap VARCHAR(20) NOT NULL PRIMARY KEY,
	MatKhau VARCHAR(20) NOT NULL,
);
GO
CREATE TABLE NguoiDung
(
	NguoiDungID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	HoTen NVARCHAR(20),
	DiaChi NVARCHAR(50),
	GioiTinh NVARCHAR(50),
	SoDienThoai NVARCHAR(15),
	TenDangNhap VARCHAR(20) FOREIGN KEY REFERENCES TaiKhoanNguoiDung(TenDangNhap)
);
GO


CREATE TABLE ThoiGian
(
	ThoiGianID INT NOT NULL PRIMARY KEY, -- lưu thời gian trong một ngày
	GioBatDau TIME,
	GioKetThuc TIME
);
GO
CREATE TABLE Lop
(
	LopID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	TenLop NVARCHAR(100),
	NgayBatDau DATE,
	NgayKetThuc DATE,
	HocPhi MONEY,
	GiaoVienID INT FOREIGN KEY REFERENCES GiaoVien(GiaoVienID),
	KhoaID INT FOREIGN KEY REFERENCES Khoa(KhoaId),	
);
GO

CREATE TABLE Thu
(
	ThuID INT NOT NULL PRIMARY KEY,
	TenThu NVARCHAR(15),
)

CREATE TABLE ThoiKhoaBieu
(
	LopID INT FOREIGN KEY REFERENCES Lop(LopID) not null,
	ThuID INT FOREIGN KEY REFERENCES Thu(ThuID) not null,
	ThoiGianID INT FOREIGN KEY REFERENCES Thoigian(ThoiGianID) not null
)
GO

-- Thêm điều kiện NOT NULL cho cột LopID
ALTER TABLE ThoiKhoaBieu
ALTER COLUMN LopID INT NOT NULL;

-- Thêm điều kiện NOT NULL cho cột ThuID
ALTER TABLE ThoiKhoaBieu
ALTER COLUMN ThuID INT NOT NULL;

-- Thêm điều kiện NOT NULL cho cột ThoiGianID
ALTER TABLE ThoiKhoaBieu
ALTER COLUMN ThoiGianID INT NOT NULL;
--Thêm cái khóa
ALTER TABLE ThoiKhoaBieu
ADD CONSTRAINT PK_TKB PRIMARY KEY (LopID, ThuID, ThoiGianID);
delete thoikhoabieu

GO
CREATE TABLE Lop_HocSinh
(
	Lop_HocSinhID  INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	LopID INT,
	HocSinhID INT,
	    Diem FLOAT,
	GhiChu NVARCHAR(100),
	FOREIGN KEY (LopID) REFERENCES Lop(LopID),
	FOREIGN KEY (HocSinhID) REFERENCES HocSinh(HocSinhID)
);
GO
--bảng điểm số lưu điểm số của học sinh trong lớp


CREATE TABLE Sach 
(
	SachID INT NOT NULL PRIMARY KEY,
	TenSach NVARCHAR(100),
	TenTacGia NVARCHAR(100),
	Gia Money
);
GO
CREATE TABLE HoaDon
(
	HoaDonID VARCHAR(15) NOT NULL PRIMARY KEY,
	NgayThanhToan DATE,
	HocSinhID INT FOREIGN KEY REFERENCES HocSinh(HocSinhID),
	DaDong bit
);
GO


CREATE TABLE ChiTietHoaDon
(
	HoaDonID VARCHAR(15) NOT NULL FOREIGN KEY REFERENCES HoaDon(HoaDonID),
	LopID INT FOREIGN KEY REFERENCES Lop(LopID),
	SachID INT FOREIGN KEY REFERENCES Sach(SachID),
	SoLuong INT DEFAULT 0,
	TongTien Money
);
GO
--Nhập liệu  ============================================================================================================
insert into Sach
values 
(1,N'Fist Fiends 1 Class Book',N'Susan Iannuzzi',200000),
(2,N'First Friend',N'Susan Iannuzzi',200000),
(3,N'First Friends 1 Teacher"s Book with Test Center CD-ROM',N'Susan Iannuzzi',200000),
(4,N'First Friend 2 Activity Book',N'Susan Iannuzzi',200000),
(5,N'First Friend 2 Class Book',N'Susan Iannuzzi',200000),
(6,N'First Friends 2 Teacher"s Book with Test Center CD-ROM',N'Susan Iannuzzi',200000),
(7,N'Fanmily and friends 1 Student Book',N'Naomi Simmons',200000),
(8,N'Fanmily and friends 1 WorkBook',N'Naomi Simmons',200000),
(9,N'Family and friends 1 Teacher"s Book with Test Center CD-ROM',N'Julie Pann',200000),
(10,N'Family and friends 2 Teacher"s Book with test Center CD-ROM',N'Naomi Simmons',200000),
(11,N'Family and friends 2 Workbook',N'Naomi Simmons',200000),
(12,N'Family and friends 2 Teacher"s Book with Test Center CD-ROM',N'Julie Penn',200000),
(13,N'Family and friends 3 Workbook',N'Tamzin Thompson and Naomi Simmons',200000),
(14,N'Family and friends 3 Workbook',N'Liz Driscoll',200000),
(15,N'Family and friends 3 Teacher"s Book with Test Center CD-ROM',N'Alex Raynham',200000),
(16,N'Family and friends 4 Student Book',N'Naomi Simmons',200000),
(17,N'Family and friends 4 Workbook',N'Naomi Simmons',200000),
(18,N'Family and friends 4 Teacher"s Book with Test Center CD-ROM',N'Barbara Mackay',200000),
(19,N'Family and friends 5 Student Book',N'Tamzin Thompson',200000),
(20,N'Family and friends 5 Workbook',N'Helen Casey',200000);
--Bảng học sinh
SET DATEFORMAT dmy
SET IDENTITY_INSERT HocSinh ON;
insert into HocSinh(HocSinhID, Ten, Ho, SoDienThoai, DiaChi, email, NgaySinh) values
(1, N'Kim', N'Nguyễn Việt Ánh', '094405688', N'Ấp 1, Tân Hòa, Bến Lức, Long An', 'AnhNV@gmail.com', '09/02/2006'),
(2, N'Quý', N'Nguyễn Văn', '0869068814', N'Ấp 2, An Thạnh, Bến Lức, Long An', 'QuyNV@gmail.com', '03/11/2005'),
(3, N'Thy', N'Nguyễn Thị Hoàng', '0368492873', N'Ấp 3, Tân Bửu, Bến Lức, Long An', 'ThyNTH@gmail.com', '25/09/2007'),
(4, N'Khanh', N'Nguyễn Thị Kiều', '0944088046', N'Ấp 4, Tân Hòa, Bến Lức, Long An', 'KhanhNTK@gmail.com', '17/04/2012'),
(5, N'Trang', N'Nguyễn Thị Huyền', '0904828034', N'Ấp 5, An Thạnh, Bến Lức, Long An', 'TrangNTH@gmail.com', '07/07/2009'),
(6, N'Tâm', N'Văn Thị Mỹ', '0908690188', N'Ấp 1, Tân Bửu, Bến Lức, Long An', 'TamVTM@gmail.com', '13/11/2011'),
(7, N'Duyên', N'Dương Ngô Mỹ', '0918280682', N'Ấp 2, Tân Hòa, Bến Lức, Long An', 'DuyenDNM@gmail.com', '08/09/2008'),
(8, N'Phương', N'Phạm Ngọc Lan', '0975209204', N'Ấp 3, An Thạnh, Bến Lức, Long An', 'PhuongPNL@gmail.com', '20/03/2010'),
(9, N'My', N'Nguyễn Thị Trà', '0365142248', N'Ấp 4, Tân Bửu, Bến Lức, Long An', 'MyNTT@gmail.com', '01/10/2013'),
(10, N'Trân', N'Nguyễn Ngọc Bảo', '0869932443', N'Ấp 5, Tân Hòa, Bến Lức, Long An', 'TranNNB@gmail.com', '20/07/2005'),
(11, N'Ngân', N'Nguyễn Thị Kim', '0344781929', N'Ấp 1, An Thạnh, Bến Lức, Long An', 'NganNTK@gmail.com', '14/05/2014'),
(12, N'Khang', N'Võ Minh', '0372883050', N'Ấp 2, Tân Bửu, Bến Lức, Long An', 'KhangVM@gmail.com', '22/01/2008'),
(13, N'Thịnh', N'Lưu Gia', '0977716668', N'Ấp 3, Tân Hòa, Bến Lức, Long An', 'ThinhLG@gmail.com', '12/03/2015'),
(14, N'Quỳnh', N'Lê Thị Thúy', '0977716668', N'Ấp 4, An Thạnh, Bến Lức, Long An', 'QuynhLTT@gmail.com', '30/11/2008'),
(15, N'Khải', N'Lê Thành', '0904828045', N'Ấp 5, Tân Bửu, Bến Lức, Long An', 'KhaiLT@gmail.com', '19/10/2011'),
(16, N'Phúc', N'Tạ Hồng', '0932422782', N'Ấp 1, Tân Hòa, Bến Lức, Long An', 'PhucTH@gmail.com', '27/06/2007'),
(17, N'Phương', N'Phạm Ngọc Mai', '0975209204', N'Ấp 2, An Thạnh, Bến Lức, Long An', 'PhuongPNM@gmail.com', '05/12/2010'),
(18, N'Hoa', N'Nguyễn Phương Kiều', '0907169915', N'Ấp 3, Tân Bửu, Bến Lức, Long An', 'HoaNPK@gmail.com', '17/09/2006'),
(19, N'Hưng', N'Phan Khánh', '0962072921', N'Ấp 4, Tân Hòa, Bến Lức, Long An', 'HungPK@gmail.com', '08/07/2013'),
(20, N'Phúc', N'Lê Trọng', '0364425446', N'Ấp 5, An Thạnh, Bến Lức, Long An', 'PhucLT@gmail.com', '14/12/2009'),
(21, N'Lê', N'Nguyễn Thị Hồng', '0908382947', N'Ấp 1, Tân Bửu, Bến Lức, Long An', 'LeNTH@gmail.com', '18/09/2005'),
(22, N'My', N'Trần Ngọc Khánh', '0377674906', N'Ấp 2, Tân Hòa, Bến Lức, Long An', 'MyTNK@gmail.com', '25/08/2012'),
(23, N'An', N'Nguyễn Văn Hoài', '0944958721', N'Ấp 3, An Thạnh, Bến Lức, Long An', 'AnNVH@gmail.com', '09/09/2006'),
(24, N'Phi', N'Lê Hoàng', '0989955644', N'Ấp 4, Tân Bửu, Bến Lức, Long An', 'PhiLH@gmail.com', '04/06/2011'),
(25, N'Huyền', N'Nguyễn Thị Ngọc', '0989955644', N'Ấp 5, Tân Hòa, Bến Lức, Long An', 'HuyenNTN@gmail.com', '15/11/2008'),
(26, N'Quỳnh', N'Nguyễn Thị Như', '0389130036', N'Ấp 1, Tân Bửu, Bến Lức, Long An', 'QuynhNTN@gmail.com', '28/02/2014'),
(27, N'Tiên', N'Nguyễn Hoàng Thủy', '0399605759', N'Ấp 2, Tân Hòa, Bến Lức, Long An', 'TienNHT@gmail.com', '10/05/2007'),
(28, N'Tuyền', N'Nguyễn Thị Thanh', '0332593752', N'Ấp 3, An Thạnh, Bến Lức, Long An', 'TuyenNTT@gmail.com', '16/12/2010'),
(29, N'Vy', N'Lê Thị Yến', '0862852957', N'Ấp 4, Tân Bửu, Bến Lức, Long An', 'VyLTY@gmail.com', '18/02/2013'),
(30, N'Diệu', N'Nguyễn Thị Thu', '0357010358', N'Ấp 5, Tân Hòa, Bến Lức, Long An', 'DieuNTT@gmail.com', '30/07/2006'),
(31, N'Nhi', N'Lê Thị Yến', '0865955360', N'Ấp 1, Tân Bửu, Bến Lức, Long An', 'NhiLTY@gmail.com', '11/11/2012'),
(32, N'Nhân', N'Tấn Huỳnh Trọng', '0367231948', N'Ấp 2, Tân Hòa, Bến Lức, Long An', 'NhanNHT@gmail.com', '07/04/2009'),
(33, N'Băng', N'Phạm Huỳnh Hải', '0909468558', N'Ấp 3, An Thạnh, Bến Lức, Long An', 'BangPHH@gmail.com', '26/03/2011'),
(34, N'Mai', N'Nguyễn Thị Xuân', '0358402391', N'Ấp 4, Tân Bửu, Bến Lức, Long An', 'MaiNTX@gmail.com', '19/08/2010'),
(35, N'Thùy', N'Phan Ngọc Mộng', '0376381077', N'Ấp 5, Tân Hòa, Bến Lức, Long An', 'ThuyPNM@gmail.com', '14/06/2005');
SET IDENTITY_INSERT HocSinh OFF;
SELECT * FROM HocSinh
GO

--Giáo viên
SET IDENTITY_INSERT GiaoVien ON;
INSERT INTO GiaoVien (GiaoVienID, Mota, Ho, Ten, email, SoDienThoai) VALUES
    (1, N'Giáo viên Tiếng Anh trẻ em', N'Nguyễn', N'Văn', 'nguyenvan@gmail.com', '0987654321'),
    (2, N'Giáo viên Tiếng Anh Ielts 10.', N'Trần', N'Thị Thu', 'tranthuthu@gmail.com', '0912345678'),
    (3, N'Giáo viên Tiếng Anh có thể dạy Toán', N'Lê', N'Đình', 'ledinh@gmail.com', '0976543210'),
    (4, N'Giáo viên Tiếng Anh Toeic 900', N'Phạm', N'Minh', 'phamminh@gmail.com', '0909090909'),
    (5, N'Giáo viên dạy Tiếng Anh người mất gốc', N'Đặng', N'Hồng', 'danghong@gmail.com', '0969696969');

SET IDENTITY_INSERT GiaoVien OFF;
SELECT * FROM GiaoVien
GO

SET DATEFORMAT dmy;

GO
SELECT * FROM HoaDon

SELECT HocSinh.Ho + ' ' + HocSinh.Ten AS N'Họ và tên', HoaDon.DaDong, NgayThanhToan FROM HocSinh INNER JOIN HoaDon ON HocSinh.HocSinhID = HoaDon.HocSinhID ORDER BY HocSinh.Ten
GO




--INSERT INTO GiaoVien
--VALUES ('','',)
GO

SET DATEFORMAT dmy;

INSERT INTO TaiKhoanNguoiDung(TenDangNhap, MatKhau)
VALUES 
	('NhanLH', '19734682@Nhan123'),
	('KhangHM', 'Khang@123'),
	('TuongNC', 'Tuong@123'),
	('VyNTT', 'Vy@123')

GO

INSERT INTO NguoiDung(HoTen, DiaChi,GioiTinh,SoDienThoai, TenDangNhap)
VALUES
	(N'Lê Hồng Nhân', N'Long An', N'Nam', '0372880194', 'NhanLH'),
	(N'Huỳnh Minh Khang', N'Bình Định', N'Nam', '01234556543', 'KhangHM'),
	(N'Nguyễn Cát Tường', N'Bến Tre', N'Nam', '0987654321', 'TuongNC'),
	(N'Nguyễn Trần Thế Vy', N'Long An', N'Nữ', '0192837465', 'VyNTT')
GO
Select * From NguoiDung

insert into CapDo values
(1, 'A1'),
(2, 'A2'),
(3, 'B1'),
(4, 'B2'),
(5, 'C1'),
(6, 'C2')
GO
insert into DoTuoi (TenDoTuoi) values
(N'Mầm non'),
(N'Cấp 1'),
(N'Cấp 2'),
(N'Cấp 3'),
(N'Đại học'),
(N'Đi làm')
GO
SELECT * FROM KHOA
insert into Khoa(MoTa, CapDoID, DoTuoiID) values
(N'Khóa lấy gốc thi Toeic', 5, 3),
(N'Khóa học trẻ em', 2, 1),
(N'Khóa Cấp 2', 3, 2)
GO

GO
set dateformat dmy
insert into Lop(TenLop, NgayBatDau, NgayKetThuc, HocPhi, GiaoVienID, KhoaID) Values
(N'Lớp toeic 1', '12/12/2012', '12/12/2023', 200000, 1, 1),
(N'Lớp mầm non', '12/12/2012', '12/12/2023', 200000, 2,2),
(N'Lớp cấp 2', '12/12/2012', '12/12/2023', 200000, 3, 3)


select * from Khoa
select * from hocsinh
select * from Lop
select * from Lop_HocSinh
insert into Lop_HocSinh (LopID, HocSinhID, Diem, GhiChu) values 
(1, 1, 8, N'Học tốt'),
(1, 2, 4, N'Học chăm nhưng chưa giổi'),
(1, 3, 6, N'Học hơi giỏi'),
(1, 4, 2, N'Hay nghỉ học'),
(1, 5, 9, N'Học nhanh tiến bộ')

SELECT * FROM HocSinh inner join Lop_HocSinh ON Lop_HocSinh.HocSinhID = HocSinh.HocSinhID where HocSinh.HocSinhID = 1

UPDATE Lop_HocSinh SET Diem = 4 , GhiChu = N'Học chăm nhưng chưa giỏi' WHERE HocSinhID = 2
UPDATE Lop_HocSinh SET Diem = {diem}, GhiChu = N'{ghiChu}' WHERE HocSinhID = {hocSinhID}

insert into Lop_HocSinh(Lop_HocSinhID, HocSinhID, Diem, GhiChu) values ('', '', null, null)
select * from dotuoi

select * from khoa
select KhoaID as N'Mã khoa', MoTa as N'Mô tả khoa', TenCapDo as N'Cấp độ', TenDoTuoi as 'Độ tuổi' from khoa inner join CapDo ON khoa.CapDoID = CapDo.CapDoID inner join DoTuoi ON Khoa.DoTuoiID = DoTuoi.DoTuoiID;
insert into Khoa(MoTa, CapDoID, DoTuoiID) values('','','')
delete from khoa where KhoaID > 3
go
update Khoa set MoTa = N'{txtTenKhoa.Text}', CapDoID = {maCapDo} , DoTuoiID = {maDoTuoi} where khoaID = {}

select * from giaovien

select * from hoadon
delete from hoadon 

select * from chiTietHoaDon
Select ChiTietHoaDon.HoaDonID, ChiTietHoaDon.SachID, SoLuong, Gia*SOLUONG as TT from ChiTietHoaDon inner join Sach ON ChiTietHoaDon.SachID = Sach.SachID

select * from Lop
select * from Lop_HocSinh

delete from chitiethoadon
select ChiTietHoaDon.HoaDonID, TenLop, TenSach, SoLuong, TongTien, Ho + ' ' + Ten as 'TenHocSinh'  from ChiTietHoaDon inner join Lop on ChiTietHoaDon.LopID = Lop.LopID inner join Sach on ChiTietHoaDon.SachID = Sach.SachID inner join HoaDon ON ChiTietHoaDon.HoaDonID = HoaDon.HoaDonID inner join HocSinh on HoaDon.HoaDonID = HocSinh.HocSinhID;

SELECT ChiTietHoaDon.HoaDonID, TenLop, TenSach, SoLuong, TongTien, Ho + ' ' + Ten AS TenHocSinh FROM ChiTietHoaDon INNER JOIN Lop ON ChiTietHoaDon.LopID = Lop.LopID INNER JOIN Sach ON ChiTietHoaDon.SachID = Sach.SachID INNER JOIN HoaDon ON ChiTietHoaDon.HoaDonID = HoaDon.HoaDonID INNER JOIN HocSinh ON HoaDon.HocSinhID = HocSinh.HocSinhID; 
SELECT ChiTietHoaDon.HoaDonID, TenLop, TenSach, SoLuong, TongTien, Ho + ' ' + Ten AS TenHocSinh FROM ChiTietHoaDon INNER JOIN Lop ON ChiTietHoaDon.LopID = Lop.LopID INNER JOIN Sach ON ChiTietHoaDon.SachID = Sach.SachID INNER JOIN HoaDon ON ChiTietHoaDon.HoaDonID = HoaDon.HoaDonID INNER JOIN HocSinh ON HoaDon.HocSinhID = HocSinh.HocSinhID Where ChiTietHoaDon.HoaDonID =HD06122023001

select TenLop, Ho + ' ' + Ten as N'Họ và tên',  Diem, GhiChu from Lop_HocSinh inner join Lop On Lop_HocSinh.LopID = Lop.LopID inner join HocSinh On Lop_HocSinh.HocSinhID = HocSinh.HocSinhID
select TenLop, Ho, Ten,  Diem, GhiChu from Lop_HocSinh inner join Lop On Lop_HocSinh.LopID = Lop.LopID inner join HocSinh On Lop_HocSinh.HocSinhID = HocSinh.HocSinhID where Lop_HocSinh.LopID = 
select * from thoigian


insert into thoigian values
(1,'07:00', '09:15'),
(2,'10:00', '12:15'),
(3,'13:00', '15:15'),
(4,'16:00', '18:15'),
(5,'19:00', '21:15')

select ThoiGianID, GioBatDau + ' -> ' + GioKetThuc as 'Gio' from ThoiGian

SELECT ThoiGianID, CONVERT(varchar(8), GioBatDau, 108) + ' -> ' + CONVERT(varchar(8), GioKetThuc, 108) AS 'Gio'
FROM ThoiGian;

select * from ThoiKhoaBieu


insert into ThoiKhoaBieu values (,,)
select * from Thu
insert into thu values
(1, N'Thứ 2'),
(2, N'Thứ 3'),
(3, N'Thứ 4'),
(4, N'Thứ 5'),
(5, N'Thứ 6'),
(6, N'Thứ 7'),
(7, N'Chủ nhật')

alter table hoadon
drop column dadong
select TenLop , TenThu , CONVERT(varchar(8), GioBatDau, 108) + ' -> ' + CONVERT(varchar(8), GioKetThuc, 108) AS N'GioHoc'  from ThoiKhoaBieu inner join Lop on ThoiKhoaBieu.LopID = Lop.LopID inner join Thu on ThoiKhoaBieu.ThuID = Thu.ThuID inner join ThoiGian On ThoiKhoaBieu.ThoiGianID = ThoiGian.ThoiGianID

select TenLop , TenThu , CONVERT(varchar(8), GioBatDau, 108) + ' -> ' + CONVERT(varchar(8), GioKetThuc, 108) AS N'GioHoc'  from ThoiKhoaBieu inner join Lop on ThoiKhoaBieu.LopID = Lop.LopID inner join Thu on ThoiKhoaBieu.ThuID = Thu.ThuID inner join ThoiGian On ThoiKhoaBieu.ThoiGianID = ThoiGian.ThoiGianID
select ChiTietHoaDon.HoaDonID as N'Mã hóa đơn', NgayThanhToan as N'Ngày thanh toán' , ho + ' ' + Ten as N'Họ tên', TenLop as N'Tên lớp', TenSach as N'Tên sách', SoLuong as N'Số lượng', TongTien as N'Tổng tiền' from HoaDon inner join ChiTietHoaDon on HoaDon.HoaDonID = ChiTietHoaDon.HoaDonID inner join HocSinh on HoaDon.HocSinhID = HocSinh.HocSinhID inner join Lop On ChiTietHoaDon.LopID = Lop.LopID inner join Sach on ChiTietHoaDon.SachID = Sach.SachID 
delete from ChiTietHoaDon
select * from chiTietHoaDon

Select ChiTietHoaDon.HoaDonID as N'Mã hóa đơn', TenLop as N'Tên lớp', TenSach as N'Tên sách', SoLuong as N'Số lượng', TongTien as 'Tổng tiền' from ChiTietHoaDon inner join Sach ON ChiTietHoaDon.SachID = Sach.SachID inner join Lop on ChiTietHoaDon.LopID = lop.LopID

select * from TaiKhoanNguoiDung
insert into TaiKhoanNguoiDung values ('Admin','123')

SELECT * FROM Sach

UPDATE NGUOIDUNG SET HoTen = N'Lê Hồng Nhân' where TenDangNhap = 'NhanLH'

select TenLop , TenThu , CONVERT(varchar(8), GioBatDau, 108) + ' -> ' + CONVERT(varchar(8), GioKetThuc, 108) AS N'GioHoc'  from ThoiKhoaBieu inner join Lop on ThoiKhoaBieu.LopID = Lop.LopID inner join Thu on ThoiKhoaBieu.ThuID = Thu.ThuID inner join ThoiGian On ThoiKhoaBieu.ThoiGianID = ThoiGian.ThoiGianID

select * from Lop_HocSinh

delete from Lop_HocSinh Where Diem is NULL

UPDAte NguoiDung set HoTen = N'Lê Hồng Nhân' where TenDangNhap = 'NhanLH'

select * from DoTuoi where DoTuoiID > 6

delete from DoTuoi where DoTuoiID > 6

select * from Lop
