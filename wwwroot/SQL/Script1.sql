--Tovar -----

USE [TruckerDb]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 8/10/2021 10:58:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Load](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	Height decimal(5,2) null,
	Width decimal(5,2) null,
	Weight decimal(5,2) null,
	Length decimal(5,2) null

 CONSTRAINT [PK_Load] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



--Tura 

USE [TruckerDb]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 8/10/2021 10:58:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tour](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[From] [nvarchar](100) NOT NULL,
	[To] [nvarchar](100) NOT NULL,
	[Price] decimal(20,2) NOT NULL,
	[Distance] decimal(20,2) NULL,
	[DateCreated] datetime NULL,
	DriverProfileId int not null,
	LoadId int not null,
	TypeTour int not null

 CONSTRAINT [PK_Tour] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[Tour]  WITH CHECK ADD  CONSTRAINT [FK_Tour_DriverProfile] FOREIGN KEY([DriverProfileId])
REFERENCES [dbo].[DriverProfile] ([Id])
GO

ALTER TABLE [dbo].[Tour] CHECK CONSTRAINT [FK_Tour_DriverProfile]
GO

ALTER TABLE [dbo].[Tour]  WITH CHECK ADD  CONSTRAINT [FK_Tour_Load] FOREIGN KEY([LoadId])
REFERENCES [dbo].[Load] ([Id])
GO

ALTER TABLE [dbo].[Tour] CHECK CONSTRAINT [FK_Tour_Load]
GO


--Review

USE [TruckerDb]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 8/10/2021 10:58:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Review](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	Comment nvarchar(500) null,
	Rate decimal (2,1) null,
	[DateCreated] datetime NULL,
	DriverProfileId int not null,
	UserId int not null,	
	TourId int not null
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_DriverProfile] FOREIGN KEY([DriverProfileId])
REFERENCES [dbo].[DriverProfile] ([Id])
GO

ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_DriverProfile]
GO

ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_User]
GO

ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_Tour] FOREIGN KEY([TourId])
REFERENCES [dbo].[Tour] ([Id])
GO

ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_Tour]
GO


--ALTER TABLE 
ALTER TABLE Tour
ALTER COLUMN DriverProfileId int NULL;


ALTER TABLE Tour
ALTER COLUMN LoadId int NULL;