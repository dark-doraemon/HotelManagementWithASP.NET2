use Hotel
go
insert into Trang_Thai_Phong values
('MTT1',N'Trống'),
('MTT2',N'Đang thuê'),
('MTT3',N'Đã đặt trước')

go

insert into Loai_Phong values
('MLP1',N'Phòng đơn',150000),
('MLP2',N'Phòng đôi',280000),
('MLP3',N'Phòng gia đình',480000),
('MLP4',N'Phòng đôi VIP',1000000)
go

insert into Phong values
('P1','P101',N'rẻ','MTT1','MLP1'),
('P2','P102',N'rẻ','MTT1','MLP1'),
('P3','P103',N'rẻ','MTT1','MLP1'),
('P4','P201',N'rẻ','MTT1','MLP2'),
('P5','P202',N'rẻ','MTT1','MLP2'),
('P6','P203',N'rẻ','MTT1','MLP2'),
('P7','P302',N'rẻ','MTT1','MLP3'),
('P8','P303',N'rẻ','MTT1','MLP3'),
('P9','P203',N'rẻ','MTT1','MLP3'),
('P10','P402',N'rẻ','MTT1','MLP4'),
('P11','P403',N'rẻ','MTT1','MLP4')
go


insert into Dich_Vu values
('DV1',N'Pepsi',10000),
('DV2',N'Coca',10000),
('DV3',N'Sting',10000),
('DV4',N'Bia',150000),
('DV5',N'Mì xào',30000)
go

insert into Loai_Tai_Khoan values 
('LTK1','admin'),
('LTK2',N'nhân viên'),
('LTK3',N'khách hàng')

go

insert into Person values
('NV1',N'No name',21,0,'2002-01-20','HN','9038412343','0913412342')

insert into Vai_Tro values
('MVT1',N'quản lý'),
('MVT2',N'nhân viên')
go



insert into Nhan_Vien values
('NV1','MVT1','2023-11-16')
go

insert into Tai_Khoan values
('TK1','admin','1','LTK1','NV1')
go




