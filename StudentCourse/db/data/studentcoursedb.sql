USE [master]
GO
CREATE DATABASE [StudentCourses]
GO
USE [StudentCourses]
CREATE TABLE [dbo].[StudentCourses](
	[StudentCourseID] [int] IDENTITY(1,1) NOT NULL,
	[Subjects] [varchar](5000) NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[EmailAddress] [varchar](100) NOT NULL,
	[PhoneNumber] [varchar](20) NOT NULL,
	[Address] [varchar](500) NOT NULL,
	[SessionStartDate] [datetime] NOT NULL,
	[SessionEndDate] [datetime] NOT NULL,
	[DateAdded] [datetime] NOT NULL,
	[DateUpdated] [datetime] NULL,
 CONSTRAINT [PK_StudentCourses] PRIMARY KEY CLUSTERED 
(
	[StudentCourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [StudentCourses] SET  READ_WRITE 
GO




