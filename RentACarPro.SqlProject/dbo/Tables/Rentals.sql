CREATE TABLE [dbo].[Rentals]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CarId] INT NOT NULL,
    [CustomerId] INT NOT NULL,
    [RentDate] DATETIME NOT NULL, 
    [ReturnDate] DATETIME NULL, 
    CONSTRAINT [FK_Rentals_Cars] FOREIGN KEY (CarId) REFERENCES Cars(Id), 
    CONSTRAINT [FK_Rentals_Customers] FOREIGN KEY (CustomerId) REFERENCES Customers(Id)
)
