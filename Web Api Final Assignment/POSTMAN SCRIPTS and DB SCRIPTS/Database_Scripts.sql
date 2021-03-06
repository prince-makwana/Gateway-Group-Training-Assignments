USE [master]
GO
/****** Object:  Database [Hotel Management System]    Script Date: 1/14/2021 9:22:02 PM ******/
CREATE DATABASE [Hotel Management System]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Hotel Management System', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Hotel Management System.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Hotel Management System_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Hotel Management System_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Hotel Management System] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Hotel Management System].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Hotel Management System] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Hotel Management System] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Hotel Management System] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Hotel Management System] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Hotel Management System] SET ARITHABORT OFF 
GO
ALTER DATABASE [Hotel Management System] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Hotel Management System] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Hotel Management System] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Hotel Management System] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Hotel Management System] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Hotel Management System] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Hotel Management System] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Hotel Management System] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Hotel Management System] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Hotel Management System] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Hotel Management System] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Hotel Management System] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Hotel Management System] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Hotel Management System] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Hotel Management System] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Hotel Management System] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Hotel Management System] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Hotel Management System] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Hotel Management System] SET  MULTI_USER 
GO
ALTER DATABASE [Hotel Management System] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Hotel Management System] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Hotel Management System] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Hotel Management System] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Hotel Management System] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Hotel Management System] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Hotel Management System] SET QUERY_STORE = OFF
GO
USE [Hotel Management System]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 1/14/2021 9:22:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[bookingId] [int] NOT NULL,
	[hotelId] [int] NOT NULL,
	[roomId] [int] NOT NULL,
	[statusOfBooking] [nvarchar](20) NOT NULL,
	[bookingDate] [nvarchar](20) NOT NULL,
	[isActive] [int] NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[bookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 1/14/2021 9:22:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[hid] [int] NOT NULL,
	[hotelName] [nvarchar](200) NOT NULL,
	[address] [nvarchar](200) NULL,
	[city] [nvarchar](50) NOT NULL,
	[pincode] [nvarchar](20) NULL,
	[contactNumber] [nvarchar](20) NOT NULL,
	[contactPerson] [nvarchar](50) NOT NULL,
	[website] [nvarchar](200) NULL,
	[facebook] [nvarchar](200) NULL,
	[Twitter] [nvarchar](200) NULL,
	[isActive] [nchar](10) NOT NULL,
	[createDate] [datetime] NULL,
	[createdBy] [nvarchar](50) NULL,
	[updateDate] [datetime] NULL,
	[updatedBy] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[hid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 1/14/2021 9:22:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[rid] [int] NOT NULL,
	[hotelId] [int] NOT NULL,
	[roomName] [nvarchar](50) NOT NULL,
	[category] [nvarchar](50) NOT NULL,
	[price] [nvarchar](50) NOT NULL,
	[isActive] [bigint] NULL,
	[createdDate] [datetime] NULL,
	[createdBy] [nvarchar](50) NULL,
	[updateDate] [datetime] NULL,
	[updatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[rid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Hotel Management System] SET  READ_WRITE 
GO
