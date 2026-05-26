CREATE TABLE GuestAccounts (
    AccountID INT PRIMARY KEY,
    GuestID INT FOREIGN KEY REFERENCES Guests(GuestId),
    BankAccountNumber INT NOT NULL,
    Balance DECIMAL(10, 2) NOT NULL
);