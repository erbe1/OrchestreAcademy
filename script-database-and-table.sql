USE [master]
GO
/****** Object:  Database [OrchesterAcademy]    Script Date: 2019-01-11 14:52:42 ******/
CREATE DATABASE [OrchesterAcademy]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OrchesterAcademy', FILENAME = N'C:\Users\Administrator\OrchesterAcademy.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OrchesterAcademy_log', FILENAME = N'C:\Users\Administrator\OrchesterAcademy_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [OrchesterAcademy] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OrchesterAcademy].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OrchesterAcademy] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OrchesterAcademy] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OrchesterAcademy] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OrchesterAcademy] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OrchesterAcademy] SET ARITHABORT OFF 
GO
ALTER DATABASE [OrchesterAcademy] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OrchesterAcademy] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OrchesterAcademy] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OrchesterAcademy] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OrchesterAcademy] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OrchesterAcademy] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OrchesterAcademy] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OrchesterAcademy] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OrchesterAcademy] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OrchesterAcademy] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OrchesterAcademy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OrchesterAcademy] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OrchesterAcademy] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OrchesterAcademy] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OrchesterAcademy] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OrchesterAcademy] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OrchesterAcademy] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OrchesterAcademy] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OrchesterAcademy] SET  MULTI_USER 
GO
ALTER DATABASE [OrchesterAcademy] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OrchesterAcademy] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OrchesterAcademy] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OrchesterAcademy] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OrchesterAcademy] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OrchesterAcademy] SET QUERY_STORE = OFF
GO
USE [OrchesterAcademy]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [OrchesterAcademy]
GO
/****** Object:  Table [dbo].[Arrangör]    Script Date: 2019-01-11 14:52:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Arrangör](
	[ArrangörId] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NULL,
 CONSTRAINT [PK_Arrangör] PRIMARY KEY CLUSTERED 
(
	[ArrangörId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bokningar]    Script Date: 2019-01-11 14:52:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bokningar](
	[MusikerId] [int] NOT NULL,
	[StyckeNamn] [nvarchar](50) NOT NULL,
	[ArrangörId] [int] NULL,
	[EventId] [int] NULL,
	[InstrumentNamn] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 2019-01-11 14:52:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[StadNamn] [nvarchar](50) NULL,
	[Datum] [datetime] NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Instrument]    Script Date: 2019-01-11 14:52:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instrument](
	[InstrumentNamn] [nvarchar](50) NOT NULL,
	[InstrumentKlass] [nvarchar](50) NULL,
 CONSTRAINT [PK_Instrument] PRIMARY KEY CLUSTERED 
(
	[InstrumentNamn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musiker]    Script Date: 2019-01-11 14:52:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musiker](
	[MusikerId] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NULL,
 CONSTRAINT [PK_Musiker] PRIMARY KEY CLUSTERED 
(
	[MusikerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MusikerInstrument]    Script Date: 2019-01-11 14:52:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MusikerInstrument](
	[MusikerId] [int] NOT NULL,
	[Istrumentnamn] [nvarchar](50) NOT NULL,
	[Nivå] [int] NULL,
 CONSTRAINT [PK_MusikerInstrument] PRIMARY KEY CLUSTERED 
(
	[MusikerId] ASC,
	[Istrumentnamn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 2019-01-11 14:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[Förnamn] [nvarchar](50) NULL,
	[Efternamn] [nvarchar](50) NULL,
	[TelefonNummer] [int] NULL,
	[StadsNamn] [nvarchar](50) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stad]    Script Date: 2019-01-11 14:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stad](
	[StadsNamn] [nvarchar](50) NOT NULL,
	[X] [int] NULL,
	[Y] [int] NULL,
 CONSTRAINT [PK_Stad] PRIMARY KEY CLUSTERED 
(
	[StadsNamn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stycken]    Script Date: 2019-01-11 14:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stycken](
	[StyckeNamn] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Stycken_1] PRIMARY KEY CLUSTERED 
(
	[StyckeNamn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StyckesInstrument]    Script Date: 2019-01-11 14:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StyckesInstrument](
	[StyckeNamn] [nvarchar](50) NOT NULL,
	[InstrumentNamn] [nvarchar](50) NOT NULL,
	[Nivå] [int] NULL,
 CONSTRAINT [PK_StyckesInstrument] PRIMARY KEY CLUSTERED 
(
	[StyckeNamn] ASC,
	[InstrumentNamn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Arrangör] ON 

INSERT [dbo].[Arrangör] ([ArrangörId], [PersonId]) VALUES (1, 4)
INSERT [dbo].[Arrangör] ([ArrangörId], [PersonId]) VALUES (2, 7)
INSERT [dbo].[Arrangör] ([ArrangörId], [PersonId]) VALUES (3, 12)
SET IDENTITY_INSERT [dbo].[Arrangör] OFF
INSERT [dbo].[Bokningar] ([MusikerId], [StyckeNamn], [ArrangörId], [EventId], [InstrumentNamn]) VALUES (1, N'Crocodile Rock', 1, 1, N'Valthorn')
INSERT [dbo].[Bokningar] ([MusikerId], [StyckeNamn], [ArrangörId], [EventId], [InstrumentNamn]) VALUES (1, N'Under Blå Gul Fana', 1, 1, N'Valthorn')
INSERT [dbo].[Bokningar] ([MusikerId], [StyckeNamn], [ArrangörId], [EventId], [InstrumentNamn]) VALUES (2, N'Crocodile Rock', 1, 1, N'Valvofon')
INSERT [dbo].[Bokningar] ([MusikerId], [StyckeNamn], [ArrangörId], [EventId], [InstrumentNamn]) VALUES (3, N'Crocodile Rock', 1, 1, N'Cello')
INSERT [dbo].[Bokningar] ([MusikerId], [StyckeNamn], [ArrangörId], [EventId], [InstrumentNamn]) VALUES (4, N'Crocodile Rock', 1, 1, N'Klarinett')
INSERT [dbo].[Bokningar] ([MusikerId], [StyckeNamn], [ArrangörId], [EventId], [InstrumentNamn]) VALUES (5, N'My Favourite Things', 1, 1, N'Piano')
INSERT [dbo].[Bokningar] ([MusikerId], [StyckeNamn], [ArrangörId], [EventId], [InstrumentNamn]) VALUES (5, N'Under Blå Gul Fana', 1, 1, N'Tvärflöjt')
INSERT [dbo].[Bokningar] ([MusikerId], [StyckeNamn], [ArrangörId], [EventId], [InstrumentNamn]) VALUES (6, N'My Favourite Things', 1, 1, N'Batteri')
INSERT [dbo].[Bokningar] ([MusikerId], [StyckeNamn], [ArrangörId], [EventId], [InstrumentNamn]) VALUES (6, N'Under Blå Gul Fana', 1, 1, N'Batteri')
INSERT [dbo].[Bokningar] ([MusikerId], [StyckeNamn], [ArrangörId], [EventId], [InstrumentNamn]) VALUES (8, N'Crocodile Rock', 1, 1, N'Triangel')
INSERT [dbo].[Bokningar] ([MusikerId], [StyckeNamn], [ArrangörId], [EventId], [InstrumentNamn]) VALUES (9, N'Under Blå Gul Fana', 1, 1, N'Trumpet')
INSERT [dbo].[Bokningar] ([MusikerId], [StyckeNamn], [ArrangörId], [EventId], [InstrumentNamn]) VALUES (12, N'My Favourite Things', 1, 1, N'Trombon')
INSERT [dbo].[Bokningar] ([MusikerId], [StyckeNamn], [ArrangörId], [EventId], [InstrumentNamn]) VALUES (14, N'My Favourite Things', 1, 1, N'Kontrabas')
INSERT [dbo].[Bokningar] ([MusikerId], [StyckeNamn], [ArrangörId], [EventId], [InstrumentNamn]) VALUES (15, N'My Favourite Things', 1, 1, N'Saxofon')
SET IDENTITY_INSERT [dbo].[Event] ON 

INSERT [dbo].[Event] ([EventId], [StadNamn], [Datum]) VALUES (1, N'Göteborg', CAST(N'2019-03-16T19:30:00.000' AS DateTime))
INSERT [dbo].[Event] ([EventId], [StadNamn], [Datum]) VALUES (2, N'Växjö', CAST(N'2019-06-06T20:00:00.000' AS DateTime))
INSERT [dbo].[Event] ([EventId], [StadNamn], [Datum]) VALUES (3, N'Strängnäs', CAST(N'2019-09-11T18:00:00.000' AS DateTime))
INSERT [dbo].[Event] ([EventId], [StadNamn], [Datum]) VALUES (1010, N'Munktorp', CAST(N'2030-03-06T20:00:00.000' AS DateTime))
INSERT [dbo].[Event] ([EventId], [StadNamn], [Datum]) VALUES (1011, N'Göteborg', CAST(N'2019-03-01T16:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Event] OFF
INSERT [dbo].[Instrument] ([InstrumentNamn], [InstrumentKlass]) VALUES (N'Batteri', N'Slagverk')
INSERT [dbo].[Instrument] ([InstrumentNamn], [InstrumentKlass]) VALUES (N'Cello', N'Stränginstrument')
INSERT [dbo].[Instrument] ([InstrumentNamn], [InstrumentKlass]) VALUES (N'Eufonium', N'Brass')
INSERT [dbo].[Instrument] ([InstrumentNamn], [InstrumentKlass]) VALUES (N'Fagott', N'Tråblås')
INSERT [dbo].[Instrument] ([InstrumentNamn], [InstrumentKlass]) VALUES (N'Fiol', N'Stränginstrument')
INSERT [dbo].[Instrument] ([InstrumentNamn], [InstrumentKlass]) VALUES (N'Harpa', N'Stränginstrument')
INSERT [dbo].[Instrument] ([InstrumentNamn], [InstrumentKlass]) VALUES (N'Klarinett', N'Träblås')
INSERT [dbo].[Instrument] ([InstrumentNamn], [InstrumentKlass]) VALUES (N'Kontrabas', N'Stränginstrument')
INSERT [dbo].[Instrument] ([InstrumentNamn], [InstrumentKlass]) VALUES (N'Lyra', N'Slagverk')
INSERT [dbo].[Instrument] ([InstrumentNamn], [InstrumentKlass]) VALUES (N'Oboe', N'Träblås')
INSERT [dbo].[Instrument] ([InstrumentNamn], [InstrumentKlass]) VALUES (N'Piano', N'Slagverk')
INSERT [dbo].[Instrument] ([InstrumentNamn], [InstrumentKlass]) VALUES (N'Pukor', N'Slagverk')
INSERT [dbo].[Instrument] ([InstrumentNamn], [InstrumentKlass]) VALUES (N'Saxofon', N'Träblås')
INSERT [dbo].[Instrument] ([InstrumentNamn], [InstrumentKlass]) VALUES (N'Triangel', N'Slagverk')
INSERT [dbo].[Instrument] ([InstrumentNamn], [InstrumentKlass]) VALUES (N'Trombon', N'Brass')
INSERT [dbo].[Instrument] ([InstrumentNamn], [InstrumentKlass]) VALUES (N'Trumpet', N'Brass')
INSERT [dbo].[Instrument] ([InstrumentNamn], [InstrumentKlass]) VALUES (N'Tuba', N'Brass')
INSERT [dbo].[Instrument] ([InstrumentNamn], [InstrumentKlass]) VALUES (N'Tvärflöjt', N'Träblås')
INSERT [dbo].[Instrument] ([InstrumentNamn], [InstrumentKlass]) VALUES (N'Valthorn', N'Brass')
INSERT [dbo].[Instrument] ([InstrumentNamn], [InstrumentKlass]) VALUES (N'Valvofon', N'Brass')
SET IDENTITY_INSERT [dbo].[Musiker] ON 

INSERT [dbo].[Musiker] ([MusikerId], [PersonId]) VALUES (1, 1)
INSERT [dbo].[Musiker] ([MusikerId], [PersonId]) VALUES (2, 2)
INSERT [dbo].[Musiker] ([MusikerId], [PersonId]) VALUES (3, 3)
INSERT [dbo].[Musiker] ([MusikerId], [PersonId]) VALUES (4, 5)
INSERT [dbo].[Musiker] ([MusikerId], [PersonId]) VALUES (5, 6)
INSERT [dbo].[Musiker] ([MusikerId], [PersonId]) VALUES (6, 8)
INSERT [dbo].[Musiker] ([MusikerId], [PersonId]) VALUES (7, 9)
INSERT [dbo].[Musiker] ([MusikerId], [PersonId]) VALUES (8, 10)
INSERT [dbo].[Musiker] ([MusikerId], [PersonId]) VALUES (9, 11)
INSERT [dbo].[Musiker] ([MusikerId], [PersonId]) VALUES (10, 13)
INSERT [dbo].[Musiker] ([MusikerId], [PersonId]) VALUES (11, 14)
INSERT [dbo].[Musiker] ([MusikerId], [PersonId]) VALUES (12, 15)
INSERT [dbo].[Musiker] ([MusikerId], [PersonId]) VALUES (13, 16)
INSERT [dbo].[Musiker] ([MusikerId], [PersonId]) VALUES (14, 17)
INSERT [dbo].[Musiker] ([MusikerId], [PersonId]) VALUES (15, 18)
SET IDENTITY_INSERT [dbo].[Musiker] OFF
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (1, N'Lyra', 2)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (1, N'Triangel', 4)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (1, N'Valthorn', 5)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (1, N'Valvofon', 3)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (2, N'Harpa', 1)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (2, N'Trumpet', 5)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (2, N'Tuba', 3)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (2, N'Valthorn', 5)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (2, N'Valvofon', 4)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (3, N'Cello', 3)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (3, N'Fiol', 2)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (3, N'Pukor', 2)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (3, N'Saxofon', 5)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (3, N'Tvärflöjt', 4)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (4, N'Fagott', 4)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (4, N'Klarinett', 5)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (4, N'Oboe', 4)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (4, N'Triangel', 2)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (5, N'Harpa', 4)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (5, N'Piano', 5)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (5, N'Tvärflöjt', 2)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (6, N'Batteri', 5)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (6, N'Saxofon', 3)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (6, N'Trombon', 4)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (7, N'Cello', 4)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (7, N'Kontrabas', 3)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (7, N'Oboe', 5)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (8, N'Eufonium', 5)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (8, N'Lyra', 3)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (8, N'Triangel', 4)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (9, N'Fiol', 3)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (9, N'Trumpet', 4)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (9, N'Tvärflöjt', 5)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (10, N'Pukor', 5)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (11, N'Fagott', 4)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (11, N'Klarinett', 5)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (11, N'Oboe', 3)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (12, N'Fagott', 4)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (12, N'Trombon', 5)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (12, N'Tuba', 3)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (13, N'Harpa', 5)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (13, N'Lyra', 4)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (13, N'Valvofon', 2)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (14, N'Cello', 5)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (14, N'Fiol', 3)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (14, N'Kontrabas', 4)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (15, N'Batteri', 5)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (15, N'Lyra', 3)
INSERT [dbo].[MusikerInstrument] ([MusikerId], [Istrumentnamn], [Nivå]) VALUES (15, N'Piano', 4)
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([PersonId], [Förnamn], [Efternamn], [TelefonNummer], [StadsNamn]) VALUES (1, N'Karl-Graham', N'Sharp', 959, N'Köping')
INSERT [dbo].[Person] ([PersonId], [Förnamn], [Efternamn], [TelefonNummer], [StadsNamn]) VALUES (2, N'Erik', N'Bergström', 112, N'Växjö')
INSERT [dbo].[Person] ([PersonId], [Förnamn], [Efternamn], [TelefonNummer], [StadsNamn]) VALUES (3, N'Elin', N'Johansson', 911, N'Arvidsjaur')
INSERT [dbo].[Person] ([PersonId], [Förnamn], [Efternamn], [TelefonNummer], [StadsNamn]) VALUES (4, N'Hanna', N'Andersson', 156, N'Göteborg')
INSERT [dbo].[Person] ([PersonId], [Förnamn], [Efternamn], [TelefonNummer], [StadsNamn]) VALUES (5, N'Oscar', N'Carlsson', 753, N'Strängnäs')
INSERT [dbo].[Person] ([PersonId], [Förnamn], [Efternamn], [TelefonNummer], [StadsNamn]) VALUES (6, N'Rebecka', N'Carlsson', 475, N'Köping')
INSERT [dbo].[Person] ([PersonId], [Förnamn], [Efternamn], [TelefonNummer], [StadsNamn]) VALUES (7, N'Songül', N'Cetinkaya', 555, N'Borås')
INSERT [dbo].[Person] ([PersonId], [Förnamn], [Efternamn], [TelefonNummer], [StadsNamn]) VALUES (8, N'Georg', N'Fälemark', 421, N'Växjö')
INSERT [dbo].[Person] ([PersonId], [Förnamn], [Efternamn], [TelefonNummer], [StadsNamn]) VALUES (9, N'Sara', N'Galvin', 523, N'Stockholm')
INSERT [dbo].[Person] ([PersonId], [Förnamn], [Efternamn], [TelefonNummer], [StadsNamn]) VALUES (10, N'Rikard', N'Isaksson', 632, N'Arvidsjaur')
INSERT [dbo].[Person] ([PersonId], [Förnamn], [Efternamn], [TelefonNummer], [StadsNamn]) VALUES (11, N'Erika', N'Molinder', 441, N'Göteborg')
INSERT [dbo].[Person] ([PersonId], [Förnamn], [Efternamn], [TelefonNummer], [StadsNamn]) VALUES (12, N'Oscar', N'Olsson', 542, N'Göteborg')
INSERT [dbo].[Person] ([PersonId], [Förnamn], [Efternamn], [TelefonNummer], [StadsNamn]) VALUES (13, N'Tobias', N'Persson', 420, N'Arvidsjaur')
INSERT [dbo].[Person] ([PersonId], [Förnamn], [Efternamn], [TelefonNummer], [StadsNamn]) VALUES (14, N'Jonathan', N'Risberg', 863, N'Växjö')
INSERT [dbo].[Person] ([PersonId], [Förnamn], [Efternamn], [TelefonNummer], [StadsNamn]) VALUES (15, N'Magnus', N'Tidqvist', 548, N'Strängnäs')
INSERT [dbo].[Person] ([PersonId], [Förnamn], [Efternamn], [TelefonNummer], [StadsNamn]) VALUES (16, N'Heidi', N'von Jahf', 640, N'Stockholm')
INSERT [dbo].[Person] ([PersonId], [Förnamn], [Efternamn], [TelefonNummer], [StadsNamn]) VALUES (17, N'Olof', N'Wideström', 863, N'Borås')
INSERT [dbo].[Person] ([PersonId], [Förnamn], [Efternamn], [TelefonNummer], [StadsNamn]) VALUES (18, N'Alexander', N'Zetterberg', 777, N'Stockholm')
SET IDENTITY_INSERT [dbo].[Person] OFF
INSERT [dbo].[Stad] ([StadsNamn], [X], [Y]) VALUES (N'Arvidsjaur', 42, 63)
INSERT [dbo].[Stad] ([StadsNamn], [X], [Y]) VALUES (N'Borås', 7, 3)
INSERT [dbo].[Stad] ([StadsNamn], [X], [Y]) VALUES (N'Göteborg', 0, 0)
INSERT [dbo].[Stad] ([StadsNamn], [X], [Y]) VALUES (N'Köping', 63, 22)
INSERT [dbo].[Stad] ([StadsNamn], [X], [Y]) VALUES (N'Munktorp', NULL, NULL)
INSERT [dbo].[Stad] ([StadsNamn], [X], [Y]) VALUES (N'Stockholm', 100, 100)
INSERT [dbo].[Stad] ([StadsNamn], [X], [Y]) VALUES (N'Strängnäs', 5, 5)
INSERT [dbo].[Stad] ([StadsNamn], [X], [Y]) VALUES (N'Växjö', 25, 43)
INSERT [dbo].[Stycken] ([StyckeNamn]) VALUES (N'Crocodile Rock')
INSERT [dbo].[Stycken] ([StyckeNamn]) VALUES (N'Finlandia')
INSERT [dbo].[Stycken] ([StyckeNamn]) VALUES (N'Jurassic Park Theme Song')
INSERT [dbo].[Stycken] ([StyckeNamn]) VALUES (N'My Favourite Things')
INSERT [dbo].[Stycken] ([StyckeNamn]) VALUES (N'Under Blå Gul Fana')
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'Crocodile Rock', N'Cello', 1)
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'Crocodile Rock', N'Klarinett', 1)
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'Crocodile Rock', N'Lyra', 4)
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'Crocodile Rock', N'Triangel', 5)
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'Crocodile Rock', N'Valvofon', 4)
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'Finlandia', N'Eufonium', 5)
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'Finlandia', N'Fagott', 4)
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'Finlandia', N'Harpa', 2)
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'Finlandia', N'Tuba', 4)
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'Finlandia', N'Valthorn', 3)
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'Jurassic Park Theme Song', N'Fiol', 2)
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'Jurassic Park Theme Song', N'Oboe', 3)
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'Jurassic Park Theme Song', N'Pukor', 3)
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'Jurassic Park Theme Song', N'Saxofon', 2)
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'Jurassic Park Theme Song', N'Valthorn', 4)
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'My Favourite Things', N'Batteri', 4)
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'My Favourite Things', N'Kontrabas', 3)
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'My Favourite Things', N'Piano', 4)
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'My Favourite Things', N'Saxofon', 5)
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'My Favourite Things', N'Trombon', 2)
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'Under Blå Gul Fana', N'Batteri', 2)
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'Under Blå Gul Fana', N'Trumpet', 4)
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'Under Blå Gul Fana', N'TvärFlöjt', 3)
INSERT [dbo].[StyckesInstrument] ([StyckeNamn], [InstrumentNamn], [Nivå]) VALUES (N'Under Blå Gul Fana', N'Valthorn', 2)
ALTER TABLE [dbo].[Arrangör]  WITH CHECK ADD  CONSTRAINT [FK_Arrangör_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Arrangör] CHECK CONSTRAINT [FK_Arrangör_Person]
GO
ALTER TABLE [dbo].[Bokningar]  WITH CHECK ADD  CONSTRAINT [FK_Bokningar_Arrangör] FOREIGN KEY([ArrangörId])
REFERENCES [dbo].[Arrangör] ([ArrangörId])
GO
ALTER TABLE [dbo].[Bokningar] CHECK CONSTRAINT [FK_Bokningar_Arrangör]
GO
ALTER TABLE [dbo].[Bokningar]  WITH CHECK ADD  CONSTRAINT [FK_Bokningar_Event] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event] ([EventId])
GO
ALTER TABLE [dbo].[Bokningar] CHECK CONSTRAINT [FK_Bokningar_Event]
GO
ALTER TABLE [dbo].[Bokningar]  WITH CHECK ADD  CONSTRAINT [FK_Bokningar_Instrument] FOREIGN KEY([InstrumentNamn])
REFERENCES [dbo].[Instrument] ([InstrumentNamn])
GO
ALTER TABLE [dbo].[Bokningar] CHECK CONSTRAINT [FK_Bokningar_Instrument]
GO
ALTER TABLE [dbo].[Bokningar]  WITH CHECK ADD  CONSTRAINT [FK_Bokningar_Musiker] FOREIGN KEY([MusikerId])
REFERENCES [dbo].[Musiker] ([MusikerId])
GO
ALTER TABLE [dbo].[Bokningar] CHECK CONSTRAINT [FK_Bokningar_Musiker]
GO
ALTER TABLE [dbo].[Bokningar]  WITH CHECK ADD  CONSTRAINT [FK_Bokningar_Stycken1] FOREIGN KEY([StyckeNamn])
REFERENCES [dbo].[Stycken] ([StyckeNamn])
GO
ALTER TABLE [dbo].[Bokningar] CHECK CONSTRAINT [FK_Bokningar_Stycken1]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Stad] FOREIGN KEY([StadNamn])
REFERENCES [dbo].[Stad] ([StadsNamn])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Stad]
GO
ALTER TABLE [dbo].[Musiker]  WITH CHECK ADD  CONSTRAINT [FK_Musiker_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Musiker] CHECK CONSTRAINT [FK_Musiker_Person]
GO
ALTER TABLE [dbo].[MusikerInstrument]  WITH CHECK ADD  CONSTRAINT [FK_MusikerInstrument_Instrument] FOREIGN KEY([Istrumentnamn])
REFERENCES [dbo].[Instrument] ([InstrumentNamn])
GO
ALTER TABLE [dbo].[MusikerInstrument] CHECK CONSTRAINT [FK_MusikerInstrument_Instrument]
GO
ALTER TABLE [dbo].[MusikerInstrument]  WITH CHECK ADD  CONSTRAINT [FK_MusikerInstrument_Musiker] FOREIGN KEY([MusikerId])
REFERENCES [dbo].[Musiker] ([MusikerId])
GO
ALTER TABLE [dbo].[MusikerInstrument] CHECK CONSTRAINT [FK_MusikerInstrument_Musiker]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Stad] FOREIGN KEY([StadsNamn])
REFERENCES [dbo].[Stad] ([StadsNamn])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Stad]
GO
ALTER TABLE [dbo].[StyckesInstrument]  WITH CHECK ADD  CONSTRAINT [FK_StyckesInstrument_Instrument] FOREIGN KEY([InstrumentNamn])
REFERENCES [dbo].[Instrument] ([InstrumentNamn])
GO
ALTER TABLE [dbo].[StyckesInstrument] CHECK CONSTRAINT [FK_StyckesInstrument_Instrument]
GO
ALTER TABLE [dbo].[StyckesInstrument]  WITH CHECK ADD  CONSTRAINT [FK_StyckesInstrument_Stycken] FOREIGN KEY([StyckeNamn])
REFERENCES [dbo].[Stycken] ([StyckeNamn])
GO
ALTER TABLE [dbo].[StyckesInstrument] CHECK CONSTRAINT [FK_StyckesInstrument_Stycken]
GO
USE [master]
GO
ALTER DATABASE [OrchesterAcademy] SET  READ_WRITE 
GO
