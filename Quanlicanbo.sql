CREATE DATABASE BTLQUANLI;
GO

USE BTLQUANLI;
GO

CREATE TABLE PhongBan (
    MaPhongBan INT PRIMARY KEY IDENTITY(1,1),
    TenPhongBan NVARCHAR(255)
);

CREATE TABLE CanBo (
    MaCanBo INT PRIMARY KEY ,
    HoTen NVARCHAR(255),
    MaPhongBan INT,
    TrinhDo NVARCHAR(50),
    ChucVu NVARCHAR(50),
    NgayVeHuu DATE,
    FOREIGN KEY (MaPhongBan) REFERENCES PhongBan(MaPhongBan)
);
CREATE TABLE YeuCauChinhLuong (
    MaYeuCau INT PRIMARY KEY IDENTITY(1,1),
    MaCanBo INT,
    LuongMoi FLOAT,
    ThangMoi INT,
    NamMoi INT,
    NgayYeuCau DATE,
    TrangThai NVARCHAR(50), -- Trạng thái của yêu cầu (đã xử lý, đang chờ, ...)
    FOREIGN KEY (MaCanBo) REFERENCES CanBo(MaCanBo)
);
CREATE TABLE Luong (
    MaLuong INT PRIMARY KEY IDENTITY(1,1),
    MaCanBo INT,
    Luong FLOAT,
    Thang INT,
    Nam INT,
    MaYeuCau INT,
    FOREIGN KEY (MaCanBo) REFERENCES CanBo(MaCanBo),
    FOREIGN KEY (MaYeuCau) REFERENCES YeuCauChinhLuong(MaYeuCau)
);
INSERT INTO PhongBan (TenPhongBan) VALUES
    ('Khoa hoc co ban'),
    ('Cong nghe thong tin'),
    ('Mo'),
    ('Kinh te & Quan tri kinh doanh'),
    ('Khoa hoc Ky thuat dia chat'),
    ('Ly luan Chinh tri'),
    ('Trac dia - Ban do va quan ly dat dai'),
    ('Giao duc Quoc phong'),
    ('Dau khi va Nang luong'),
    ('Co dien'),
    ('Xay dung'),
    ('Moi truong');

INSERT INTO CanBo (HoTen, MaPhongBan, TrinhDo, ChucVu, NgayVeHuu)
VALUES
    ('Le Van Hung', 2, 'PGS.TS', 'Truong bo mon', CAST('2024-12-11' AS DATE)),
    ('Hoang Anh Duc', 2, 'NCS.Ths', 'Pho bo mon', CAST('2024-12-11' AS DATE)),
    ('Nguyen The Loc', 2, 'GVC.Ts', 'Giang vien', CAST('2024-12-11' AS DATE)),
    ('Pham Van Dong', 2, 'GVC.NCS.ThS', 'Giang vien', CAST('2024-12-11' AS DATE)),
    ('Nguyen Thi Huu Phuong', 2, 'GVC.TS', 'Giang vien', CAST('2024-12-11' AS DATE)),
    ('Dang Huu Nghi', 2, 'GVC.ThS', 'Giang vien', CAST('2024-12-11' AS DATE)),
    ('Ho Thi Thao Trang', 2, 'GV.Ths', 'Giang vien', CAST('2024-12-11' AS DATE)),
    ('Nguyen Thi Thanh', 2, 'Gv.ThS', 'Giang vien', CAST('2024-12-11' AS DATE)),
    ('Bui The Vinh', 2, 'Gv.TS', 'Giang vien', CAST('2024-12-11' AS DATE)),
    ('Pham Thi Hai Van', 2, 'ThS', 'Giang vien', CAST('2024-12-11' AS DATE));

INSERT INTO CanBo (HoTen, MaPhongBan, TrinhDo, ChucVu, NgayVeHuu)
VALUES
    ('Cong Tien Dung', 1, 'GVC.TS', 'Truong Khoa', CAST('2024-12-11' AS DATE)),
    ('Nguyen Manh Hung', 1, 'GVC.TS', 'Truong pho khoa', CAST('2024-12-11' AS DATE)),
    ('Duong Thuy Huong', 1, 'GVC.ThS', 'Truong pho Khoa', CAST('2024-12-11' AS DATE));

INSERT INTO CanBo (HoTen, MaPhongBan, TrinhDo, ChucVu, NgayVeHuu)
VALUES
    ('Pham Van Hoa', 3, 'PGS.TS', 'Truong khoa', CAST('2024-12-11' AS DATE)),
    ('Pham Van Luan', 3, 'PGS.TS', 'Pho Truong khoa', CAST('2024-12-11' AS DATE)),
    ('Vu Trung Tien', 3, 'GVC.Ts', 'Pho Truong khoa', CAST('2024-12-11' AS DATE));

