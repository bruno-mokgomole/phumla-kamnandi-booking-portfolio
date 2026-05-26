
SET NOCOUNT ON;
GO

-- Drop tables if exist
IF OBJECT_ID('dbo.Bookings', 'U') IS NOT NULL DROP TABLE dbo.Bookings;
IF OBJECT_ID('dbo.Seasons', 'U') IS NOT NULL DROP TABLE dbo.Seasons;
IF OBJECT_ID('dbo.Rooms', 'U') IS NOT NULL DROP TABLE dbo.Rooms;
IF OBJECT_ID('dbo.Guests', 'U') IS NOT NULL DROP TABLE dbo.Guests;
GO

-- Rooms table
CREATE TABLE dbo.Rooms (
    RoomId NVARCHAR(10) PRIMARY KEY,
    Capacity INT NOT NULL,
    BasePrice DECIMAL(10,2) NULL -- base price 
);

-- Guests table
CREATE TABLE dbo.Guests (
    GuestID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    DateOfBirth datetime NOT NULL,
    Address NVARCHAR(300) NULL,
);

-- Seasons table (Low / Mid / High)
CREATE TABLE dbo.Seasons (
    SeasonId INT IDENTITY(1,1) PRIMARY KEY,
    SeasonName NVARCHAR(50) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    NightlyRate DECIMAL(10,2) NOT NULL
);

-- Bookings table (Auumption: 1 booking = 1 room)
CREATE TABLE dbo.Bookings (
    BookingId NVARCHAR(50) PRIMARY KEY,
    RoomId NVARCHAR(10) NOT NULL,
    GuestId INT NOT NULL,
    CheckInDate DATE NOT NULL,
    CheckOutDate DATE NOT NULL,
    Status NVARCHAR(20) NOT NULL, -- Pending, Confirmed, Cancelled
    DepositPaid BIT NOT NULL DEFAULT 0,
    DepositAmount DECIMAL(10,2) NULL,
    SpecialRequests NVARCHAR(500) NULL,
    CONSTRAINT FK_Booking_Room FOREIGN KEY (RoomId) REFERENCES dbo.Rooms(RoomId),
    CONSTRAINT FK_Booking_Guest FOREIGN KEY (GuestId) REFERENCES dbo.Guests(GuestId)
);

GO

-------------------------
-- Rooms Numbers (101 - 105)
-------------------------
INSERT INTO dbo.Rooms (RoomId, Capacity, BasePrice) VALUES
('101', 4, NULL),
('102', 4, NULL),
('103', 4, NULL),
('104', 4, NULL),
('105', 4, NULL);

-------------------------
-- rates for 2025, we'll confirm with tutor
-- Low: Dec 1-7 (R550)
-- Mid: Dec 8-15 (R750)
-- High: Dec16-31 (R995)
-------------------------
INSERT INTO dbo.Seasons (SeasonName, StartDate, EndDate, NightlyRate) VALUES
('Low',  '2025-12-01', '2025-12-07', 550.00),
('Mid',  '2025-12-08', '2025-12-15', 750.00),
('High', '2025-12-16', '2025-12-31', 995.00);

-------------------------
-- Guests 
-------------------------
INSERT INTO dbo.Guests (FirstName, LastName, Address, Email, Phone, DOB) VALUES
('John', 'Smith', '7 Main Rd, Rondebosch, 7700', 'john.smith@example.com', '021-555-0101', '1985-02-14'),
('Nkosinathi', 'Mthembu', '14 Lungelo Drive, Mtimkhulu, Durban, 4001', 'nkosi@example.com', '031-555-0202', '1990-05-20'),
('Alice', 'Brown', '12 Park Street, Gardens, 8001', 'alice.brown@example.com', '021-555-0303', '1992-10-01'),
('David', 'Adams', '5 Church Lane, Claremont, 7708', 'd.adams@example.com', '021-555-0404', '1988-06-06'),
('Lerato', 'Kgogo', '22 Vine St, Salt River, 7925', 'lerato@example.com', '021-555-0505', '1995-11-11'),
('Priya', 'Naidoo', '45 Beach Rd, Muizenberg, 7945', 'priya@example.com', '021-555-0606', '1993-03-03'),
('Owen', 'White', '88 Main Rd, Sea Point, 8005', 'owen@example.com', '021-555-0707', '1980-07-07'),
('Maria', 'Gonzalez', '3 Oak Ave, Newlands, 7700', 'maria@example.com', '021-555-0808', '1994-12-12'),
('Sipho', 'Dlamini', '9 River Rd, Kloof, 3610', 'sipho@example.com', '031-555-0909', '1991-09-09'),
('Fatima', 'Patel', '16 Hill St, Woodstock, 7925', 'fatima@example.com', '021-555-1010', '1996-04-04');

-------------------------
-- We'll create 11 bookings:
-- - Dec 24: only 2 bookings for that night 
-- - Dec 25-26: fully booked
-- - Dec 27-28: four rooms booked 
-- BookingId are strings
-------------------------

-- 1) Two bookings occupying night 24 only
INSERT INTO dbo.Bookings (BookingId, RoomId, GuestId, CheckInDate, CheckOutDate, Status, DepositPaid, DepositAmount, SpecialRequests)
VALUES
('BKG1001', '101', 6, '2025-12-24', '2025-12-25', 'Confirmed', 1, 0.00, 'Arriving late'),
('BKG1002', '102', 7, '2025-12-24', '2025-12-25', 'Confirmed', 1, 0.00, 'N/A');

-- 2) Fully booked on 25 & 26 => 5 bookings with checkin 25 checkout 27
INSERT INTO dbo.Bookings (BookingId, RoomId, GuestId, CheckInDate, CheckOutDate, Status, DepositPaid, DepositAmount, SpecialRequests)
VALUES
('BKG2001', '101', 1, '2025-12-25', '2025-12-27', 'Confirmed', 1, 0.00, 'John Smith booking on 25th'),
('BKG2002', '102', 3, '2025-12-25', '2025-12-27', 'Confirmed', 1, 0.00, 'Family stay'),
('BKG2003', '103', 4, '2025-12-25', '2025-12-27', 'Confirmed', 1, 0.00, 'Holiday'),
('BKG2004', '104', 5, '2025-12-25', '2025-12-27', 'Confirmed', 1, 0.00, 'Business'),
('BKG2005', '105', 8, '2025-12-25', '2025-12-27', 'Confirmed', 1, 0.00, 'Friends');

-- 3) Bookings occupying nights 27 & 28 (checkin 27 checkout 29) for 4 rooms
INSERT INTO dbo.Bookings (BookingId, RoomId, GuestId, CheckInDate, CheckOutDate, Status, DepositPaid, DepositAmount, SpecialRequests)
VALUES
('BKG3001', '101', 9, '2025-12-27', '2025-12-29', 'Confirmed', 1, 0.00, 'Conference'),
('BKG3002', '102', 10, '2025-12-27', '2025-12-29', 'Confirmed', 1, 0.00, 'Overnight'),
('BKG3003', '103', 4, '2025-12-27', '2025-12-29', 'Confirmed', 1, 0.00, 'Returning guests'),
('BKG3004', '104', 3, '2025-12-27', '2025-12-29', 'Confirmed', 1, 0.00, 'Leisure');

GO

