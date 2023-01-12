CREATE DATABASE [CarRental]

USE [CarRental]

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] VARCHAR(50) NOT NULL,
	[DailyRate] DECIMAL (6,2) NOT NULL,
	[WeeklyRate] DECIMAL (6,2) NOT NULL,
	[MonthlyRate] DECIMAL (6,2) NOT NULL,
	[WeekendRate] DECIMAL (6,2) NOT NULL
)

CREATE TABLE [Cars](
	[Id] INT PRIMARY KEY IDENTITY,
	[PlateNumber] VARCHAR(50) NOT NULL,
	[Manufacturer] VARCHAR(50) NOT NULL,
	[Model] VARCHAR(50) NOT NULL,
	[CarYear] INT NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL,
	[Doors] INT NOT NULL,
	[Picture] IMAGE,
	[Condition] NVARCHAR(1000) NOT NULL,
	[Available] BIT NOT NULL
)

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Title] VARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(1000)
)

CREATE TABLE [Customers](
	[Id] INT PRIMARY KEY IDENTITY,
	[DriverLicenceNumber] INT NOT NULL,
	[FullName] VARCHAR(50) NOT NULL,
	[Address] VARCHAR(200) NOT NULL,
	[City] VARCHAR(50) NOT NULL,
	[ZIPCode] INT NOT NULL,
	[Notes] NVARCHAR(1000)
)

CREATE TABLE [RentalOrders](
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL,
	[CustomerId] INT FOREIGN KEY REFERENCES [Customers](Id) NOT NULL,
	[CarId] INT FOREIGN KEY REFERENCES [Cars](Id) NOT NULL,
	[TankLevel] INT NOT NULL,
	[KilometrageStart] INT NOT NULL,
	[KilometrageEnd] INT NOT NULL,
	[TotalKilometrage] INT NOT NULL,
	[StartDate] DATE NOT NULL,
	[EndDate] DATE NOT NULL,
	[TotalDays] INT NOT NULL,
	[RateApplied] DECIMAL(6,2) NOT NULL,
	[TaxRate] DECIMAL(4,2) NOT NULL,
	[OrderStatus] VARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(1000)
)

INSERT INTO [Categories]
	VALUES
	('urban', 10.00, 50.00, 150.00, 20.00),
	('Off-road', 50.00, 250.00, 750.00, 100.00),
	('Sport', 100.00, 500.00, 1500.00, 200.00)

INSERT INTO [Cars]
	VAlUES
	('CB 6778 MN', 'Ford', 'Model A', 1994, 1, 4, NULL, 'Good', 1),
	('PV 3416 KA', 'Tesla', 'Model B', 2021, 2, 4, NULL, 'Great', 1),
	('PK 7349 OP', 'Capsule Corp', 'Model C', 2054, 3, 10, NULL, 'Top', 0)

INSERT INTO [Employees]
	VALUES
	('Petur', 'Petrov', 'Edward Norton`s Alter Ego', NULL),
	('Ivan', 'Ivanov', 'some gal', NULL),
	('Gosho', 'Goshev', 'BIB BIB', NULL)

INSERT INTO [Customers]
	VALUES
	(421764, 'G-n Filev', 'ul. Popa', 'Bojurishte', 1400, NULL),
	(983548, 'Nadeto Georgieva', 'kv. Lulyn', 'Sofia', 1000, NULL),
	(067142, 'Muhi Sotirov', 'Zona B-18', 'Sofia', 1000, NULL)

INSERT INTO [RentalOrders]
	VALUES
	(1, 1, 1, 10, 1000, 3000, 4000, '1994-10-01', '1994-11-01', 30, 100.00, 14.00, 'Pending', NULL),
	(2, 2, 2, 50, 7000, 31000, 41000, '2006-05-10', '2006-05-19', 9, 100.00, 14.00, 'Deliverd', NULL),
	(3, 3, 3, 70, 8000, 7000, 9000, '2020-01-01', '2020-01-06', 5, 100.00, 14.00, 'Pending', NULL)