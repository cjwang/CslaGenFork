USE [master]
GO
/****** Object:  Database [InvoiceTest]    Script Date: 07-02-2017 00:34:45 ******/
CREATE DATABASE [InvoiceTest] ON  PRIMARY 
( NAME = N'InvoiceTest', FILENAME = N'C:\MYDB\InvoiceTest.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'InvoiceTest_log', FILENAME = N'C:\MYDB\InvoiceTest_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [InvoiceTest] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InvoiceTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InvoiceTest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InvoiceTest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InvoiceTest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InvoiceTest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InvoiceTest] SET ARITHABORT OFF 
GO
ALTER DATABASE [InvoiceTest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InvoiceTest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InvoiceTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InvoiceTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InvoiceTest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InvoiceTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InvoiceTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InvoiceTest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InvoiceTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InvoiceTest] SET  DISABLE_BROKER 
GO
ALTER DATABASE [InvoiceTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InvoiceTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InvoiceTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InvoiceTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InvoiceTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InvoiceTest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InvoiceTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InvoiceTest] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [InvoiceTest] SET  MULTI_USER 
GO
ALTER DATABASE [InvoiceTest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InvoiceTest] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'InvoiceTest', N'ON'
GO
USE [InvoiceTest]
GO
/****** Object:  Table [Customers]    Script Date: 07-02-2017 00:34:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Customers](
	[CustomerId] [char](10) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FiscalNumber] [varchar](20) NULL,
	[AddressLine1] [varchar](100) NULL,
	[AddressLine2] [varchar](100) NULL,
	[ZipCode] [varchar](15) NULL,
	[State] [varchar](15) NULL,
	[Coutry] [tinyint] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_CustomerFiscalNumber] UNIQUE NONCLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_CustomerName] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [InvoiceLines]    Script Date: 07-02-2017 00:34:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [InvoiceLines](
	[InvoiceLineId] [uniqueidentifier] NOT NULL,
	[InvoiceId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitCost] [money] NOT NULL,
	[Cost] [money] NOT NULL,
	[PercentDiscount] [tinyint] NOT NULL,
 CONSTRAINT [PK_InvoiceLines] PRIMARY KEY CLUSTERED 
(
	[InvoiceLineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Invoices]    Script Date: 07-02-2017 00:34:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Invoices](
	[InvoiceId] [uniqueidentifier] NOT NULL,
	[InvoiceNumber] [varchar](20) NOT NULL,
	[CustomerId] [char](10) NOT NULL,
	[InvoiceDate] [date] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[CreateUser] [int] NOT NULL,
	[ChangeDate] [datetime2](7) NOT NULL,
	[ChangeUser] [int] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Products]    Script Date: 07-02-2017 00:34:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Products](
	[ProductId] [uniqueidentifier] NOT NULL,
	[ProductCode] [nchar](10) NULL,
	[Name] [varchar](50) NOT NULL,
	[ProductTypeId] [int] NOT NULL,
	[UnitCost] [nchar](10) NOT NULL,
	[StockByteNull] [tinyint] NULL,
	[StockByte] [tinyint] NOT NULL,
	[StockShortNull] [smallint] NULL,
	[StockShort] [smallint] NOT NULL,
	[StockIntNull] [int] NULL,
	[StockInt] [int] NOT NULL,
	[StockLongNull] [bigint] NULL,
	[StockLong] [bigint] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_ProductCode] UNIQUE NONCLUSTERED 
(
	[ProductCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [ProductsSuppliers]    Script Date: 07-02-2017 00:34:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ProductsSuppliers](
	[ProductSupplierId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[SupplierId] [int] NOT NULL,
 CONSTRAINT [PK_ProductsSuppliers] PRIMARY KEY CLUSTERED 
(
	[ProductSupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [ProductTypes]    Script Date: 07-02-2017 00:34:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ProductTypes](
	[ProductTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ProductTypes] PRIMARY KEY CLUSTERED 
(
	[ProductTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_ProductTypesName] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Suppliers]    Script Date: 07-02-2017 00:34:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Suppliers](
	[SupplierId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[AddressLine1] [varchar](100) NULL,
	[AddressLine2] [varchar](100) NULL,
	[ZipCode] [varchar](15) NULL,
	[State] [varchar](15) NULL,
	[Coutry] [tinyint] NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_SupplierName] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_InvoiceCustomer]    Script Date: 07-02-2017 00:34:45 ******/
CREATE NONCLUSTERED INDEX [IX_InvoiceCustomer] ON [Invoices]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_InvoiceDate]    Script Date: 07-02-2017 00:34:45 ******/
CREATE NONCLUSTERED INDEX [IX_InvoiceDate] ON [Invoices]
(
	[InvoiceDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_InvoiceNumber]    Script Date: 07-02-2017 00:34:45 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_InvoiceNumber] ON [Invoices]
(
	[InvoiceNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ProductName]    Script Date: 07-02-2017 00:34:45 ******/
CREATE NONCLUSTERED INDEX [IX_ProductName] ON [Products]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductType]    Script Date: 07-02-2017 00:34:45 ******/
CREATE NONCLUSTERED INDEX [IX_ProductType] ON [Products]
(
	[ProductTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ProductUnitCost]    Script Date: 07-02-2017 00:34:45 ******/
CREATE NONCLUSTERED INDEX [IX_ProductUnitCost] ON [Products]
(
	[UnitCost] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [InvoiceLines]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceLines_Invoices] FOREIGN KEY([InvoiceId])
REFERENCES [Invoices] ([InvoiceId])
GO
ALTER TABLE [InvoiceLines] CHECK CONSTRAINT [FK_InvoiceLines_Invoices]
GO
ALTER TABLE [InvoiceLines]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceLines_Products] FOREIGN KEY([ProductId])
REFERENCES [Products] ([ProductId])
GO
ALTER TABLE [InvoiceLines] CHECK CONSTRAINT [FK_InvoiceLines_Products]
GO
ALTER TABLE [Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Customers] FOREIGN KEY([CustomerId])
REFERENCES [Customers] ([CustomerId])
GO
ALTER TABLE [Invoices] CHECK CONSTRAINT [FK_Invoices_Customers]
GO
ALTER TABLE [Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductTypes] FOREIGN KEY([ProductTypeId])
REFERENCES [ProductTypes] ([ProductTypeId])
GO
ALTER TABLE [Products] CHECK CONSTRAINT [FK_Products_ProductTypes]
GO
ALTER TABLE [ProductsSuppliers]  WITH CHECK ADD  CONSTRAINT [FK_ProductsSuppliers_Products] FOREIGN KEY([ProductId])
REFERENCES [Products] ([ProductId])
GO
ALTER TABLE [ProductsSuppliers] CHECK CONSTRAINT [FK_ProductsSuppliers_Products]
GO
ALTER TABLE [ProductsSuppliers]  WITH CHECK ADD  CONSTRAINT [FK_ProductsSuppliers_Suppliers] FOREIGN KEY([SupplierId])
REFERENCES [Suppliers] ([SupplierId])
GO
ALTER TABLE [ProductsSuppliers] CHECK CONSTRAINT [FK_ProductsSuppliers_Suppliers]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The invoice internal identification' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoices', @level2type=N'COLUMN',@level2name=N'InvoiceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The public invoice number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoices', @level2type=N'COLUMN',@level2name=N'InvoiceNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'For simplicity sake, use the VAT number (no auto increment here).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Suppliers', @level2type=N'COLUMN',@level2name=N'SupplierId'
GO
USE [master]
GO
ALTER DATABASE [InvoiceTest] SET  READ_WRITE 
GO
