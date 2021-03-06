USE [FurnitureSaleDB]
GO
/****** Object:  Table [dbo].[productcategories]    Script Date: 12/19/2017 11:31:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productcategories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 12/19/2017 11:31:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](255) NOT NULL,
	[ProductPrice] [money] NOT NULL,
	--[ProductWeight] [float] NULL,
	--[ProductQuantity] [int] NULL,
	--[ProductDimension] [varchar](255) NULL,
	--[ProductMsrp] [int] NULL,
	[ProductDescription] [varchar](max) NULL,
	[ProductImageName1] [varchar](255) NULL,
	[ProductImageName2] [varchar](255) NULL,
	[ProductImageName3] [varchar](255) NULL,
	[ProductCategoryID] [int] NOT NULL,
	[ProductQuantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[products]  WITH CHECK ADD  CONSTRAINT [fk_products_ProductCategoryId] FOREIGN KEY([ProductCategoryID])
REFERENCES [dbo].[productcategories] ([CategoryID])
GO
ALTER TABLE [dbo].[products] CHECK CONSTRAINT [fk_products_ProductCategoryId]
GO


--drop table  products;
--drop table productcategories;


--SELECT TOP 20 products.* from products;
--select *  from products;
--select * from productcategories;

Insert into productcategories (CategoryName) values('LivingRoom');
Insert into productcategories (CategoryName) values('BedRoom');
Insert into productcategories (CategoryName) values('DiningRoom');
Insert into productcategories (CategoryName) values('Kitchen');
Insert into productcategories (CategoryName) values('Babies & Kids');

--delete from products where ProductCategoryID = 1;
--delete from productcategories where CategoryName = 'LivingRoom';

--SELECT products.*, productcategories.* FROM products JOIN productcategories ON products.ProductCategoryID = productcategories.CategoryID WHERE products.ProductID =1;
--UPDATE products set ProductName = 'test', ProductPrice = 119, ProductDescription = 'small', ProductImageName1 = '', ProductCategoryID = 3 WHERE ProductID = 1