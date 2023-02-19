CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @countOfCommits INT =
	(
		SELECT
			COUNT(*)
		FROM [Users] AS u
		JOIN [Commits] AS c
			ON u.[Id] = c.[ContributorId]
		GROUP BY u.[Username]
		HAVING u.[Username] =@username)
	IF(@countOfCommits IS NULL)
	BEGIN 
		SET @countOfCommits = 0
	END
	RETURN @countOfCommits
END