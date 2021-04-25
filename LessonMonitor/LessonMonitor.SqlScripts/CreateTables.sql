/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
			   SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

USE LessonMonitorDb

--DROP TABLE Members

CREATE TABLE [Members] (
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(50),
	[CreatedDate] DATETIME2 DEFAULT GETDATE()
)

CREATE TABLE [MemberAccounts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
	[MemberId] INT NOT NULL,
	[UserName] NVARCHAR(50) NOT NULL,
	[Link] NVARCHAR(200) NULL, 
    [CreatedDate] DATETIME2 DEFAULT GETDATE(),
	CONSTRAINT [FK_MemberAccounts_Members] FOREIGN KEY (MemberId) REFERENCES Memebers(Id)
)


CREATE TABLE [Lessons]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [Title] NVARCHAR(200) NOT NULL, 
    [Description] NVARCHAR(1000) NULL, 
    [StartDate] DATETIME2 NULL, 
    [CreatedDate] DATETIME2 DEFAULT GETDATE()
)


CREATE TABLE [VisitedLessons]
(
    [MemberId] INT NOT NULL,
	[LessonId] INT NOT NULL,
	[CreatedDate] DATETIME2 DEFAULT GETDATE(),
	CONSTRAINT [PK_MemberId_LessonId] PRIMARY KEY (MemberId, LessonId),
	CONSTRAINT [FK_VisitedLessons_Members] FOREIGN KEY (MemberId) REFERENCES Members(Id),
	CONSTRAINT [FK_VisitedLessons_Lessons] FOREIGN KEY (LessonId) REFERENCES Lessons(Id)
)

