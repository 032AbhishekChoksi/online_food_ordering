USE [master]
GO
/****** Object:  Database [online_food]    Script Date: 22-02-2022 11.51.51 PM ******/
CREATE DATABASE [online_food]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'online_food', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\online_food.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'online_food_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\online_food_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [online_food] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [online_food].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [online_food] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [online_food] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [online_food] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [online_food] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [online_food] SET ARITHABORT OFF 
GO
ALTER DATABASE [online_food] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [online_food] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [online_food] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [online_food] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [online_food] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [online_food] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [online_food] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [online_food] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [online_food] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [online_food] SET  DISABLE_BROKER 
GO
ALTER DATABASE [online_food] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [online_food] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [online_food] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [online_food] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [online_food] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [online_food] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [online_food] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [online_food] SET RECOVERY FULL 
GO
ALTER DATABASE [online_food] SET  MULTI_USER 
GO
ALTER DATABASE [online_food] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [online_food] SET DB_CHAINING OFF 
GO
ALTER DATABASE [online_food] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [online_food] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [online_food] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [online_food] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'online_food', N'ON'
GO
ALTER DATABASE [online_food] SET QUERY_STORE = OFF
GO
USE [online_food]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[username] [varchar](25) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Banner]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banner](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[image] [varchar](100) NOT NULL,
	[heading] [varchar](50) NOT NULL,
	[sub_heading] [varchar](25) NOT NULL,
	[link] [varchar](100) NOT NULL,
	[link_text] [varchar](50) NOT NULL,
	[banner_order] [int] NOT NULL,
	[added_on] [datetime] NOT NULL,
	[status] [bit] NOT NULL,
 CONSTRAINT [PK_Banner] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[category] [varchar](50) NOT NULL,
	[status] [bit] NOT NULL,
	[added_on] [datetime] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact_Us]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact_Us](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[mobile] [bigint] NOT NULL,
	[subject] [varchar](100) NOT NULL,
	[message] [text] NOT NULL,
	[added_on] [datetime] NOT NULL,
 CONSTRAINT [PK_Contact_Us] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coupon_Code]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coupon_Code](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[coupon_code] [varchar](20) NOT NULL,
	[coupon_type] [char](1) NOT NULL,
	[coupon_value] [decimal](8, 2) NOT NULL,
	[cart_min_value] [decimal](8, 2) NOT NULL,
	[expired_on] [date] NOT NULL,
	[status] [bit] NOT NULL,
	[added_on] [datetime] NOT NULL,
 CONSTRAINT [PK_Coupon_Code] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[mobile] [bigint] NOT NULL,
	[password] [varchar](50) NOT NULL,
	[status] [bit] NOT NULL,
	[email_verify] [bit] NOT NULL,
	[rand_str] [varchar](20) NOT NULL,
	[referral_code] [varchar](20) NOT NULL,
	[from_referral_code] [varchar](20) NULL,
	[added_on] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Delivery_Boy]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery_Boy](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[mobile] [bigint] NOT NULL,
	[password] [varchar](50) NOT NULL,
	[status] [bit] NOT NULL,
	[added_on] [datetime] NOT NULL,
 CONSTRAINT [PK_Delivery_Boy] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dish]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dish](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[category_id] [int] NOT NULL,
	[dish_name] [varchar](50) NOT NULL,
	[dish_desc] [text] NOT NULL,
	[image] [varchar](70) NOT NULL,
	[type] [char](7) NOT NULL,
	[status] [bit] NOT NULL,
	[added_on] [datetime] NOT NULL,
 CONSTRAINT [PK_Dish] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dish_Cart]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dish_Cart](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[dish_detail_id] [int] NOT NULL,
	[qty] [int] NOT NULL,
	[added_on] [datetime] NOT NULL,
 CONSTRAINT [PK_Dish_Cart] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dish_Details]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dish_Details](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dish_id] [int] NOT NULL,
	[attribute] [varchar](50) NOT NULL,
	[price] [int] NOT NULL,
	[status] [bit] NOT NULL,
	[added_on] [datetime] NOT NULL,
 CONSTRAINT [PK_Dish_Details] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Detail]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Detail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NOT NULL,
	[dish_detail_id] [int] NOT NULL,
	[qty] [int] NOT NULL,
 CONSTRAINT [PK_Order_Detail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Master]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Master](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[address] [text] NOT NULL,
	[total_price] [decimal](8, 2) NOT NULL,
	[coupon_code] [varchar](20) NULL,
	[final_price] [decimal](8, 2) NOT NULL,
	[zipcode] [int] NOT NULL,
	[delivery_boy_id] [int] NULL,
	[payment_status] [varchar](20) NOT NULL,
	[payment_type] [varchar](10) NOT NULL,
	[payment_id] [varchar](100) NULL,
	[order_status] [int] NOT NULL,
	[cancel_by] [char](5) NULL,
	[cancel_at] [datetime] NULL,
	[delivered_on] [datetime] NULL,
	[refund_status] [bit] NULL,
	[added_on] [datetime] NOT NULL,
 CONSTRAINT [PK_Order_Master] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Status]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_status] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Order_Status] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rating]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rating](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[order_id] [int] NOT NULL,
	[dish_detail_id] [int] NOT NULL,
	[rating] [int] NOT NULL,
 CONSTRAINT [PK_Rating] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Setting](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cart_min_price] [decimal](8, 2) NOT NULL,
	[cart_min_price_msg] [varchar](50) NOT NULL,
	[website_close] [char](3) NOT NULL,
	[wallet_amt] [decimal](8, 2) NOT NULL,
	[website_close_msg] [varchar](50) NOT NULL,
	[referral_amt] [decimal](8, 2) NOT NULL,
	[theme_color] [varchar](25) NOT NULL,
 CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wallet]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wallet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[amt] [decimal](8, 2) NOT NULL,
	[msg] [varchar](100) NOT NULL,
	[type] [char](3) NOT NULL,
	[payment_id] [varchar](100) NULL,
	[added_on] [datetime] NOT NULL,
 CONSTRAINT [PK_Wallet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([id], [name], [username], [password], [email]) VALUES (1, N'Abhishek Choksi', N'Admin', N'admin', N'abhishekmeet032015@gmail.com')
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[Banner] ON 

INSERT [dbo].[Banner] ([id], [image], [heading], [sub_heading], [link], [link_text], [banner_order], [added_on], [status]) VALUES (2, N'xL8u1Imv6_slider_1.jpg', N'Drink & Heathy Food', N'Fresh Heathy and Organic.', N'shop.aspx', N'Order Now', 1, CAST(N'2022-01-05T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Banner] ([id], [image], [heading], [sub_heading], [link], [link_text], [banner_order], [added_on], [status]) VALUES (6, N'PWKZ30SOV_slider_2.jpg', N'Drink & Heathy Food', N'Fresh Heathy and Organic.', N'shop.aspx', N'Order Now', 2, CAST(N'2022-02-14T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Banner] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [category], [status], [added_on]) VALUES (1, N'Chart and Snack', 1, CAST(N'2021-12-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Category] ([id], [category], [status], [added_on]) VALUES (2, N'Dessert', 1, CAST(N'2021-12-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Category] ([id], [category], [status], [added_on]) VALUES (5, N'Drink', 1, CAST(N'2022-01-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Category] ([id], [category], [status], [added_on]) VALUES (7, N'Punjabi Food', 1, CAST(N'2022-01-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Category] ([id], [category], [status], [added_on]) VALUES (8, N'Fast Food', 1, CAST(N'2022-02-11T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Coupon_Code] ON 

INSERT [dbo].[Coupon_Code] ([id], [coupon_code], [coupon_type], [coupon_value], [cart_min_value], [expired_on], [status], [added_on]) VALUES (1, N'FIRST#2022', N'F', CAST(40.00 AS Decimal(8, 2)), CAST(20.00 AS Decimal(8, 2)), CAST(N'2022-02-15' AS Date), 1, CAST(N'2022-01-09T00:00:00.000' AS DateTime))
INSERT [dbo].[Coupon_Code] ([id], [coupon_code], [coupon_type], [coupon_value], [cart_min_value], [expired_on], [status], [added_on]) VALUES (2, N'SECOND@2022', N'P', CAST(2.00 AS Decimal(8, 2)), CAST(20.00 AS Decimal(8, 2)), CAST(N'2022-01-18' AS Date), 0, CAST(N'2022-01-09T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Coupon_Code] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([id], [name], [email], [mobile], [password], [status], [email_verify], [rand_str], [referral_code], [from_referral_code], [added_on]) VALUES (16, N'Abhishek Choksi', N'19bmiit032@gmail.com', 7877366968, N'9ACB8BA75C3084662B8B73436297B4B30E7B106F', 1, 1, N'V4ruSbA79TsyH62xkw1Y', N'V4ruSbA79TsyH62xkw1Y', N'', CAST(N'2022-02-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([id], [name], [email], [mobile], [password], [status], [email_verify], [rand_str], [referral_code], [from_referral_code], [added_on]) VALUES (19, N'Abhishek Choksi', N'a.p.choksi420@gmail.com', 2848336751, N'1990CAD0CE34C852B6EAFFE6D42D6A63311E6720', 1, 1, N'pbFHkIWc5Jv3QN164BTX', N'pbFHkIWc5Jv3QN164BTX', N'', CAST(N'2022-02-16T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Delivery_Boy] ON 

INSERT [dbo].[Delivery_Boy] ([id], [name], [mobile], [password], [status], [added_on]) VALUES (1, N'Abhishek Choksi', 9994445554, N'a', 1, CAST(N'2022-01-07T00:00:00.000' AS DateTime))
INSERT [dbo].[Delivery_Boy] ([id], [name], [mobile], [password], [status], [added_on]) VALUES (2, N'Meet Patel', 9944557755, N'a', 1, CAST(N'2022-01-08T00:00:00.000' AS DateTime))
INSERT [dbo].[Delivery_Boy] ([id], [name], [mobile], [password], [status], [added_on]) VALUES (3, N'Deep Shah', 9934445554, N'a', 0, CAST(N'2022-02-11T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Delivery_Boy] OFF
GO
SET IDENTITY_INSERT [dbo].[Dish] ON 

INSERT [dbo].[Dish] ([id], [category_id], [dish_name], [dish_desc], [image], [type], [status], [added_on]) VALUES (1, 1, N'Raj Kachori', N'Give a royal treat to your loved ones by preparing this Raj Kachori at home. This name itself of this dish has ''royal'' in it and the reason for the same is that it''s loaded with all the things you can imagine in a chaat. Well, here is the easiest recipe explained in detail with which you can make Raj Kachori at home.', N'X20Hf1OlI_raj-kachori.jpg', N'veg    ', 1, CAST(N'2021-12-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Dish] ([id], [category_id], [dish_name], [dish_desc], [image], [type], [status], [added_on]) VALUES (2, 2, N'Ice Cream', N'A smooth, sweet, cold food prepared from a frozen mixture of milk products and flavorings, containing a minimum of 10 percent milk fat and eaten as a snack or dessert.', N'IXpsuYfWq_ice_cream.jpg', N'veg    ', 1, CAST(N'2021-12-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Dish] ([id], [category_id], [dish_name], [dish_desc], [image], [type], [status], [added_on]) VALUES (3, 2, N'Gulab Jamun', N'Gulab jamun is an Indian dessert of fried dough balls that are soaked in a sweet, sticky sugar syrup. As per tradition, the syrup has a delicate rose flavour: Gulab means ''rose water'' and jamun refers to a berry of a similar size and colour.', N'HN1DeQk3l_gulab-jamun.jpg', N'veg    ', 0, CAST(N'2021-12-29T00:00:00.000' AS DateTime))
INSERT [dbo].[Dish] ([id], [category_id], [dish_name], [dish_desc], [image], [type], [status], [added_on]) VALUES (6, 8, N'French Fries', N'French fries, chips, finger chips, French-fried potatoes, or simply fries, are batonnet or allumette-cut deep-fried potatoes, originating from either Belgium or France. They are prepared by cutting the potato into even strips, then drying and frying it, usually in a deep fryer', N'mguUZceCs_French-Fries.jpg', N'veg    ', 1, CAST(N'2022-02-11T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Dish] OFF
GO
SET IDENTITY_INSERT [dbo].[Dish_Cart] ON 

INSERT [dbo].[Dish_Cart] ([id], [user_id], [dish_detail_id], [qty], [added_on]) VALUES (1, 16, 12, 2, CAST(N'2022-02-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Dish_Cart] ([id], [user_id], [dish_detail_id], [qty], [added_on]) VALUES (3, 16, 1, 2, CAST(N'2022-02-21T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Dish_Cart] OFF
GO
SET IDENTITY_INSERT [dbo].[Dish_Details] ON 

INSERT [dbo].[Dish_Details] ([id], [dish_id], [attribute], [price], [status], [added_on]) VALUES (1, 1, N'Full Plate Rate', 70, 1, CAST(N'2021-12-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Dish_Details] ([id], [dish_id], [attribute], [price], [status], [added_on]) VALUES (3, 2, N'Per Scoop Rate', 25, 1, CAST(N'2021-12-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Dish_Details] ([id], [dish_id], [attribute], [price], [status], [added_on]) VALUES (4, 3, N'Per Piece Rate', 25, 0, CAST(N'2021-12-29T00:00:00.000' AS DateTime))
INSERT [dbo].[Dish_Details] ([id], [dish_id], [attribute], [price], [status], [added_on]) VALUES (7, 1, N'Half Plate Rate', 35, 0, CAST(N'2021-12-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Dish_Details] ([id], [dish_id], [attribute], [price], [status], [added_on]) VALUES (12, 6, N'200 Gram', 40, 1, CAST(N'2022-02-11T00:00:00.000' AS DateTime))
INSERT [dbo].[Dish_Details] ([id], [dish_id], [attribute], [price], [status], [added_on]) VALUES (13, 6, N'600 Gram', 100, 1, CAST(N'2022-02-11T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Dish_Details] OFF
GO
SET IDENTITY_INSERT [dbo].[Order_Detail] ON 

INSERT [dbo].[Order_Detail] ([id], [order_id], [dish_detail_id], [qty]) VALUES (1, 1, 12, 4)
INSERT [dbo].[Order_Detail] ([id], [order_id], [dish_detail_id], [qty]) VALUES (2, 1, 3, 2)
INSERT [dbo].[Order_Detail] ([id], [order_id], [dish_detail_id], [qty]) VALUES (4, 3, 12, 1)
SET IDENTITY_INSERT [dbo].[Order_Detail] OFF
GO
SET IDENTITY_INSERT [dbo].[Order_Master] ON 

INSERT [dbo].[Order_Master] ([id], [user_id], [address], [total_price], [coupon_code], [final_price], [zipcode], [delivery_boy_id], [payment_status], [payment_type], [payment_id], [order_status], [cancel_by], [cancel_at], [delivered_on], [refund_status], [added_on]) VALUES (1, 19, N'348, Laxmi Villa', CAST(210.00 AS Decimal(8, 2)), N'', CAST(210.00 AS Decimal(8, 2)), 394601, NULL, N'pending', N'cod', NULL, 1, NULL, NULL, NULL, 0, CAST(N'2022-02-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Order_Master] ([id], [user_id], [address], [total_price], [coupon_code], [final_price], [zipcode], [delivery_boy_id], [payment_status], [payment_type], [payment_id], [order_status], [cancel_by], [cancel_at], [delivered_on], [refund_status], [added_on]) VALUES (3, 19, N'Surat', CAST(40.00 AS Decimal(8, 2)), N'', CAST(40.00 AS Decimal(8, 2)), 394601, NULL, N'success', N'wallet', NULL, 1, NULL, NULL, NULL, 0, CAST(N'2022-02-22T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Order_Master] OFF
GO
SET IDENTITY_INSERT [dbo].[Setting] ON 

INSERT [dbo].[Setting] ([id], [cart_min_price], [cart_min_price_msg], [website_close], [wallet_amt], [website_close_msg], [referral_amt], [theme_color]) VALUES (1, CAST(40.00 AS Decimal(8, 2)), N'Cart Min Price will be 40 Rs.', N'no ', CAST(20.00 AS Decimal(8, 2)), N'Website Close for Today', CAST(10.00 AS Decimal(8, 2)), N'darkbluestyle.css')
SET IDENTITY_INSERT [dbo].[Setting] OFF
GO
SET IDENTITY_INSERT [dbo].[Wallet] ON 

INSERT [dbo].[Wallet] ([id], [user_id], [amt], [msg], [type], [payment_id], [added_on]) VALUES (11, 16, CAST(20.00 AS Decimal(8, 2)), N'Register', N'in ', N'', CAST(N'2022-02-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Wallet] ([id], [user_id], [amt], [msg], [type], [payment_id], [added_on]) VALUES (14, 19, CAST(60.00 AS Decimal(8, 2)), N'Register', N'in ', N'', CAST(N'2022-02-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Wallet] ([id], [user_id], [amt], [msg], [type], [payment_id], [added_on]) VALUES (16, 19, CAST(40.00 AS Decimal(8, 2)), N'Order Id- 3', N'out', N'', CAST(N'2022-02-22T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Wallet] OFF
GO
/****** Object:  Index [UK_User]    Script Date: 22-02-2022 11.51.52 PM ******/
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [UK_User] UNIQUE NONCLUSTERED 
(
	[mobile] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UK_Delivery_Boy]    Script Date: 22-02-2022 11.51.52 PM ******/
ALTER TABLE [dbo].[Delivery_Boy] ADD  CONSTRAINT [UK_Delivery_Boy] UNIQUE NONCLUSTERED 
(
	[mobile] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Banner] ADD  CONSTRAINT [DF_Banner_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Coupon_Code] ADD  CONSTRAINT [DF_Coupon_Code_coupon_type]  DEFAULT ('F') FOR [coupon_type]
GO
ALTER TABLE [dbo].[Coupon_Code] ADD  CONSTRAINT [DF_Coupon_Code_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_User_status]  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_User_email_verify]  DEFAULT ((0)) FOR [email_verify]
GO
ALTER TABLE [dbo].[Delivery_Boy] ADD  CONSTRAINT [DF_Delivery_Boy_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Dish] ADD  CONSTRAINT [DF_Dish_type]  DEFAULT ('veg') FOR [type]
GO
ALTER TABLE [dbo].[Dish] ADD  CONSTRAINT [DF_Dish_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Dish_Details] ADD  CONSTRAINT [DF_Dish_Details_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Order_Master] ADD  CONSTRAINT [DF_Order_Master_order_status]  DEFAULT ((0)) FOR [order_status]
GO
ALTER TABLE [dbo].[Order_Master] ADD  CONSTRAINT [DF_Order_Master_refund_status]  DEFAULT ((1)) FOR [refund_status]
GO
ALTER TABLE [dbo].[Setting] ADD  CONSTRAINT [DF__Setting__website__30C33EC3]  DEFAULT ('no') FOR [website_close]
GO
ALTER TABLE [dbo].[Dish]  WITH CHECK ADD  CONSTRAINT [FK_Dish_Category] FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Dish] CHECK CONSTRAINT [FK_Dish_Category]
GO
ALTER TABLE [dbo].[Dish_Cart]  WITH CHECK ADD  CONSTRAINT [FK_Dish_Cart_Dish_Details] FOREIGN KEY([dish_detail_id])
REFERENCES [dbo].[Dish_Details] ([id])
GO
ALTER TABLE [dbo].[Dish_Cart] CHECK CONSTRAINT [FK_Dish_Cart_Dish_Details]
GO
ALTER TABLE [dbo].[Dish_Cart]  WITH CHECK ADD  CONSTRAINT [FK_Dish_Cart_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[Dish_Cart] CHECK CONSTRAINT [FK_Dish_Cart_User]
GO
ALTER TABLE [dbo].[Dish_Details]  WITH CHECK ADD  CONSTRAINT [FK_Dish_Details_Dish] FOREIGN KEY([dish_id])
REFERENCES [dbo].[Dish] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Dish_Details] CHECK CONSTRAINT [FK_Dish_Details_Dish]
GO
ALTER TABLE [dbo].[Order_Detail]  WITH CHECK ADD  CONSTRAINT [FK_Order_Detail_Dish_Details] FOREIGN KEY([dish_detail_id])
REFERENCES [dbo].[Dish_Details] ([id])
GO
ALTER TABLE [dbo].[Order_Detail] CHECK CONSTRAINT [FK_Order_Detail_Dish_Details]
GO
ALTER TABLE [dbo].[Order_Detail]  WITH CHECK ADD  CONSTRAINT [FK_Order_Detail_Order_Master] FOREIGN KEY([order_id])
REFERENCES [dbo].[Order_Master] ([id])
GO
ALTER TABLE [dbo].[Order_Detail] CHECK CONSTRAINT [FK_Order_Detail_Order_Master]
GO
ALTER TABLE [dbo].[Order_Master]  WITH CHECK ADD  CONSTRAINT [FK_Order_Master_Delivery_Boy] FOREIGN KEY([delivery_boy_id])
REFERENCES [dbo].[Delivery_Boy] ([id])
GO
ALTER TABLE [dbo].[Order_Master] CHECK CONSTRAINT [FK_Order_Master_Delivery_Boy]
GO
ALTER TABLE [dbo].[Order_Master]  WITH CHECK ADD  CONSTRAINT [FK_Order_Master_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[Order_Master] CHECK CONSTRAINT [FK_Order_Master_User]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_Rating_Dish_Details] FOREIGN KEY([dish_detail_id])
REFERENCES [dbo].[Dish_Details] ([id])
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_Dish_Details]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_Rating_Order_Master] FOREIGN KEY([order_id])
REFERENCES [dbo].[Order_Master] ([id])
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_Order_Master]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_Rating_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_User]
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_AdminByUsernameAndPassword]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_AdminByUsernameAndPassword]
	@username varchar(50),
	@password varchar(50)
AS
	SELECT * FROM Admin WHERE username=@username AND password=@password
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_Banner]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_Banner]
AS
	SELECT * FROM Banner ORDER BY banner_order
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_BannerById]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_BannerById]
	@id int
AS
	SELECT * FROM Banner where id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_BannerByStatus]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_BannerByStatus]
AS
	SELECT * FROM Banner where status=1 ORDER BY banner_order
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_BannerImage]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_BannerImage]
	@id int
AS
	SELECT image FROM Banner WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_Category]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_Category]
AS
	SELECT * FROM Category ORDER BY id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_CategoryByCategory]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_CategoryByCategory]
	@category varchar(50)
AS
	SELECT * FROM Category WHERE category=@category
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_CategoryByCategoryAndId]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_CategoryByCategoryAndId]
	@id int,
	@category varchar(50)
AS
	SELECT * FROM category WHERE category=@category AND id!=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_CategoryById]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_CategoryById]
	@id int
