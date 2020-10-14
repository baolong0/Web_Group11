Create Database FootballNews_5
Go

Use FootballNews_5
Go

Create Table TINTUC
(
	ID_TinTuc char(15) not null primary key,
	TieuDe nvarchar(max) default N'No title',
	Avatar varchar(2000) default 'No picture',
	TomTat nvarchar(max),
	LuotTuongTac int,
	LuotXem int,
	TrangThaiHienThi nvarchar(20) default N'Hiển thị'
)
go

Create Table HINHANH
(
	ID_HinhAnh int identity(1,1) not null primary key,
	Source_HinhAnh varchar(2000),
)
Go

Create Table NOIDUNG
(
	ID_NoiDung int identity(1,1) not null primary key,
	Text_NoiDung nvarchar(max)
)
Go

Create Table HASHTAG
(
	ID_Hashtag int identity(1,1) not null primary key,
	Hashtag nvarchar(100)
)
Go

Create Table sub_TINTUC
(
	ID_sub_TT int identity(1,1) primary key,
	ID_Tintuc char(15) foreign key references TINTUC(ID_TinTuc),
	ID_HinhAnh int foreign key references HINHANH(ID_HinhAnh),
	ID_NoiDung int foreign key references NOIDUNG(ID_NoiDung) ,
	ID_Hashtag int foreign key references HASHTAG(ID_Hashtag)
)
Go

Create Table DOIBONG
(
	ID_DoiBong char(15) not null primary key,
	TenDoi nvarchar(100) not null,
	Source_Logo varchar(2000),
	Source_Banner varchar(2000)
)
Go

Create Table THONGTINCOBAN
(
	ID_ThongTin char(15) not null primary key,
	DiaChi nvarchar(1000),
	Hotline char(15),
	Email varchar(50),
	Website varchar(500),
	SanVanDong nvarchar(20),
	SucChua int,
	ChuTichCLB nvarchar(50),
	GĐDH nvarchar(50),
	HLVTruong nvarchar(50),
	GĐKT nvarchar(50),
	NhaTaiTro nvarchar(50),
	ID_DoiBong char(15) not null foreign key references DOIBONG(ID_DoiBong)
)
Go

Create Table LOAITHANHTICH
(
	ID_LoaiThanhTich char(15) not null primary key,
	TenLoaiThanhTich nvarchar(50)	-- Thành tích của đội bóng, Thành tích của cầu thủ
)
Go

Create Table THANHTICH
(
	ID_ThanhTich char(15) not null primary key,
	TenThanhTich nvarchar(100),
	ID_LoaiThanhTich char(15) not null foreign key references LOAITHANHTICH(ID_LoaiThanhTich),
	ID_DoiBong char(15) not null foreign key references DOIBONG(ID_DoiBong)
)
Go

Create Table TAITRO
(
	ID_TaiTro char(15) not null primary key,
	Source_Logo varchar(2000),
)
Go

Create Table sub_TAITRO 
(
	ID_Sub_TT int identity(1,1)primary key ,
	ID_DoiBong char(15) not null foreign key references DOIBONG(ID_DoiBong),
	ID_TaiTro char(15) not null foreign key references TAITRO(ID_TaiTro)
	
)
Go

Create Table CAUTHU
(
	ID_CauThu char(15) not null primary key,
	TenCauThu nvarchar(50),
	Source_HACT varchar(2000),
	ID_DoiBong char(15) not null foreign key references DOIBONG(ID_DoiBong),
)
Go


Create Table TRANDAU
(
	ID_TranDau char(15) not null primary key,
	DoiNha char(15) not null foreign key references DOIBONG(ID_DoiBong),
	DoiKhach char(15) not null foreign key references DOIBONG(ID_DoiBong),
	ThoiGianThiDau datetime,
	SanThiDau nvarchar(20),
	TiSo varchar(15)
)
Go

Create Table BANTHANG
(
	ID_BanThang char(15) not null primary key,
	ID_CauThu char(15) not null foreign key references CAUTHU(ID_CauThu),
	ID_TranDau char(15) not null foreign key references TRANDAU(ID_TranDau),
	ThoiDiem datetime
)
Go

Create Table tb_USER
(
	ID_User char(15) not null primary key,
	HoTen nvarchar(50),
	TaiKhoan varchar(50),
	MatKhau varchar(50),
	Email varchar(50),
	SDT char(15)
)
Go

Create Table KHACHHANG
(
	ID_KhachHang char(15) not null primary key,
	HoTen nvarchar(50),
	DiaChi nvarchar(100),
	SDT char(15)
)
Go

Create Table HOADON
(
	ID_HoaDon char(15) not null primary key,
	ID_KhachHang char(15) not null foreign key references KHACHHANG(ID_KhachHang),
	ThoiGian datetime
)
go

Create Table LOAIVE
(
	ID_LoaiVe char(15) not null primary key,
	TenLoaiVe nvarchar(50),	-- Vé khán đài A, vé khán đài B, vé khán đài C, vé khán đài D
	SoLuong int,	-- Tổng số lượng của loại vé đó là bao nhiêu
	GiaVe int
)
Go

Create Table TICKET
(
	ID_Ve char(15) not null primary key,
	ID_LoaiVe char(15) not null foreign key references LOAIVE(ID_LoaiVe),
	DoiNha char(15) not null foreign key references DOIBONG(ID_DoiBong),
	DoiKhach char(15) not null foreign key references DOIBONG(ID_DoiBong),
	ThoiGianBatDau datetime,
)
Go

Create Table CTHD
(
	ID_HoaDon char(15) not null foreign key references HOADON(ID_HoaDon),
	ID_Ve char(15) not null foreign key references TICKET(ID_Ve),
	SoLuong int		-- Số lượng vé đã bán
	Constraint CTHD_pk primary key(ID_HoaDon, ID_Ve)
)
Go

create table HINHANH_QC(
ID_HA_QC int identity(1,1),
Source_HinhAnh_QC varchar(2000)
)
go

create table VIDEO(
ID_VIDEO int identity(1,1) primary key,
Source_VIDEO varchar(2000)
)
go


create table TIN_VIDEO(
ID_TIN_VIDEO char(15) primary key,
TieuDe_VIDEO nvarchar(max) default N'No title',
Avatar_VIDEO varchar(2000) default 'No picture',
TomTat_VIDEO nvarchar(max),
LuotTuongTac_VIDEO int,
LuotXem_VIDEO int,
TrangThaiHienThi_VIDEO nvarchar(20) default N'Hiển thị'
)
go

create table sub_TIN_VIDEO(
ID_sub_TIN_VIDEO int identity(1,1) primary key,
ID_TIN_VIDEO char(15) foreign key references TIN_VIDEO(ID_TIN_VIDEO),
ID_VIDEO int foreign key references VIDEO(ID_VIDEO)
)
go

create table Thong_Tin_Xep_Hang(
ID_Thu_Tu int identity(1,1) primary key,
ID_DoiBong char(15) foreign key references DOIBONG(ID_DoiBong),
SoTran int,
Thang int,
Hoa int,
Thua int,
HieuSo char(10),
Diem int,
)