USE [master]
GO

/****** Object:  Table [dbo].[tblContact]    Script Date: 12/13/2018 10:13:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'tblContact') 
BEGIN
	DROP TABLE tblContact
END
CREATE TABLE [dbo].[tblContact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FName] [nvarchar](100) NULL,
	[LName] [nvarchar](100) NULL,
	[EmailId] [nvarchar](100) NULL,
	[Status] [nvarchar](100) NULL
) ON [PRIMARY]

GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertContact') 
BEGIN
	DROP PROCEDURE  InsertContact
END

GO
CREATE PROCEDURE  [dbo].[InsertContact]
@FName nvarchar(100),
@LName nvarchar(100),
@EmailId nvarchar(100),
@Status nvarchar(100)
AS
Begin
insert into tblContact(FName,LName ,EmailId,[Status]) values(@FName,@LName,@EmailId,@Status)


END

GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateContact') 
BEGIN
	DROP PROCEDURE  UpdateContact
END

GO
CREATE PROCEDURE  [dbo].[UpdateContact]
@Id int,
@FName nvarchar(100),
@LName nvarchar(100),
@EmailId nvarchar(100),
@Status nvarchar(100)
AS
Begin
update tblContact set FName=@FName, LName=@LName,EmailId=@EmailId,[Status] =@Status  where Id=@Id


END

GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DeleteContact') 
BEGIN
	DROP PROCEDURE  DeleteContact
END

GO
CREATE PROCEDURE  [dbo].[DeleteContact]
@Id int
AS
Begin
update tblContact set [Status]='Inactive'  where Id=@Id

END

GO


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetContactList') 
BEGIN
	DROP PROCEDURE GetContactList

END

GO
CREATE PROCEDURE  GetContactList

AS
Begin


Select * from tblContact 
where [Status] !='Inactive'
order by FName, LName


END




