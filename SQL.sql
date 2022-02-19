USE [DoAn_Trung_Tuan_Bixie]
GO

INSERT INTO [dbo].[TaiKhoan]
           ([LoaiTk]
           ,[TenDangNhap]
           ,[MatKHau]
           ,[Email]
           ,[HoTen]
           ,[DiaChi]
           ,[SoDT]
           ,[SoTK]
           ,[NgaySinh]
           ,[HinhDaiDien]
           ,[TinhTrang])
     VALUES
           ('admin','ad1','123','admin1@admin.com',N'Nguyễn Văn A',N'891 Đường Kha Vạn Cân, Thủ Đức, Thành phố Hồ Chí Minh','0707979789','1234567891112','11/11/2000','123.jpg',1),
		   ('admin','ad2','123','vbc@admin.com',N'Nguyễn Văn E',N'118 Nguyễn Cửu Vân, Phường 17, Bình Thạnh, Thành phố Hồ Chí Minh','0707979796','1234567891131','11/11/2000','123.jpg',1),
		   ('user','us1','123','abc@gmail.com',N'Nguyễn Văn B',N'118 Nguyễn Cửu Vân, Phường 17, Bình Thạnh, Thành phố Hồ Chí Minh','0707979799','1234567891213','11/11/2000','123.jpg',1),
		   ('user','us2','123','abcd@gmail.com',N'Nguyễn Văn C',N'118 Nguyễn Cửu Vân, Phường 17, Bình Thạnh, Thành phố Hồ Chí Minh','0707979798','1234567891111','11/11/2000','123.jpg',1),
		   ('user','us3','123','fdc@gmail.com',N'Nguyễn Văn D',N'118 Nguyễn Cửu Vân, Phường 17, Bình Thạnh, Thành phố Hồ Chí Minh','0707979797','1234567891141','11/11/2000','123.jpg',1),
		   ('user','us4','123','ter@gmail.com',N'Nguyễn Văn F',N'118 Nguyễn Cửu Vân, Phường 17, Bình Thạnh, Thành phố Hồ Chí Minh','0707979795','1234567891121','11/11/2000','123.jpg',1)

GO

INSERT INTO [dbo].[NhaCungCaps]
           ([TenNCC]
           ,[Diachi] 
           ,[SDT]
           ,[TinhTrang])
     VALUES
           (N'ABC','68/4','0123456789',1),
		   (N'BBA','78/9','0123456788',1)
GO

INSERT INTO [dbo].[LoaiSPs]
           ([TenLoaiSP]
           ,[TinhTrang])
     VALUES
           (N'Áo',1),
		   (N'Quần',1),
		   (N'Áo khoác',1),
		   (N'Giày',1),
		   (N'Túi',1)
GO

INSERT INTO [dbo].[SanPhams]
           ([TenSp]
           ,[Dongia]
           ,[SoLuong]
           ,[MoTa]
           ,[KichThuoc]
		   ,[NhaCungCapId]
		   ,[LoaiSPId]
           ,[TinhTrang]
           ,[HinhAnh])
     VALUES
	  (N'Áo thun', 150000, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 'S',1,1, 1,'Sp_1.png'),
	  (N'Áo thun cá sấu nam', 170000, 12, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 'XXL',2,2, 1,'Sp_2.png'),
	  (N'Áo hoodie nữ chữ thêu', 200000, 20, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 'XL',1,2, 1,'Sp_3.png'),
	  (N'Áo thun nam thể thao', 100000, 15, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 'XL',2,1, 1,'Sp_4.png'),
	  (N'Áo khoác kaki 2 lớp', 210000, 2, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua..', 'XXL',1,1, 1,'Sp_5.png'),
	  (N'Áo sơ mi nam TIX', 310000, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 'XL',1,2, 1,'Sp_6.png'),
	  (N'Áo sơ mi nam TIX', 310000, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 'XL',2,3, 1,'Sp_7.png'),
	  (N'Áo sơ mi nam TIX', 310000, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 'XL',1,3, 1,'Sp_8.png'),
	  (N'Áo sơ mi nam TIX', 310000, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 'XL',2,3, 1,'Sp_9.png')
GO

INSERT INTO [dbo].[HoaDons]
           ([TaiKhoanId]
           ,[NgayLapHD]
           ,[NgayGiaoHang]
           ,[LoaiHD]
           ,[TongTien]
           ,[ThongTinNguoiNhan]
           ,[TinhTrang])
     VALUES
           (3,'12/20/2021','12/28/2021','N',3400000,N'Họ Tên: Nguyễn Văn B, SĐT: 0707979799, Địa chỉ: 118 Nguyễn Cửu Vân, Phường 17, Bình Thạnh, Thành phố Hồ Chí Minh',1),
		   (3,'12/21/2021','12/29/2021','N',3400000,N'Họ Tên: Nguyễn Văn B, SĐT: 0707979799, Địa chỉ: 118 Nguyễn Cửu Vân, Phường 17, Bình Thạnh, Thành phố Hồ Chí Minh',1),
		   (3,'12/22/2021','12/30/2021','N',3400000,N'Họ Tên: Nguyễn Văn B, SĐT: 0707979799, Địa chỉ: 118 Nguyễn Cửu Vân, Phường 17, Bình Thạnh, Thành phố Hồ Chí Minh',1),
		   (4,'12/20/2021','12/28/2021','N',5000000,N'Họ Tên: Nguyễn Văn C, SĐT: 0707979798, Địa chỉ: 118 Nguyễn Cửu Vân, Phường 17, Bình Thạnh, Thành phố Hồ Chí Minh',1),
		   (4,'12/21/2021','12/29/2021','N',5000000,N'Họ Tên: Nguyễn Văn C, SĐT: 0707979798, Địa chỉ: 118 Nguyễn Cửu Vân, Phường 17, Bình Thạnh, Thành phố Hồ Chí Minh',1),
		   (4,'12/22/2021','12/30/2021','N',5000000,N'Họ Tên: Nguyễn Văn C, SĐT: 0707979798, Địa chỉ: 118 Nguyễn Cửu Vân, Phường 17, Bình Thạnh, Thành phố Hồ Chí Minh',1)
GO

INSERT INTO [dbo].[CT_HoaDons]
           ([HoaDonId]
           ,[SanPhamId]
           ,[SoLuong]
           ,[GiaBan]
           ,[TinhTrang])
     VALUES
           (1,2,20,170000,1),		   
		   (2,2,20,170000,1),		  
		   (3,2,20,170000,1),
		   (4,3,20,200000,1),
		   (4,4,10,100000,1),
		   (5,3,20,200000,1),
		   (5,4,10,100000,1),
		   (6,3,20,200000,1),
		   (6,4,10,100000,1)
GO

INSERT INTO [dbo].[Giohangs]
           ([TaiKhoanId]
           ,[SanPhamId]
           ,[SoLuong])
     VALUES
           (5,1,2),
		   (5,2,6),
		   (5,3,10)

GO

