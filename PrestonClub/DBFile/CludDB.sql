USE [master]
GO
/****** Object:  Database [PrestonClubDB]    Script Date: 2022-12-05 23:36:34 ******/
CREATE DATABASE [PrestonClubDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PrestonClubDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PrestonClubDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PrestonClubDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PrestonClubDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PrestonClubDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PrestonClubDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PrestonClubDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PrestonClubDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PrestonClubDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PrestonClubDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PrestonClubDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PrestonClubDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PrestonClubDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PrestonClubDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PrestonClubDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PrestonClubDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PrestonClubDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PrestonClubDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PrestonClubDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PrestonClubDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PrestonClubDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PrestonClubDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PrestonClubDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PrestonClubDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PrestonClubDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PrestonClubDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PrestonClubDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PrestonClubDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PrestonClubDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PrestonClubDB] SET  MULTI_USER 
GO
ALTER DATABASE [PrestonClubDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PrestonClubDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PrestonClubDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PrestonClubDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PrestonClubDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PrestonClubDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PrestonClubDB] SET QUERY_STORE = OFF
GO
USE [PrestonClubDB]
GO
/****** Object:  Table [dbo].[AmateurSponserDetails]    Script Date: 2022-12-05 23:36:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AmateurSponserDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Runner_ID] [int] NOT NULL,
	[Sponsor_Id] [int] NOT NULL,
	[SponsorAmount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_AmateurSponserDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParticipantDetails]    Script Date: 2022-12-05 23:36:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParticipantDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_ParticipantDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegistrationDetails]    Script Date: 2022-12-05 23:36:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistrationDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[phone_number] [nvarchar](50) NOT NULL,
	[address] [nvarchar](200) NOT NULL,
	[ParticipantsID] [int] NOT NULL,
	[WorldRanking] [int] NULL,
	[Volunteer_ID] [int] NULL,
	[password] [nvarchar](100) NULL,
	[UserType] [nvarchar](50) NULL,
	[costume] [varchar](100) NULL,
 CONSTRAINT [PK_RegistrationDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RunnerStatus]    Script Date: 2022-12-05 23:36:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RunnerStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Runner_ID] [int] NULL,
	[RunningStatus] [nvarchar](50) NULL,
	[FinishedTime] [nvarchar](50) NULL,
 CONSTRAINT [PK_RunnerStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SponserList]    Script Date: 2022-12-05 23:36:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SponserList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SponserList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Volunteer_Types]    Script Date: 2022-12-05 23:36:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Volunteer_Types](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Volunteer_Types] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AmateurSponserDetails] ON 

INSERT [dbo].[AmateurSponserDetails] ([ID], [Runner_ID], [Sponsor_Id], [SponsorAmount]) VALUES (1, 1, 1, CAST(125.00 AS Decimal(18, 2)))
INSERT [dbo].[AmateurSponserDetails] ([ID], [Runner_ID], [Sponsor_Id], [SponsorAmount]) VALUES (2, 1, 2, CAST(150.00 AS Decimal(18, 2)))
INSERT [dbo].[AmateurSponserDetails] ([ID], [Runner_ID], [Sponsor_Id], [SponsorAmount]) VALUES (3, 6, 2, CAST(250.00 AS Decimal(18, 2)))
INSERT [dbo].[AmateurSponserDetails] ([ID], [Runner_ID], [Sponsor_Id], [SponsorAmount]) VALUES (5, 6, 1, CAST(12.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[AmateurSponserDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[ParticipantDetails] ON 

INSERT [dbo].[ParticipantDetails] ([ID], [Name]) VALUES (1, N'Amateur Runners')
INSERT [dbo].[ParticipantDetails] ([ID], [Name]) VALUES (2, N'Professionals Runners')
INSERT [dbo].[ParticipantDetails] ([ID], [Name]) VALUES (3, N'Volunteers')
SET IDENTITY_INSERT [dbo].[ParticipantDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[RegistrationDetails] ON 

INSERT [dbo].[RegistrationDetails] ([ID], [first_name], [last_name], [email], [phone_number], [address], [ParticipantsID], [WorldRanking], [Volunteer_ID], [password], [UserType], [costume]) VALUES (1, N'Amateur', N'Runner', N'AmateurRunner@gmail.com', N'1231231231', N'Test address', 1, NULL, NULL, N'123456', N'User', N'Snow White')
INSERT [dbo].[RegistrationDetails] ([ID], [first_name], [last_name], [email], [phone_number], [address], [ParticipantsID], [WorldRanking], [Volunteer_ID], [password], [UserType], [costume]) VALUES (2, N'Proffessional', N'Runner', N'Proffessional@gmail.com', N'1231231231', N'Test address', 2, 12, NULL, N'123456', N'User', N'Red')
INSERT [dbo].[RegistrationDetails] ([ID], [first_name], [last_name], [email], [phone_number], [address], [ParticipantsID], [WorldRanking], [Volunteer_ID], [password], [UserType], [costume]) VALUES (3, N'Test', N'Valunteer', N'Test@gmail.com', N'1231231231', N'Test', 3, NULL, 1, N'123456', N'User', N'')
INSERT [dbo].[RegistrationDetails] ([ID], [first_name], [last_name], [email], [phone_number], [address], [ParticipantsID], [WorldRanking], [Volunteer_ID], [password], [UserType], [costume]) VALUES (5, N'Admin', N'User', N'Admin@gmail.com', N'1231231231', N'Test Admin', 3, NULL, NULL, N'123456', N'Admin', N'')
INSERT [dbo].[RegistrationDetails] ([ID], [first_name], [last_name], [email], [phone_number], [address], [ParticipantsID], [WorldRanking], [Volunteer_ID], [password], [UserType], [costume]) VALUES (6, N'Amateur', N'New', N'NewRunner@gmail.com', N'1231231231', N'Test', 1, NULL, NULL, N'123456', N'User', N'Yellow')
INSERT [dbo].[RegistrationDetails] ([ID], [first_name], [last_name], [email], [phone_number], [address], [ParticipantsID], [WorldRanking], [Volunteer_ID], [password], [UserType], [costume]) VALUES (7, N'Test', N'Test', N'test@gmail.com', N'1231231231', N'Test', 3, NULL, 2, N'123456', N'User', N'Yellow')
SET IDENTITY_INSERT [dbo].[RegistrationDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[RunnerStatus] ON 

INSERT [dbo].[RunnerStatus] ([ID], [Runner_ID], [RunningStatus], [FinishedTime]) VALUES (1, 1, N'Finished', N'15:11:12')
SET IDENTITY_INSERT [dbo].[RunnerStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[SponserList] ON 

INSERT [dbo].[SponserList] ([ID], [Name]) VALUES (1, N'Test Sponsor')
INSERT [dbo].[SponserList] ([ID], [Name]) VALUES (2, N'Sponsor 2')
SET IDENTITY_INSERT [dbo].[SponserList] OFF
GO
SET IDENTITY_INSERT [dbo].[Volunteer_Types] ON 

INSERT [dbo].[Volunteer_Types] ([ID], [Name]) VALUES (1, N'Drink Station')
INSERT [dbo].[Volunteer_Types] ([ID], [Name]) VALUES (2, N'Marshalling')
SET IDENTITY_INSERT [dbo].[Volunteer_Types] OFF
GO
ALTER TABLE [dbo].[RegistrationDetails] ADD  DEFAULT (NULL) FOR [costume]
GO
ALTER TABLE [dbo].[AmateurSponserDetails]  WITH CHECK ADD  CONSTRAINT [FK_AmateurSponserDetails_RegistrationDetails] FOREIGN KEY([Runner_ID])
REFERENCES [dbo].[RegistrationDetails] ([ID])
GO
ALTER TABLE [dbo].[AmateurSponserDetails] CHECK CONSTRAINT [FK_AmateurSponserDetails_RegistrationDetails]
GO
ALTER TABLE [dbo].[AmateurSponserDetails]  WITH CHECK ADD  CONSTRAINT [FK_AmateurSponserDetails_SponserList] FOREIGN KEY([Sponsor_Id])
REFERENCES [dbo].[SponserList] ([ID])
GO
ALTER TABLE [dbo].[AmateurSponserDetails] CHECK CONSTRAINT [FK_AmateurSponserDetails_SponserList]
GO
ALTER TABLE [dbo].[RegistrationDetails]  WITH CHECK ADD  CONSTRAINT [FK_RegistrationDetails_ParticipantDetails] FOREIGN KEY([ParticipantsID])
REFERENCES [dbo].[ParticipantDetails] ([ID])
GO
ALTER TABLE [dbo].[RegistrationDetails] CHECK CONSTRAINT [FK_RegistrationDetails_ParticipantDetails]
GO
ALTER TABLE [dbo].[RegistrationDetails]  WITH CHECK ADD  CONSTRAINT [FK_RegistrationDetails_Volunteer_Types] FOREIGN KEY([Volunteer_ID])
REFERENCES [dbo].[Volunteer_Types] ([ID])
GO
ALTER TABLE [dbo].[RegistrationDetails] CHECK CONSTRAINT [FK_RegistrationDetails_Volunteer_Types]
GO
ALTER TABLE [dbo].[RunnerStatus]  WITH CHECK ADD  CONSTRAINT [FK_RunnerStatus_RegistrationDetails] FOREIGN KEY([Runner_ID])
REFERENCES [dbo].[RegistrationDetails] ([ID])
GO
ALTER TABLE [dbo].[RunnerStatus] CHECK CONSTRAINT [FK_RunnerStatus_RegistrationDetails]
GO
USE [master]
GO
ALTER DATABASE [PrestonClubDB] SET  READ_WRITE 
GO
