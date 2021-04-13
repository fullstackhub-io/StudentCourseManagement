USE [master]
GO
CREATE DATABASE [UserManagement]
GO
USE [UserManagement]
CREATE TABLE [dbo].[User](
	[UserID] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[DOB] [datetime] NOT NULL,
	[Gender] [char](1) NOT NULL,
	[EmailAddress] [varchar](100) NOT NULL,
	[PhoneNumber] [varchar](20) NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[Zip] [numeric](10, 0) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[DateAdded] [datetime] NOT NULL,
	[DateUpdated] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_DateUpdated]  DEFAULT (NULL) FOR [DateUpdated]
GO
USE [master]
GO
ALTER DATABASE [UserManagement] SET  READ_WRITE 
GO
