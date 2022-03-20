﻿CREATE TABLE [dbo].[Cars]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[BrandId] INT NOT NULL,
	[ColorId] INT NOT NULL,
	[ModelId] INT NOT NULL,
	[ModelYear] SMALLINT NOT NULL,
	[DailyPrice] DECIMAL(9, 2) NOT NULL, -- max: 9,999,999.99
	[Description] NVARCHAR(300) NOT NULL, 
    CONSTRAINT [FK_Cars_Brands] FOREIGN KEY (BrandId) REFERENCES Brands(Id),
    CONSTRAINT [FK_Cars_Colors] FOREIGN KEY (ColorId) REFERENCES Colors(Id),
    CONSTRAINT [FK_Cars_Models] FOREIGN KEY (ModelId) REFERENCES Models(Id)
)
