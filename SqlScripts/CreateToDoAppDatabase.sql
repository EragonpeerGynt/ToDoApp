USE [master]
GO
/****** Object:  Database [ToDoApp]    Script Date: 05/08/2023 13:52:47 ******/
CREATE DATABASE [ToDoApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ToDoApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.TODOAPP\MSSQL\DATA\ToDoApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ToDoApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.TODOAPP\MSSQL\DATA\ToDoApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ToDoApp] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ToDoApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ToDoApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ToDoApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ToDoApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ToDoApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ToDoApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [ToDoApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ToDoApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ToDoApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ToDoApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ToDoApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ToDoApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ToDoApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ToDoApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ToDoApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ToDoApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ToDoApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ToDoApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ToDoApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ToDoApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ToDoApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ToDoApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ToDoApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ToDoApp] SET RECOVERY FULL 
GO
ALTER DATABASE [ToDoApp] SET  MULTI_USER 
GO
ALTER DATABASE [ToDoApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ToDoApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ToDoApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ToDoApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ToDoApp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ToDoApp] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ToDoApp', N'ON'
GO
ALTER DATABASE [ToDoApp] SET QUERY_STORE = ON
GO
ALTER DATABASE [ToDoApp] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ToDoApp]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 05/08/2023 13:52:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Naslov] [nvarchar](50) NOT NULL,
	[Opis] [nvarchar](250) NULL,
	[DatumUstvarjanja] [datetime2](7) NOT NULL,
	[Opravljeno] [bit] NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Task] ADD  CONSTRAINT [DF_Task_Opravljeno]  DEFAULT ((0)) FOR [Opravljeno]
GO
USE [master]
GO
ALTER DATABASE [ToDoApp] SET  READ_WRITE 
GO
