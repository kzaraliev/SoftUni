CREATE PROC usp_SearchByAirportName (@airportName VARCHAR(70))
AS
BEGIN
	SELECT
		a.[AirportName],
		p.[FullName],
		CASE
			WHEN fd.[TicketPrice] <= 400 THEN 'Low'
			WHEN fd.[TicketPrice] BETWEEN 401 AND 1500 THEN 'Medium'
			WHEN fd.[TicketPrice] > 1500 THEN 'High'
		END AS [LevelOfTickerPrice],
		aircr.[Manufacturer],
		aircr.[Condition],
		airt.[TypeName]
	FROM [Airports] AS a
	JOIN [FlightDestinations] AS fd
		ON a.[Id] = fd.[AirportId]
	JOIN [Passengers] AS p
		ON fd.[PassengerId] = p.[Id]
	JOIN [Aircraft] AS aircr
		ON fd.[AircraftId] = aircr.[Id]
	JOIN [AircraftTypes] AS airt
		ON airt.[Id] = aircr.[TypeId]
	WHERE a.[AirportName] = @airportName
	ORDER BY aircr.[Manufacturer] ASC,
			 p.[FullName] ASC
END