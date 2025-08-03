CREATE DATABASE HW1_DB

GO

USE HW1_DB

GO

CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Username] NVARCHAR(50) UNIQUE NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [Age] INT NULL, 
    [Gender] BIT NULL
)

GO

INSERT INTO Users (UserName, Password, FirstName, LastName, Age, Gender)
VALUES ('admin', 'admin', 'firidun', 'hasanli', 20, 1)