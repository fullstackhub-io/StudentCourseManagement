USE [master]
GO
/****** Object:  Database [CourseManagement]    Script Date: 2/4/2021 11:58:40 PM ******/
CREATE DATABASE [CourseManagement]
GO
USE [CourseManagement]
/****** Object:  Table [dbo].[Course]    Script Date: 2/4/2021 11:58:40 PM ******/
CREATE TABLE [dbo].[Course](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [varchar](500) NOT NULL,
	[CrouseShortName] [varchar](20) NULL,
	[CreditHour] [decimal](18, 2) NOT NULL,
	[DateAdded] [datetime] NULL,
	[DateUpdated] [datetime] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [CourseManagement] SET  READ_WRITE 
GO
