CREATE TABLE [Directors](
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] VARCHAR(50) NOT NULL,
	[Notes] VARCHAR(1000),
)

CREATE TABLE [Genres](
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] VARCHAR(50) NOT NULL,
	[Notes] VARCHAR(1000),
)


CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] VARCHAR(50) NOT NULL,
	[Notes] VARCHAR(1000),
)

CREATE TABLE [Movies](
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] VARCHAR(50) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors](Id) NOT NULL,
	[CopyrightYear] INT NOT NULL,
	[Length] TIME NOT NULL,
	[GenreId] INT FOREIGN KEY REFERENCES [Genres](Id) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL,
	[Rating] DECIMAL (2,1) NOT NULL,
	[Notes] VARCHAR(1000)
)

INSERT INTO [Directors]
	VALUES
	('Stanley Kubrick', NULL),
	('Alfred Hitchcock', NULL),
	('Quentin Tarantino', NULL),
	('Steven Spielberg', NULL),
	('Martin Scorsese', NULL)

INSERT INTO [Genres]
	VALUES
	('Action', NULL),
	('Comedy', NULL),
	('Drama', NULL),
	('Fantasy', NULL),
	('Horror', NULL)

INSERT INTO [Categories]
	VALUES
	('Short', NULL),
	('Long', NULL),
	('Biography', NULL),
	('Documentary', NULL),
	('TV', NULL)

INSERT INTO [Movies]
	VALUES
	('The Shawshank Redemption', 1, 1994, '02:22:00', 2, 3, 9.4, NULL),
	('The Godfather', 2, 1972, '02:55:00', 3, 4, 9.2, NULL),
	('Schindler`s List', 3, 1993, '03:15:00', 4, 5, 9.0, NULL),
	('Pulp Fiction', 4, 1994, '02:34:00', 5, 1, 8.9, NULL),
	('Fight Club', 5, 1999, '02:19:00', 1, 2, 8.8, NULL)