AS
	SELECT * FROM Category WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_CategoryByStatus]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_CategoryByStatus]
AS
	SELECT id,category FROM Category WHERE status='1' ORDER BY  category ASC
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_CategoryByStatusOrderById]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_CategoryByStatusOrderById]
	@status bit
AS
	SELECT * FROM Category WHERE status=@status ORDER BY id DESC
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_CouponCode]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_CouponCode]
AS
	SELECT * FROM Coupon_Code
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_CouponCodeByCode]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_CouponCodeByCode]
	@coupon_code varchar(20)
AS
	SELECT * FROM Coupon_Code WHERE coupon_code=@coupon_code
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_CouponCodeByCodeAndId]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_CouponCodeByCodeAndId]
	@id int,
	@coupon_code varchar(20)
AS
	SELECT * FROM Coupon_Code WHERE coupon_code=@coupon_code AND id!=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_CouponCodeById]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_CouponCodeById]
	@id int
AS
	SELECT * FROM Coupon_Code WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_CustomerCid]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_CustomerCid]
	@uid int
AS
	SELECT name,email,mobile,referral_code FROM Customer WHERE id=@uid
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_DeliveryBoy]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_DeliveryBoy]
AS
	SELECT * FROM Delivery_Boy ORDER BY id DESC
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_DeliveryBoyById]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_DeliveryBoyById]
	@id int
