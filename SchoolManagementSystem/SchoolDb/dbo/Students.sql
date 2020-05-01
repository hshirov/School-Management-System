﻿CREATE TABLE [dbo].[Students]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Email] VARCHAR(50) NOT NULL,
	[PasswordHash] VARCHAR(64) NOT NULL,
	[Mobile] VARCHAR(10) NOT NULL,
	[ClassNumber] INT NOT NULL,
	[ClassLetter] VARCHAR(2) NOT NULL
)
