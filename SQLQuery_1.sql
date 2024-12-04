CREATE DATABASE RoadReady;
GO

USE RoadReady;
GO


CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    PhoneNumber NVARCHAR(20),
    Role NVARCHAR(20) CHECK (Role IN ('Customer', 'Admin')) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE Cars (
    CarId INT PRIMARY KEY IDENTITY(1,1),
    Make NVARCHAR(50) NOT NULL,
    Model NVARCHAR(50) NOT NULL,
    Year INT NOT NULL,
    Color NVARCHAR(30),
    PricePerDay DECIMAL(10, 2) NOT NULL,
    AvailabilityStatus NVARCHAR(20) CHECK (AvailabilityStatus IN ('Available', 'Rented', 'UnderMaintenance')) NOT NULL,
    Description NVARCHAR(255),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);
GO



CREATE TABLE Reservations (
    ReservationId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT FOREIGN KEY REFERENCES Users(UserId),
    CarId INT FOREIGN KEY REFERENCES Cars(CarId),
    PickupDate DATETIME NOT NULL,
    DropoffDate DATETIME NOT NULL,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    Status NVARCHAR(20) CHECK (Status IN ('Pending', 'Confirmed', 'Cancelled', 'Completed')) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);
GO


CREATE TABLE Payments (
    PaymentId INT PRIMARY KEY IDENTITY(1,1),
    ReservationId INT FOREIGN KEY REFERENCES Reservations(ReservationId),
    PaymentDate DATETIME DEFAULT GETDATE(),
    Amount DECIMAL(10, 2) NOT NULL,
    PaymentMethod NVARCHAR(50) CHECK (PaymentMethod IN ('Credit Card', 'PayPal', 'Bank Transfer')),
    Status NVARCHAR(20) CHECK (Status IN ('Pending', 'Completed', 'Failed')) NOT NULL
);
GO

CREATE TABLE Reviews (
    ReviewId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT FOREIGN KEY REFERENCES Users(UserId),
    CarId INT FOREIGN KEY REFERENCES Cars(CarId),
    Rating INT CHECK (Rating BETWEEN 1 AND 5),
    Comments NVARCHAR(255),
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO




-- Inserting sample values into the Users table
INSERT INTO Users (FirstName, LastName, Email, PasswordHash, PhoneNumber, Role)
VALUES 
('Naman', 'Kumar', 'naman.kumar@gmail.com', 'Test@12', '9876543210', 'Customer'),
('Vansh', 'Sharma', 'Vansh.sharma@example.com', 'Test@12', '8765432109', 'Customer'),
('Rahul', 'Puri', 'rahul.puri.com', 'Test@12', '7654321098', 'Admin');
GO

-- Inserting sample values into the Cars table
INSERT INTO Cars (Make, Model, Year, Color, PricePerDay, AvailabilityStatus, Description)
VALUES 
('Maruti Suzuki', 'Swift', 2022, 'White', 1500.00, 'Available', 'Fuel efficient compact car'),
('Hyundai', 'Creta', 2023, 'Black', 2500.00, 'Available', 'Spacious SUV with modern features'),
('Tata', 'Nexon', 2021, 'Blue', 2000.00, 'Available', 'Compact SUV with high safety rating');
GO

-- Inserting sample values into the Reservations table
INSERT INTO Reservations (UserId, CarId, PickupDate, DropoffDate, TotalAmount, Status)
VALUES 
(1, 1, '2024-11-10 09:00:00', '2024-11-12 18:00:00', 3000.00, 'Confirmed'),
(2, 2, '2024-12-01 08:00:00', '2024-12-05 20:00:00', 12500.00, 'Pending');
GO



-- Inserting sample values into the Payments table
INSERT INTO Payments (ReservationId, PaymentDate, Amount, PaymentMethod, Status)
VALUES 
(1, '2024-11-09 10:00:00', 3000.00, 'Credit Card', 'Completed'),
(2, '2024-11-29 15:00:00', 12500.00, 'PayPal', 'Pending');
GO

-- Inserting sample values into the Reviews table
INSERT INTO Reviews (UserId, CarId, Rating, Comments, CreatedAt)
VALUES 
(1, 1, 4, 'Good car, smooth ride!', GETDATE()),
(2, 2, 5, 'Excellent SUV with great comfort.', GETDATE());
GO


