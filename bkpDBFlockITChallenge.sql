USE [master]
GO
/****** Object:  Database [FlockItChallenge]    Script Date: 13/06/2021 13:54:19 ******/
CREATE DATABASE [FlockItChallenge]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FlockItChallenge', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FlockItChallenge.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FlockItChallenge_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FlockItChallenge_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FlockItChallenge] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FlockItChallenge].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FlockItChallenge] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FlockItChallenge] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FlockItChallenge] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FlockItChallenge] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FlockItChallenge] SET ARITHABORT OFF 
GO
ALTER DATABASE [FlockItChallenge] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FlockItChallenge] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FlockItChallenge] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FlockItChallenge] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FlockItChallenge] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FlockItChallenge] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FlockItChallenge] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FlockItChallenge] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FlockItChallenge] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FlockItChallenge] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FlockItChallenge] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FlockItChallenge] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FlockItChallenge] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FlockItChallenge] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FlockItChallenge] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FlockItChallenge] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FlockItChallenge] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FlockItChallenge] SET RECOVERY FULL 
GO
ALTER DATABASE [FlockItChallenge] SET  MULTI_USER 
GO
ALTER DATABASE [FlockItChallenge] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FlockItChallenge] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FlockItChallenge] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FlockItChallenge] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FlockItChallenge] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FlockItChallenge] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'FlockItChallenge', N'ON'
GO
ALTER DATABASE [FlockItChallenge] SET QUERY_STORE = OFF
GO
USE [FlockItChallenge]
GO
/****** Object:  Table [dbo].[USERS]    Script Date: 13/06/2021 13:54:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user] [varchar](20) NOT NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[USERS] ON 
GO
INSERT [dbo].[USERS] ([id], [user], [password]) VALUES (1, N'admin', N'63a9f0ea7bb98050796b649e85481845')
GO
SET IDENTITY_INSERT [dbo].[USERS] OFF
GO
/****** Object:  StoredProcedure [dbo].[USER_C]    Script Date: 13/06/2021 13:54:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USER_C] @name varchar(20), @password varchar(50), @jsonOutput NVARCHAR(MAX) OUTPUT
as
begin
--[User] reserved keyword
SET @jsonOutput = (select U.id, U.[User], U.password from FlockItChallenge.dbo.USERS as U 
where U.[User] = @name AND U.password = @password FOR JSON PATH, WITHOUT_ARRAY_WRAPPER);


end;
GO
USE [master]
GO
ALTER DATABASE [FlockItChallenge] SET  READ_WRITE 
GO