AS
	SELECT * FROM Delivery_Boy WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_DeliveyBoyByMobile]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_DeliveyBoyByMobile]
	@mobile bigint
AS
	SELECT * FROM Delivery_Boy WHERE mobile=@mobile
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_DeliveyBoyByMobileAndId]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_DeliveyBoyByMobileAndId]
	@id int,
	@mobile bigint
AS
	SELECT * FROM Delivery_Boy WHERE mobile=@mobile AND id!=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_Dish]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_Dish]
AS
	SELECT D.id AS 'id', C.category AS 'category', D.dish_name AS 'dish', D.type AS 'type', D.image AS 'image', D.status AS 'status', D.added_on AS 'added_on'
	FROM Dish D INNER JOIN Category C
	ON D.category_id=C.id AND C.status=1 ORDER BY D.id DESC
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_Dish_DetailsByDishID]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_Dish_DetailsByDishID]
	@dish_id int
AS
	SELECT * FROM Dish_Details WHERE dish_id=@dish_id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_DishAndDishDetailsByDDId]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_DishAndDishDetailsByDDId]
	@ddid int
AS
	SELECT DD.dish_id,D.dish_name AS 'dishName', D.image AS 'dishImage', DD.price 'dishPrice'
	FROM Dish_Details DD INNER JOIN Dish D
	ON DD.dish_id=D.id AND DD.id=@ddid
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_DishById]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_DishById]
	@id int
