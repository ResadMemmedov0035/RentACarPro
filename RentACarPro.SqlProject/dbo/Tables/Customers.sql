﻿CREATE TABLE [dbo].[Customers]
(
	[Id] INT NOT NULl PRIMARY KEY IDENTITY,
	[UserId] INT NOT NULL, 
	[CompanyName] NVARCHAR(50) NOT NULL,
    CONSTRAINT [FK_Customers_Users] FOREIGN KEY (UserId) REFERENCES Users(Id)
)
