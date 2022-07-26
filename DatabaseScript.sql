
------Create WebServiceDemo blank database and run this script to generate tables and stored Procedures and insert data

USE [WebServiceDemo]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 07/17/2020 11:11:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderNo] [nvarchar](50) NULL,
	[ProductName] [nvarchar](50) NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 0) NULL,
	[OrderDate] [date] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 
GO
INSERT [dbo].[OrderDetails] ([OrderID], [OrderNo], [ProductName], [Quantity], [Price], [OrderDate]) VALUES (1, N'11022', N'Monitor', 5, CAST(5000 AS Decimal(18, 0)), CAST(N'2020-07-17' AS Date))
GO
INSERT [dbo].[OrderDetails] ([OrderID], [OrderNo], [ProductName], [Quantity], [Price], [OrderDate]) VALUES (2, N'11023', N'CPU', 2, CAST(4000 AS Decimal(18, 0)), CAST(N'2020-07-01' AS Date))
GO
INSERT [dbo].[OrderDetails] ([OrderID], [OrderNo], [ProductName], [Quantity], [Price], [OrderDate]) VALUES (3, N'11024', N'Mouse', 3, CAST(1000 AS Decimal(18, 0)), CAST(N'2020-07-15' AS Date))
GO
INSERT [dbo].[OrderDetails] ([OrderID], [OrderNo], [ProductName], [Quantity], [Price], [OrderDate]) VALUES (4, N'11025', N'AC', 10, CAST(400000 AS Decimal(18, 0)), CAST(N'2020-08-10' AS Date))
GO
INSERT [dbo].[OrderDetails] ([OrderID], [OrderNo], [ProductName], [Quantity], [Price], [OrderDate]) VALUES (5, N'11026', N'Fan', 5, CAST(5000 AS Decimal(18, 0)), CAST(N'2020-08-10' AS Date))
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
/****** Object:  StoredProcedure [dbo].[GetOrderDetails]    Script Date: 07/17/2020 11:11:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOrderDetails]	
AS
BEGIN
	SELECT OrderNo,ProductName,Quantity,Price,
	CONVERT(NVARCHAR(10),OrderDate,103) AS OrderDate FROM dbo.OrderDetails
	ORDER BY OrderDate
END
GO
/****** Object:  StoredProcedure [dbo].[GetOrderDetailsByDate]    Script Date: 07/17/2020 11:11:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOrderDetailsByDate]	
@FromDate NVARCHAR(10),
@ToDate NVARCHAR(10)
AS
BEGIN
	SELECT OrderNo,ProductName,Quantity,Price,
	CONVERT(NVARCHAR(10),OrderDate,103) AS OrderDate FROM dbo.OrderDetails
	WHERE OrderDate BETWEEN CONVERT(DATE, @FromDate, 105) AND CONVERT(DATE, @ToDate, 105)
	ORDER BY OrderDate
END
