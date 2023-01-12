CREATE DATABASE [SoftUni]

USE [SoftUni]


CREATE TABLE [Towns]
(
	[Id] INT IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Addresses]
(
	[Id] INT IDENTITY NOT NULL,
	[AddressText] VARCHAR(50) NOT NULL,
	[TownId] INT NOT NULL
)

CREATE TABLE [Departments]
(
	[Id] INT IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)


CREATE TABLE [Employees]
(
	[Id] INT IDENTITY NOT NULL,
	[FirstName] VARCHAR(50) NOT NULL,
	[MiddleName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[JobTitle] VARCHAR(50) NOT NULL,
	[DepartmentId] INT NOT NULL,
	[HireDate] DATE NOT NULL,
	[Salary] DECIMAL(6, 2) NOT NULL,
	[AddressId] INT
)

ALTER TABLE [Towns]
	ADD CONSTRAINT PK_Towns 
	PRIMARY KEY (Id)

ALTER TABLE [Addresses]
	ADD CONSTRAINT PK_Addresses 
	PRIMARY KEY (Id)

ALTER TABLE [Addresses]
	ADD CONSTRAINT FK_Addresses_TownId 
	FOREIGN KEY (TownId) REFERENCES [Towns](Id)

ALTER TABLE [Departments]
	ADD CONSTRAINT PK_Departments 
	PRIMARY KEY (Id)

ALTER TABLE [Employees]
	ADD CONSTRAINT PK_Employees 
	PRIMARY KEY (Id)

ALTER TABLE [Employees]
	ADD CONSTRAINT FK_Employees_DepartmentId 
	FOREIGN KEY (DepartmentId) REFERENCES [Departments](Id)

ALTER TABLE [Employees]
	ADD CONSTRAINT FK_Employees_AddressId 
	FOREIGN KEY (AddressId) REFERENCES [Addresses](Id)