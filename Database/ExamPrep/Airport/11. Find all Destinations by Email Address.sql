CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT
AS
	BEGIN
	DECLARE @numberOfFlights INT =
	(
		SELECT
			COUNT(*)
		FROM [FlightDestinations] AS fd
		JOIN [Passengers] AS p
			ON fd.[PassengerId] = p.[Id]
		WHERE p.[Email] = @email
		GROUP BY p.[Id])
		IF(@numberOfFlights IS NULL)
			BEGIN
				SET @numberOfFlights = 0
			END
		RETURN @numberOfFlights
	END