INSERT INTO CanBo (HoTen, MaPhongBan, TrinhDo, ChucVu, NgayVeHuu)
VALUES
    ('Bui Thi Thu Thuy', 4, 'GVCC.TS', 'Truong khoa', CAST('2024-12-11' AS DATE)),
    ('Dao Anh Tuan', 4, 'GVC.TS', 'Pho Truong khoa', CAST('2024-12-11' AS DATE)),
    ('Le Minh Thong', 4, 'GVC.TS', 'Pho Truong khoa', CAST('2024-12-11' AS DATE));

INSERT INTO CanBo (HoTen, MaPhongBan, TrinhDo, ChucVu, NgayVeHuu)
VALUES
    ('Nguyen Tien Dung', 5, 'GVC.TS', 'Truong khoa', CAST('2024-12-11' AS DATE)),
    ('To Xuan Ban', 5, 'GV.TS', 'Pho Truong khoa', CAST('2024-12-11' AS DATE)),
    ('Ngo Xuan Thanh', 5, 'PGS.TS', 'Pho Truong khoa', CAST('2024-12-11' AS DATE));

INSERT INTO CanBo (HoTen, MaPhongBan, TrinhDo, ChucVu, NgayVeHuu)
VALUES
    ('Tran Thi Phuc An', 6, 'GVC.TS', 'Truong khoa', CAST('2024-12-11' AS DATE)),
    ('Nguyen Thi Thu Huong', 6, 'GVC.ThS', 'Pho Truong khoa', CAST('2024-12-11' AS DATE));

INSERT INTO CanBo (HoTen, MaPhongBan, TrinhDo, ChucVu, NgayVeHuu)
VALUES
    ('Le Duc Tinh', 7, 'PGS.TS', 'Truong khoa', CAST('2024-12-11' AS DATE)),
    ('Duong Thanh Trung', 7, 'GVC.TS', 'Pho Truong khoa', CAST('2024-12-11' AS DATE));

INSERT INTO CanBo (HoTen, MaPhongBan, TrinhDo, ChucVu, NgayVeHuu)
VALUES
    ('Nguyen Van A', 8, 'GVC.TS', 'Giang vien', CAST('2024-12-11' AS DATE)),
    ('Nguyen Thi B', 8, 'GVC.ThS', 'Pho giao vien', CAST('2024-12-11' AS DATE));

INSERT INTO CanBo (HoTen, MaPhongBan, TrinhDo, ChucVu, NgayVeHuu)
VALUES
    ('Truong Van C', 9, 'GVC.TS', 'Truong khoa', CAST('2024-12-11' AS DATE)),
    ('Phan Thi D', 9, 'GVC.ThS', 'Pho Truong khoa', CAST('2024-12-11' AS DATE)),
    ('Le Hoang E', 9, 'GVC.Ts', 'Giang vien', CAST('2024-12-11' AS DATE));

INSERT INTO CanBo (HoTen, MaPhongBan, TrinhDo, ChucVu, NgayVeHuu)
VALUES
    ('Nguyen Van F', 10, 'GVC.TS', 'Truong khoa', CAST('2024-12-11' AS DATE)),
    ('Le Thi G', 10, 'GVC.ThS', 'Pho Truong khoa', CAST('2024-12-11' AS DATE)),
    ('Hoang Dinh H', 10, 'GVC.Ts', 'Giang vien', CAST('2024-12-11' AS DATE));

INSERT INTO CanBo (HoTen, MaPhongBan, TrinhDo, ChucVu, NgayVeHuu)
VALUES
    ('Pham Van I', 11, 'GVC.TS', 'Truong khoa', CAST('2024-12-11' AS DATE)),
    ('Nguyen Thi K', 11, 'GVC.ThS', 'Pho Truong khoa', CAST('2024-12-11' AS DATE)),
    ('Tran Van L', 11, 'GVC.Ts', 'Giang vien', CAST('2024-12-11' AS DATE));

INSERT INTO CanBo (HoTen, MaPhongBan, TrinhDo, ChucVu, NgayVeHuu)
VALUES
    ('Le Thi M', 12, 'GVC.TS', 'Truong khoa', CAST('2024-12-11' AS DATE)),
    ('Nguyen Van N', 12, 'GVC.ThS', 'Pho Truong khoa', CAST('2024-12-11' AS DATE)),
    ('Tran Thi O', 12, 'GVC.Ts', 'Giang vien', CAST('2024-12-11' AS DATE));

  
select *from PhongBan
select *from CanBo
select *from Luong
select *from YeuCauChinhLuong