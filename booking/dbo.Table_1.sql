CREATE TABLE [dbo].[Booking]
(
	[Booking_Reference] INT NOT NULL PRIMARY KEY, 
    [GuestID] VARCHAR(10) NOT NULL, 
    [ChekcIn] DATETIME NOT NULL, 
    [checkOut] DATETIME NOT NULL, 
    [Adults] INT NOT NULL, 
    [Children] INT NULL, 
    [Total_cost] DECIMAL(10, 2) NOT NULL, 
    [Created_At] DATETIME NULL, 
    [Updated_At] DATETIME NULL
)
