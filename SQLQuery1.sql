----"Drop Constrain" dùng để xóa bỏ ràng buộc
--"SET IDENTITY_INSERT [tênbảng]" dùng để chèn dữ liệu sau khi xóa mà không bị báo lỗi
USE [EcommerceDB]
Go
--ALTER TABLE [dbo].[Category] DROP CONSTRAINT [ID_Category]
--GO
--ALTER TABLE [dbo].[Product] DROP CONSTRAINT [ID_Product]
--GO
--ALTER TABLE [dbo].[QuanLy] DROP CONSTRAINT [ID_QuanLy]
--GO
--ALTER TABLE [dbo].[Product] DROP CONSTRAINT [ID_Category]
--GO
--ALTER TABLE [dbo].[User] DROP CONSTRAINT [ID_User]
--GO
--ALTER TABLE [dbo].[ID_Product] DROP CONSTRAINT [ID_Product]
--GO
--ALTER TABLE [dbo].[Order] DROP CONSTRAINT [ID_User]
--GO
--ALTER TABLE [dbo].[Order] DROP CONSTRAINT [ID_Product]
--GO  
--Nếu các giá trị thuộc tính và bảng đã tồn tại trong cùng một DB thì xóa
--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderDetails]') AND type in (N'U'))
--DROP TABLE [dbo].[User]
--GO
--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order]') AND type in (N'U'))
--DROP TABLE [dbo].[Order]
--GO
--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Feedback]') AND type in (N'U'))
--DROP TABLE [dbo].[Feedback]
--GO
--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
--DROP TABLE [dbo].[Product]
--GO
--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
--DROP TABLE [dbo].[User]
--GO
--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type in (N'U'))
--DROP TABLE [dbo].[Category]
--GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID_Category] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
    [ID_Category] [int] foreign key references [Category](ID_Category),
	[ID_Product] [int]  identity(1,1)NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[Image] [varchar](200) NULL,
	[Origin] [nvarchar](20) NULL,
	[Price] [float] default 0,
	[Unit][nvarchar](10) NULL,
	[Sale] [float] default 0,
	[PriceF] float default 0,
	[DateManufacture] [datetime] default getdate(),
	[ExpirationDate] [datetime] default getdate(),
	[Description] [nvarchar](50) NULL,
	[DescriptionDTS] [ntext] NULL,
	[Update] datetime default 0,
	
PRIMARY KEY CLUSTERED 
(
	[ID_Product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID_User] [int] identity(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Image] varchar(200) null,
	[Password] [nvarchar](20) NULL,
	[Address] [nvarchar](50) NULL,
	[Gender] [nvarchar](10) NULL,
	[Email] [varchar](50) NULL,
	[DateOfBirth] [date] NULL,
	[PhoneNumber] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID_Order] [int] IDENTITY(1,1) NOT NULL,
	[ID_Product] int foreign key references [Product](ID_Product),
	[ID_User] [int] foreign key references [User](ID_User),  
	[ProductName] [nvarchar](50) NULL,
	[Unit] [nvarchar](10) NULL,
	[Image] [varchar](200) NULL,
	[Price] [float] NOT NULL,
	[Amount] [int] NULL,
	[TotalPrice] [float] NULL,
	[Note] [nvarchar](200) NULL,

