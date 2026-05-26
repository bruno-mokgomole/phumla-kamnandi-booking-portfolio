CREATE TABLE Guests (
    GuestId INT PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Address_ VARCHAR(200) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Phone VARCHAR(20),
    DOB DATE NOT NULL
);