AS
	SELECT * FROM Dish WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_DishByName]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_DishByName]
	@dish_name varchar(50)
AS
	SELECT * FROM Dish WHERE dish_name=@dish_name
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_DishByNameAndId]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_DishByNameAndId]
	@dish_name varchar(50),
	@id int
AS
	SELECT * FROM Dish WHERE dish_name=@dish_name AND id!=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_DishCartByCId]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_DishCartByCId]
	@uid int
AS
	SELECT DC.* FROM Dish_Cart DC
	INNER JOIN Customer C
	ON DC.user_id = C.id WHERE DC.user_id=@uid
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_DishCategory]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_DishCategory]
	@cat_dish_str varchar(MAX) = '',
	@FilterType NVARCHAR(20) = ''
AS
	IF @FilterType = 'cat_dish'
	BEGIN
		SELECT  D.id AS 'did',D.image AS 'image',D.type AS 'dishtype',D.dish_name AS 'dish_name',D.dish_desc AS 'dish_desc'
		FROM Dish D INNER JOIN Category C 
		ON D.category_id = C.id  WHERE C.status=1 AND D.status=1 AND D.category_id IN  (SELECT value FROM STRING_SPLIT(@cat_dish_str, ','));  
	END
	ELSE
	BEGIN
		SELECT  D.id AS 'did',D.image AS 'image',D.type AS 'dishtype',D.dish_name AS 'dish_name',D.dish_desc AS 'dish_desc'
		FROM Dish D INNER JOIN Category C 
		ON D.category_id = C.id  WHERE C.status=1 AND D.status=1
	END
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_DishDetailsByDdidAndCId]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_DishDetailsByDdidAndCId]
	@uid int,
	@attr int
