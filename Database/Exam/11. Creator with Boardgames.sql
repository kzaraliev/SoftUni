CREATE FUNCTION udf_CreatorWithBoardgames(@name VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @totalGames INT =
	(SELECT
		COUNT(*)
	FROM [Boardgames] AS b
	JOIN [CreatorsBoardgames] AS cb
		ON b.[Id] = cb.[CreatorId]
	JOIN [Creators] AS c
		ON cb.[CreatorId] = c.[Id]
	WHERE c.[FirstName] = @name)
	IF(@totalGames IS NULL)
	BEGIN
		SET @totalGames = 0
	END
	RETURN @totalGames
END