PRIMARY KEY CLUSTERED 
(
	[ID_Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLe [dbo].[OrderDetails](
[ID_OrderDetails] int identity(1,1) not null,
[OrderDetailsName] nvarchar(30) null,
[ID_User] int foreign key references [User](ID_User),
[ID_Order] int foreign key references [Order](ID_Order),
[TotalPrice] float default 0,
[Status_] varchar(50) null,
[ODate] datetime default getdate(),

PRIMARY KEY CLUSTERED 
(
	[ID_OrderDetails] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[ID_Fed] [int] IDENTITY(1,1) NOT NULL,
	[ID_User] [int] foreign key references [User](ID_User),
	[FeedbackContent] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(	[ID_Fed] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON
INSERT [dbo].[Category] ([ID_Category],[CategoryName]) Values(1,N'Vegetable')
INSERT [dbo].[Category] ([ID_Category],[CategoryName]) Values(2,N'Meat')
INSERT [dbo].[Category] ([ID_Category],[CategoryName]) Values(3,N'Confectionery')
INSERT [dbo].[Category] ([ID_Category],[CategoryName]) Values(4,N'Milk')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(1,1,N'Artichoke','Arti.jpg',N'TP.HCM',34000,N'bud',NULL,'2022-7-12',N'This is an Vegetable',N'Vegetables are cared for cleanly, without chemicals, ensuring food safety for consumers')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(1,2,N'Cabbage','caibap.jpg',N'TP.HCM',12000,N'kg',NULL,'2022-7-12',N'This is an Vegetable',N'Vegetables are cared for cleanly, without chemicals, ensuring food safety for consumers')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(1,3,N'Carot','carot.jpg',N'TP.HCM',30000,N'kg',NULL,'2022-7-12',N'This is an Vegetable',N'Vegetables are cared for cleanly, without chemicals, ensuring food safety for consumers')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(1,4,N'Cauliflower','cauliflower.jpg',N'TP.HCM',20000,N'kg',NULL,'2022-7-12',N'This is an Vegetable',N'Vegetables are cared for cleanly, without chemicals, ensuring food safety for consumers')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(1,5,N'Bean sprout','giado.jpg',N'TP.ThuDuc',45000,N'kg',NULL,'2022-7-12',N'This is an Vegetable',N'Vegetables are cared for cleanly, without chemicals, ensuring food safety for consumers')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(1,6,N'Asparagus','mangtay.jpg',N'TP.HCM',47000,N'kg',NULL,'2022-7-12',N'This is an Vegetable',N'Vegetables are cared for cleanly, without chemicals, ensuring food safety for consumers')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(1,7,N'Onion','onion.jpg',N'TP.HCM',50000,N'kg',NULL,'2022-7-12',N'This is an Vegetable',N'Vegetables are cared for cleanly, without chemicals, ensuring food safety for consumers')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(1,8,N'Pepper','pepper.jpg',N'TP.HCM',39000,N'kg',NULL,'2022-7-12',N'This is an Vegetable',N'Vegetables are cared for cleanly, without chemicals, ensuring food safety for consumers')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(1,9,N'Pepper powder','tieu.jpg',N'TP.HCM',30000,N'gram',NULL,'2022-7-12',N'This is an Vegetable',N'Vegetables are cared for cleanly, without chemicals, ensuring food safety for consumers')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(2,10,N'Beef','Beef.jpg',N'BinhDuong',215000,N'kg',NULL,'2022-7-12',N'This is an object of Meat',N'Meat can provide your protein, without chemicals, ensuring food safety for consumers')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(2,11,N'Pork','Pork.jpg',N'BinhPhuoc',115000,N'kg',NULL,'2022-7-12',N'This is an object of Meat',N'Meat can provide your protein, without chemicals, ensuring food safety for consumers')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(2,12,N'Sausage','sausage.jpg',N'BinhDuong',94000,N'kg',NULL,'2022-7-12',N'This is an object of Meat',N'Meat can provide your protein, without chemicals, ensuring food safety for consumers')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(2,13,N'Squid','Squid.jpg',N'BinhDuong',155000,N'kg',NULL,'2022-7-12',N'This is an object of Meat',N'Meat can provide your protein, without chemicals, ensuring food safety for consumers')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(3,14,N'Assorted Biscuits','bq1.jpg',N'TP.HCM',34000,N'Box',NULL,'2022-7-12',N'This is an object of Confectionery',N'Confectionary can help your life happiness')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(3,15,N'Hải Châu Biscuits','bqHC.jpg',N'TP.HCM',7000,N'Bag',NULL,'2022-7-12',N'This is an object of Confectionery',N'Confectionary can help your life happiness')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(3,16,N'Chuppa chup','chup3.jpg',N'TP.HCM',43000,N'Bag',NULL,'2022-7-12',N'This is an object of Confectionery',N'Confectionary can help your life happiness')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(3,17,N'Kẹo dẻo ChuppaChup','Chup3d.jpg',N'TP.HCM',120000,N'Box',NULL,'2022-7-12',N'This is an object of Confectionery',N'Confectionary can help your life happiness')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(3,18,N'Sesame Biscuits','cosy.jpg',N'TP.HCM',37000,N'Box',NULL,'2022-7-12',N'This is an object of Confectionery',N'Confectionary can help your life happiness')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(3,19,N'Cosy Biscuits','cosy1.jpg',N'TP.HCM',34000,N'Bag',NULL,'2022-7-12',N'This is an object of Confectionery',N'Confectionary can help your life happiness')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(3,20,N'Dynamite Cake','KeoBH.jpg',N'TP.HCM',21000,N'Bag',NULL,'2022-7-12',N'This is an object of Confectionery',N'Confectionary can help your life happiness')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(3,21,N'Oreo','Oreo.jpg',N'TP.HCM',240000,N'Box',NULL,'2022-7-12',N'This is an object of Confectionery',N'Confectionary can help your life happiness')

INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(4,22,N'Coconut Milk','Coco_Milk.jpg',N'TP.HCM',34000,N'Bottle(s)',NULL,'2022-7-12',N'This is an object of Milk',N'Drinking the Milk can help you have grown!')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(4,23,N'DaLat Milk','DaLat_Milk.jpg',N'TP.HCM',340000,N'Box',NULL,'2022-7-12',N'This is an object of Milk',N'Drinking the Milk can help you have grown!')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(4,24,N'Mộc Châu Milk','MocChau_Milk.jpg',N'TP.HCM',300000,N'Box',NULL,'2022-7-12',N'This is an object of Milk',N'Drinking the Milk can help you have grown!')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(4,25,N'TH Milk','TH_Milk.jpg',N'TP.HCM',320000,N'Box',NULL,'2022-7-12',N'This is an object of Milk',N'Drinking the Milk can help you have grown!')
INSERT [dbo].[Product] ([ID_Category],[ID_Product],[ProductName],[Image],[Origin],[Price],[Unit],[DateManufacture],[ExpirationDate],[Description],[DescriptionDTS])
Values(4,26,N'VinaMilk','Vina_Milk.jpg',N'TP.HCM',285000,N'Box',NULL,'2022-7-12',N'This is an object of Milk',N'Drinking the Milk can help you have grown!')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON
INSERT [dbo].[User] ([ID_User],[UserName],[Password],[Address],[Gender],[Email],[DateOfBirth],[PhoneNumber])
VALUES(01,N'ThaiNguyen',N'nguyen123',N'CuChi',N'Male','Thainguyen@gmail.com','12-3-2001',0963259203)
INSERT [dbo].[User] ([ID_User],[UserName],[Password],[Address],[Gender],[Email],[DateOfBirth],[PhoneNumber])
VALUES(02,N'VanLam',N'lamnv1901',N'ThuDuc',N'Male','Lamnv@gmail.com','9-5-2001',0963259989)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON
INSERT [dbo].[Order] ([ID_Order],[ID_User],[ID_Product],[ProductName],[Unit],[Image],[Price],[Amount],[TotalPrice]) 
VALUES (1,01,21,N'Oreo',N'Piece(s)','Oreo.jpg', 24,5,120)
INSERT [dbo].[Order] ([ID_Order],[ID_User],[ID_Product],[ProductName],[Unit],[Image],[Price],[Amount],[TotalPrice]) 
VALUES (2,01,25,N'TH Milk',N'Box','TH_Milk.jpg', 32,1,32)
INSERT [dbo].[Order] ([ID_Order],[ID_User],[ID_Product],[ProductName],[Unit],[Image],[Price],[Amount],[TotalPrice]) 
VALUES (3,02,21,N'Oreo',N'Box','Oreo.jpg', 24,5,120)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
Set IDENTITY_INSERT [dbo].[OrderDetails] ON
INSERT [dbo].[OrderDetails] ([ID_OrderDetails],[OrderDetailsName],[ID_Order],[ID_User],[Status_],[TotalPrice])
VALUES (1,N'BUY SOMETHINGS',1,01,'Not Yet',120)
Set IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Feedback] ON
INSERT [dbo].[Feedback] ([ID_Fed],[ID_User],[FeedbackContent])
VALUES(1,01,N'Have a lot of Product so expensive and going to Expiration Date')
SET IDENTITY_INSERT [dbo].[Feedback] OFF
GO
ALTER TABLE [dbo].[Order]
  ADD [PaymentMethod] [nvarchar](20);
Go
ALTER TABLE [dbo].[Order]
  ADD [OrderDate] [datetime] default getdate();
GO