AS
	SELECT DC.* FROM Dish_Cart DC INNER JOIN Customer C
	ON DC.user_id = C.id INNER JOIN Dish_Details DD
	ON DC.dish_detail_id = DD.id WHERE DC.user_id=@uid AND DC.dish_detail_id=@attr
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_DishDetailsByDid]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_DishDetailsByDid]
	@dish_id int
AS
	SELECT DD.id AS 'DDID', DD.attribute AS 'attribute', DD.price AS 'price', DD.dish_id AS 'dish_id'
	FROM Dish_Details DD INNER JOIN Dish D
	ON DD.dish_id = D.id WHERE DD.dish_id=@dish_id AND DD.status=1 ORDER BY DD.price ASC
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_DishImage]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_DishImage]
	@id int
AS
	SELECT image FROM Dish WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_SettingById]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_SettingById]
	@id int
AS
	SELECT * FROM Setting WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_User]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_User]
AS
	SELECT * FROM Customer
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_UserByEmail]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_UserByEmail]
	@email varchar(50)
AS
	SELECT * FROM Customer WHERE email=@email
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_UserByRandomString]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_UserByRandomString]
	@rand_str varchar(20)
AS
	SELECT rand_str FROM Customer WHERE rand_str=@rand_str
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Display_WalletByUserId]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Display_WalletByUserId]
	@user_id int
