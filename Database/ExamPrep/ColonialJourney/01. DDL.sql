CREATE DATABASE [ColonialJourney]
USE [ColonialJourney]

CREATE TABLE [Planets](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE [Spaceports](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[PlanetId] INT FOREIGN KEY REFERENCES [Planets]([Id]) NOT NULL
)

CREATE TABLE [Spaceships](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Manufacturer] VARCHAR(30) NOT NULL,
	[LightSpeedRate] INT DEFAULT 0
)

CREATE TABLE [Colonists](
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(20) NOT NULL,
	[LastName] VARCHAR(20) NOT NULL,
	[Ucn] VARCHAR(10) UNIQUE NOT NULL,
	[BirthDate] DATE NOT NULL
)

CREATE TABLE [Journeys](
	[Id] INT PRIMARY KEY IDENTITY,
	[JourneyStart] DATETIME NOT NULL,
	[JourneyEnd] DATETIME NOT NULL,
	[Purpose] VARCHAR(11) NOT NULL,
	CHECK([Purpose] = 'Medical' OR [Purpose] = 'Technical' OR [Purpose] = 'Educational' OR [Purpose] = 'Military'),
	[DestinationSpaceportId] INT FOREIGN KEY REFERENCES [Spaceports]([Id]) NOT NULL,
	[SpaceshipId] INT FOREIGN KEY REFERENCES [Spaceships]([Id]) NOT NULL
)

CREATE TABLE [TravelCards](
	[Id] INT PRIMARY KEY IDENTITY,
	[CardNumber] CHAR(10) UNIQUE NOT NULL,
	[JobDuringJourney] VARCHAR(8),
	CHECK([JobDuringJourney] = 'Pilot' OR [JobDuringJourney] = 'Engineer' OR [JobDuringJourney] = 'Trooper' OR [JobDuringJourney] = 'Cleaner' OR [JobDuringJourney] = 'Cook'),
	[ColonistId] INT FOREIGN KEY REFERENCES [Colonists]([Id]) NOT NULL,
	[JourneyId] INT FOREIGN KEY REFERENCES [Journeys]([Id]) NOT NULL
)
