USE [master]
GO
/****** Object:  Database [FlamingoDB]    Script Date: 16-12-2020 20:31:52 ******/
CREATE DATABASE [FlamingoDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FlamingoDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\FlamingoDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FlamingoDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\FlamingoDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FlamingoDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FlamingoDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FlamingoDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FlamingoDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FlamingoDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FlamingoDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FlamingoDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [FlamingoDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [FlamingoDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FlamingoDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FlamingoDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FlamingoDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FlamingoDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FlamingoDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FlamingoDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FlamingoDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FlamingoDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FlamingoDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FlamingoDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FlamingoDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FlamingoDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FlamingoDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FlamingoDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FlamingoDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FlamingoDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FlamingoDB] SET  MULTI_USER 
GO
ALTER DATABASE [FlamingoDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FlamingoDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FlamingoDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FlamingoDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FlamingoDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FlamingoDB] SET QUERY_STORE = OFF
GO
USE [FlamingoDB]
GO
/****** Object:  Table [dbo].[Airports]    Script Date: 16-12-2020 20:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airports](
	[AirportID] [int] IDENTITY(100,1) NOT NULL,
	[AirportName] [nvarchar](50) NOT NULL,
	[Location] [nvarchar](max) NOT NULL,
	[Terminal] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AirportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[AirportName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 16-12-2020 20:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[BookingID] [bigint] IDENTITY(1000000,1) NOT NULL,
	[Userid] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flight_details]    Script Date: 16-12-2020 20:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flight_details](
	[FlightID] [nvarchar](10) NOT NULL,
	[Aeroplanename] [nvarchar](20) NOT NULL,
	[Capacity] [int] NOT NULL,
	[Cancelled] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FlightID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passengers]    Script Date: 16-12-2020 20:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passengers](
	[PassengerID] [int] IDENTITY(1000,1) NOT NULL,
	[PassengerName] [varchar](30) NOT NULL,
	[Age] [int] NOT NULL,
	[Gender] [varchar](10) NOT NULL,
	[Nationality] [varchar](15) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[BookingID] [bigint] NOT NULL,
	[Cancelled] [bit] NOT NULL,
 CONSTRAINT [PK_Passengers] PRIMARY KEY CLUSTERED 
(
	[PassengerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 16-12-2020 20:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentID] [int] IDENTITY(1000,1) NOT NULL,
	[PaymentMode] [nvarchar](max) NOT NULL,
	[CardNumber] [nvarchar](50) NOT NULL,
	[CardName] [nvarchar](50) NOT NULL,
	[Price] [money] NOT NULL,
	[TotalAmount] [money] NOT NULL,
	[BookingID] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScheduleFlight]    Script Date: 16-12-2020 20:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleFlight](
	[FlightSchID] [int] IDENTITY(1,1) NOT NULL,
	[FlightID] [nvarchar](10) NULL,
	[Orgin_AirportID] [int] NOT NULL,
	[Origin] [nvarchar](30) NOT NULL,
	[DepartureDay] [nvarchar](20) NOT NULL,
	[DepartureTime] [time](7) NOT NULL,
	[Destination] [nvarchar](30) NOT NULL,
	[ArrivalTime] [time](7) NOT NULL,
	[Duration] [time](7) NOT NULL,
	[Price] [money] NOT NULL,
	[Cancelled] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FlightSchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 16-12-2020 20:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[PNRNumber] [varchar](20) NOT NULL,
	[BookingID] [bigint] NOT NULL,
	[DepartureDate] [date] NOT NULL,
	[ArrivalDate] [date] NOT NULL,
	[ArrivalTime] [time](7) NOT NULL,
	[DepartureTime] [time](7) NOT NULL,
	[Duration] [time](7) NOT NULL,
	[FlightID] [nvarchar](10) NOT NULL,
	[PassengerName] [varchar](30) NOT NULL,
	[Age] [int] NOT NULL,
	[PassengerID] [int] NOT NULL,
	[Gender] [varchar](10) NOT NULL,
	[Origin] [varchar](30) NOT NULL,
	[Destination] [varchar](30) NOT NULL,
	[Cancelled] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PNRNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketAvailability]    Script Date: 16-12-2020 20:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketAvailability](
	[Slno] [int] IDENTITY(1,1) NOT NULL,
	[FlightID] [nvarchar](10) NOT NULL,
	[DepartureDate] [date] NOT NULL,
	[SeatsAvailable] [int] NOT NULL,
 CONSTRAINT [PK_TicketAvailability] PRIMARY KEY CLUSTERED 
(
	[Slno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 16-12-2020 20:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Userid] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[DoB] [date] NOT NULL,
	[Fname] [nvarchar](30) NOT NULL,
	[Lname] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](20) NOT NULL,
	[Phone] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Flight_details] ADD  DEFAULT ((0)) FOR [Cancelled]
GO
ALTER TABLE [dbo].[Passengers] ADD  DEFAULT ((0)) FOR [Cancelled]
GO
ALTER TABLE [dbo].[ScheduleFlight] ADD  DEFAULT ((0)) FOR [Cancelled]
GO
ALTER TABLE [dbo].[Ticket] ADD  DEFAULT ((0)) FOR [Cancelled]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([Userid])
REFERENCES [dbo].[User] ([Userid])
GO
ALTER TABLE [dbo].[Passengers]  WITH CHECK ADD FOREIGN KEY([BookingID])
REFERENCES [dbo].[Booking] ([BookingID])
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD FOREIGN KEY([BookingID])
REFERENCES [dbo].[Booking] ([BookingID])
GO
ALTER TABLE [dbo].[ScheduleFlight]  WITH CHECK ADD FOREIGN KEY([FlightID])
REFERENCES [dbo].[Flight_details] ([FlightID])
GO
ALTER TABLE [dbo].[ScheduleFlight]  WITH CHECK ADD FOREIGN KEY([Orgin_AirportID])
REFERENCES [dbo].[Airports] ([AirportID])
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD FOREIGN KEY([BookingID])
REFERENCES [dbo].[Booking] ([BookingID])
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD FOREIGN KEY([FlightID])
REFERENCES [dbo].[Flight_details] ([FlightID])
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD FOREIGN KEY([PassengerID])
REFERENCES [dbo].[Passengers] ([PassengerID])
GO
ALTER TABLE [dbo].[TicketAvailability]  WITH CHECK ADD FOREIGN KEY([FlightID])
REFERENCES [dbo].[Flight_details] ([FlightID])
GO
USE [master]
GO
ALTER DATABASE [FlamingoDB] SET  READ_WRITE 
GO