AS
	SELECT * FROM Wallet WHERE user_id=@user_id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertion_Banner]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Insertion_Banner]
	@image varchar(100),
	@heading varchar(50),
	@sub_heading varchar(25),
	@link varchar(100),
	@link_text varchar(50),
	@banner_order int,
	@status bit = 1,
	@added_on datetime
AS
	INSERT INTO Banner (image,heading,sub_heading,link,link_text,banner_order,added_on,status) VALUES (@image,@heading,@sub_heading,@link,@link_text,@banner_order,@added_on,@status)
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertion_Category]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Insertion_Category]
	@category varchar(50),
	@status bit = 1,
	@added_on datetime
AS
	INSERT INTO Category (category, status, added_on) VALUES(@category, @status , @added_on)
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertion_CouponCode]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Insertion_CouponCode]
	@coupon_code varchar(20),
	@coupon_type char(1),
	@coupon_value decimal(8,2),
	@cart_min_value decimal(8,2),
	@expired_on date,
	@status bit = 1,
	@added_on datetime
AS
	INSERT INTO Coupon_Code (coupon_code,coupon_type,coupon_value,cart_min_value,expired_on,status,added_on) VALUES (@coupon_code,@coupon_type,@coupon_value,@cart_min_value,@expired_on,@status,@added_on)
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertion_DeliveryBoy]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Insertion_DeliveryBoy]
	@name varchar(50),
	@mobile bigint,
	@password varchar(50),
	@status bit = 1,
	@added_on datetime
