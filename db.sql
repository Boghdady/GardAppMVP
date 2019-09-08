USE [master]
GO
/****** Object:  Database [GardDB]    Script Date: 9/8/2019 3:30:52 PM ******/
CREATE DATABASE [GardDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GardDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\GardDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GardDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\GardDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [GardDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GardDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GardDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GardDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GardDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GardDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GardDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [GardDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GardDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GardDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GardDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GardDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GardDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GardDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GardDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GardDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GardDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GardDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GardDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GardDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GardDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GardDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GardDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GardDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GardDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GardDB] SET  MULTI_USER 
GO
ALTER DATABASE [GardDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GardDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GardDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GardDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GardDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GardDB] SET QUERY_STORE = OFF
GO
USE [GardDB]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 9/8/2019 3:30:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[id] [int] NOT NULL,
	[name] [text] NULL,
	[qty] [real] NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Types]    Script Date: 9/8/2019 3:30:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Types](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tbl_Types] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddItem]    Script Date: 9/8/2019 3:30:53 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
/*
** The system profile of the same type of agent will be used as a template for
** the parameters in this new user profile.
*/
CREATE  procedure [dbo].[sp_AddItem]  (@id int , @ItemName text ,@qty real)
As
INSERT INTO Items VALUES( @id,@ItemName,@qty)

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteAllItems]    Script Date: 9/8/2019 3:30:53 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
/*
** The system profile of the same type of agent will be used as a template for
** the parameters in this new user profile.
*/
CREATE  procedure [dbo].[sp_DeleteAllItems]  
As
BEGIN
    DELETE [dbo].[Items] 
END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllItems]    Script Date: 9/8/2019 3:30:53 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
/*
** The system profile of the same type of agent will be used as a template for
** the parameters in this new user profile.
*/
CREATE procedure [dbo].[SP_GetAllItems]
As
SELECT [id] as 'رقم المنتج',[name] as ' اسم الصنف',[qty] as 'الكمية' FROM [dbo].[Items] 
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllItemsTypes]    Script Date: 9/8/2019 3:30:53 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
/*
** The system profile of the same type of agent will be used as a template for
** the parameters in this new user profile.
*/
CREATE procedure [dbo].[SP_GetAllItemsTypes]
As
SELECT [id] ,[name]  FROM [dbo].[Tbl_Types] 
GO
USE [master]
GO
ALTER DATABASE [GardDB] SET  READ_WRITE 
GO
