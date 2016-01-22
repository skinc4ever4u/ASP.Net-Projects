/*drop database CA_DATA */

/*
USE [CA_DATA]
select * from users
select * from UserActivation
select * from company
select * from file_data
select * from file_uploaded
select * from file_data fd join file_uploaded fu on fd.FileId=fu.FileId order by fd.FileId desc
select top 2 fu.FileId, fd.Username, fd.Company_Name, fd.Module, fd.CreatedDate, fu.File_Description, fu.File_Type, fu.File_Path ,fu.F_Name from file_data fd join file_uploaded fu on fd.FileId=fu.FileId order by fd.FileId desc

*/



USE [master]
GO

CREATE DATABASE [CA_DATA]

GO

USE [CA_DATA]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[Roles] [nvarchar] (10) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [CA_DATA]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Insert_User]
	@Username NVARCHAR(20),
	@Password NVARCHAR(20),
	@Roles nvarchar(10),
	@Email NVARCHAR(30)
AS
BEGIN
	SET NOCOUNT ON;
	IF EXISTS(SELECT UserId FROM Users WHERE Username = @Username)
	BEGIN
		SELECT -1 -- Username exists.
	END
	ELSE IF EXISTS(SELECT UserId FROM Users WHERE Email = @Email)
	BEGIN
		SELECT -2 -- Email exists.
	END
	ELSE
	BEGIN
		INSERT INTO [Users]
			   ([Username]
			   ,[Password]
			   ,[Roles]
			   ,[Email]
			   ,[CreatedDate])
		VALUES
			   (@Username
			   ,@Password
			   ,@Roles
			   ,@Email
			   ,GETDATE())
		
		SELECT SCOPE_IDENTITY() -- UserId			   
     END
END

GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserActivation](
	[UserId] [int] NOT NULL,
	[ActivationCode] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UserActivation] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE  PROCEDURE [dbo].[Validate_User]
	@Username NVARCHAR(20),
	@Password NVARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @UserId INT, @LastLoginDate DATETIME
	
	SELECT @UserId = UserId, @LastLoginDate = LastLoginDate
	FROM Users WHERE Username = @Username AND [Password] = @Password
	
	IF @UserId IS NOT NULL
	BEGIN
		IF NOT EXISTS(SELECT UserId FROM UserActivation WHERE UserId = @UserId)
		BEGIN
			UPDATE Users
			SET LastLoginDate =  GETDATE()
			WHERE UserId = @UserId
			SELECT Roles from Users where UserId=@UserId-- User Valid
		END
		ELSE
		BEGIN
			SELECT '-2' -- User not activated.
		END
	END
	ELSE
	BEGIN
		SELECT '-1' -- User invalid.
	END
END



GO
INSERT INTO Users
SELECT 'Sunil', '12345','Admin', 'mudassar@aspsnippets.com', GETDATE(), NULL
UNION ALL
SELECT 'Ram', '12345','User', 'ram@aspsnippets.com', GETDATE(), NULL
GO

INSERT INTO Users values('Amit', '12345','User', 'sunil@aspsnippets.com', GETDATE() ,NULL)
INSERT INTO Users values('Dilip', '12345','Head', 'sunil@aspsnippets.com', GETDATE() ,NULL)
GO
INSERT INTO UserActivation
SELECT 2, NEWID()



/*file uploading table and task*/

go
create table Company
(
Company_id int IDENTITY(1,1) constraint PK_Company primary key,
Name nvarchar(100) not null,
Addres nvarchar(500) not null,
Com_Description nvarchar(500) not null
)

go
CREATE TABLE file_data(
	FileId int IDENTITY(1,1) constraint PK_File primary key,
	UserId int foreign key references Users(UserId) not null,
	Username nvarchar(20) NOT NULL,
	Company_id int foreign key references Company(Company_id) not null,
	Company_Name nvarchar(100)Not null,
	Module nvarchar (5)not null constraint chk check (Module in('A','B','C','D','E')),
	CreatedDate date NOT NULL,
	file_year nvarchar(4)not null
)
go
create table file_uploaded(
	FileId int foreign key references file_data(FileId) not null,
	File_Description nvarchar(100),
	File_Type nvarchar(30) Not null,
	File_Path nvarchar(100) not null,
	F_Name nvarchar(20) not null
	)
	
	
	
	go
CREATE PROCEDURE [dbo].[Insert_File_Data]
	@UserId int,
	@Username NVARCHAR(20),
	@Company_id int,
	@Company_Name nvarchar(100),
	@Module nvarchar (5),
	@CreatedDate date,
	@file_year nvarchar(4)
AS
BEGIN
set nocount on;
/* When SET NOCOUNT is ON, the count is not returned. When SET NOCOUNT is OFF, the count is returned. */
		INSERT INTO [file_data]
			   ([UserId]
			   ,[Username]
			   ,[Company_id]
			   ,[Company_Name]
			   ,[Module]
			   ,[CreatedDate]
			   ,[file_year])
		VALUES
			   (@UserId
			   ,@Username
			   ,@Company_id
			   ,@Company_Name
			   ,@Module
			   ,@CreatedDate
			   ,@file_year)
		
		SELECT SCOPE_IDENTITY() -- UserId			   
END

go
CREATE PROCEDURE [dbo].[Insert_File_Uploaded]
	@FileId int,
	@File_Description nvarchar(100),
	@File_Type nvarchar(30),
	@File_Path nvarchar(100),
	@F_Name nvarchar(20)
AS
BEGIN
		INSERT INTO [file_Uploaded]
			   ([FileId]
			   ,[File_Description]
			   ,[File_Type]
			   ,[File_Path]
			   ,[F_Name])
		VALUES
			   (@FileId
			   ,@File_Description
			   ,@File_Type
			   ,@File_Path
			   ,@F_Name)
END	