AS
	INSERT INTO Delivery_Boy (name,mobile,password,status,added_on) VALUES (@name,@mobile,@password,@status,@added_on)
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertion_Dish]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Insertion_Dish]
	@category_id int,
	@dish_name varchar(50),
	@dish_desc text,
	@image varchar(70),
	@type char(7),
	@status bit = 1,
	@added_on datetime,
	@id int out
AS
	INSERT INTO Dish (category_id,dish_name,dish_desc,image,type,status,added_on) VALUES(@category_id,@dish_name,@dish_desc,@image,@type,@status,@added_on) SET @id=SCOPE_IDENTITY()
RETURN @id
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertion_Dish_Details]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Insertion_Dish_Details]
	@dish_id int,
	@attribute varchar(50),
	@price int,
	@status bit,
	@added_on datetime
AS
	INSERT INTO Dish_Details (dish_id,attribute,price,status,added_on) VALUES (@dish_id,@attribute,@price,@status,@added_on)
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertion_Order_Detail]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Insertion_Order_Detail]
	@order_id int,
	@dish_details_id int,
	@qty int
AS
	INSERT INTO Order_Detail (order_id,dish_detail_id,qty) VALUES(@order_id,@dish_details_id,@qty)
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertion_Order_Master]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Insertion_Order_Master]
	@user_id int,
	@address text,
	@zipcode int,
	@total_price decimal(8, 2),
	@final_price decimal(8, 2),
	@coupon_code varchar(20),
	@order_status int = 1,
	@payment_status varchar(20) = "pending",
	@payment_type varchar(10),
	@refund_status bit = 0,
	@added_on datetime,
	@id int out
AS
	INSERT INTO Order_Master (user_id,address,zipcode,total_price,final_price,coupon_code,order_status,payment_status,payment_type,refund_status,added_on) VALUES(@user_id,@address,@zipcode,@total_price,@final_price,@coupon_code,@order_status,@payment_status,@payment_type,@refund_status,@added_on) SET @id=SCOPE_IDENTITY()
RETURN @id
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertion_User]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Insertion_User]
	@name varchar(50),
	@email varchar(50),
	@mobile bigint,
	@password varchar(50),
	@status bit,
	@email_verify bit,
	@rand_str varchar(20),
	@referral_code varchar(20),
	@from_referral_code varchar(20),
	@added_on datetime,
	@id int out
AS
	INSERT INTO Customer (name,email,mobile,password,status,email_verify,rand_str,referral_code,from_referral_code,added_on) VALUES(@name,@email,@mobile,@password,@status,@email_verify,@rand_str,@referral_code,@from_referral_code,@added_on) SET @id=SCOPE_IDENTITY()
RETURN @id
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertion_Wallet]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Insertion_Wallet]
	@user_id int,
	@amt decimal(8,2),
	@msg varchar(100),
	@type char(3),
	@payment_id varchar(100),
	@added_on datetime

AS
	INSERT INTO Wallet (user_id,amt,msg,type,payment_id,added_on) values(@user_id,@amt,@msg,@type,@payment_id,@added_on)
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Inset_DishCart]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Inset_DishCart]
	@uid int,
	@attr int,
	@qty int,
	@added_on DateTime
AS
	INSERT INTO Dish_Cart (user_id,dish_detail_id,qty,added_on) VALUES(@uid,@attr,@qty,@added_on)
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Remove_Banner]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Remove_Banner]
	@id int
AS
	DELETE FROM Banner WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Remove_Category]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Remove_Category]
	@id int
AS
	DELETE FROM Category WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Remove_Dish_Details]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Remove_Dish_Details]
	@id int
AS
	DELETE FROM Dish_Details WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Remove_DishCartByDdidAndUid]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Remove_DishCartByDdidAndUid]
	@ddid int,
	@uid int
AS
	DELETE FROM Dish_Cart WHERE dish_detail_id=@ddid AND user_id=@uid
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Remove_DishCartByUid]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Remove_DishCartByUid]
	@uid int
