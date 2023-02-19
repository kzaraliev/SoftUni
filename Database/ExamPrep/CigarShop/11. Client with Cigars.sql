CREATE FUNCTION udf_ClientWithCigars(@name VARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @numberOfCigars INT =
	(SELECT
			COUNT(*)
		FROM [Clients] AS c
		JOIN [ClientsCigars] AS cc
			ON c.[Id] = cc.ClientId
		GROUP BY c.[FirstName]
		HAVING c.[FirstName] =@name)
	IF(@numberOfCigars IS NULL)
	BEGIN
		SET @numberOfCigars = 0
	END
	RETURN @numberOfCigars
END