AS
	DELETE FROM Dish_Cart WHERE user_id=@uid
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Banner]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_Banner]
	@id int,
	@heading varchar(50),
	@sub_heading varchar(25),
	@link varchar(100),
	@link_text varchar(50),
	@banner_order int
AS
	UPDATE Banner SET heading=@heading, sub_heading=@sub_heading, link=@link, link_text=@link_text, banner_order=@banner_order WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_BannerImage]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_BannerImage]
	@id int,
	@image varchar(100),
	@heading varchar(50),
	@sub_heading varchar(25),
	@link varchar(100),
	@link_text varchar(50),
	@banner_order int
AS
	UPDATE Banner SET image=@image, heading=@heading, sub_heading=@sub_heading, link=@link, link_text=@link_text, banner_order=@banner_order WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_BannerStatus]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_BannerStatus]
	@id int,
	@status bit
AS
	UPDATE Banner SET status=@status WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Category]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_Category]
	@id int,
	@category varchar(50)
AS
	UPDATE Category SET	category=@category WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_CategoryStatus]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_CategoryStatus]
	@id int,
	@status bit
AS
	UPDATE Category SET status=@status WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_CouponCode]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_CouponCode]
	@id int,
	@coupon_code varchar(20),
	@coupon_type char(1),
	@coupon_value decimal(8,2),
	@cart_min_value decimal(8,2),
	@expired_on date
AS
	UPDATE Coupon_Code SET coupon_code=@coupon_code, coupon_type=@coupon_type, coupon_value=@coupon_value, cart_min_value=@cart_min_value, expired_on=@expired_on WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_CouponCodeStatus]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_CouponCodeStatus]
	@id int,
	@status bit
AS
	UPDATE Coupon_Code SET status=@status WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Delivery_BoyStatus]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_Delivery_BoyStatus]
	@id int,
	@status bit
AS
	UPDATE Delivery_Boy SET status=@status WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_DeliveryBoy]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_DeliveryBoy]
	@id int,
	@name varchar(50),
	@mobile bigint,
	@password varchar(50)
AS
	UPDATE Delivery_Boy SET name=@name, mobile=@mobile, @password=@password WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_DeliveryBoyStatus]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_DeliveryBoyStatus]
	@id int,
	@status bit
AS
	UPDATE Delivery_Boy SET status=@status WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Dish]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_Dish]
	@id int,
	@category_id int,
	@dish_name varchar(50),
	@dish_desc text,
	@type char(7)
AS
	UPDATE Dish SET category_id=@category_id, dish_name=@dish_name, dish_desc=@dish_desc, type=@type WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Dish_Details]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_Dish_Details]
	@id int,
	@attribute varchar(50),
	@price int,
	@status bit
AS
	UPDATE Dish_Details SET attribute=@attribute, price=@price, status=@status WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_DishCartByCartID]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_DishCartByCartID]
	@qty int,
	@cartid int
AS
	UPDATE Dish_Cart SET qty=@qty WHERE id=@cartid
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_DishCartQTYByUid]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_DishCartQTYByUid]
	@qty int,
	@ddid int,
	@uid int
AS
	UPDATE Dish_Cart SET qty=@qty WHERE dish_detail_id=@ddid AND user_id=@uid
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_DishImage]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_DishImage]
	@id int,
	@category_id int,
	@dish_name varchar(50),
	@dish_desc text,
	@image varchar(70),
	@type char(7)
AS
	UPDATE Dish SET category_id=@category_id, dish_name=@dish_name, dish_desc=@dish_desc, image=@image, type=@type WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_DishStatus]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_DishStatus]
	@id int,
	@status bit
AS
	UPDATE Dish SET status=@status WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_OrderMasterPaymentStatusById]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_OrderMasterPaymentStatusById]
	@payment_status varchar(20),
	@id int
AS
	UPDATE Order_Master SET payment_status=@payment_status WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Setting]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_Setting]
	@id int,
	@cart_min_price decimal(8,2),
	@cart_min_price_msg varchar(50),
	@website_close char(3),
	@website_close_msg varchar(50),
	@wallet_amt decimal(8,2),
	@referral_amt decimal(8,2),
	@theme_color varchar(25)
AS
	UPDATE Setting SET cart_min_price=@cart_min_price, cart_min_price_msg=@cart_min_price_msg, website_close=@website_close, wallet_amt=@wallet_amt, website_close_msg=@website_close_msg, referral_amt=@referral_amt, theme_color=@theme_color WHERE id=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_UserEmailVerify]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_UserEmailVerify]
	@rand_str varchar(20),
	@email_verify bit
AS
	UPDATE Customer SET email_verify=@email_verify WHERE rand_str=@rand_str
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_UserStatus]    Script Date: 22-02-2022 11.51.52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_UserStatus]
	@id int,
	@status bit
AS
	UPDATE Customer SET status=@status WHERE id=@id
RETURN 0
GO
USE [master]
GO
ALTER DATABASE [online_food] SET  READ_WRITE 
GO
