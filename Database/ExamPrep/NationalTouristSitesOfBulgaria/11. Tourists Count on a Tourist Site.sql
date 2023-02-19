CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100))
RETURNS INT
AS
	BEGIN
	DECLARE @numberOfVisitors INT =
	(
		SELECT
			COUNT(*)
		FROM [Sites] AS s
		JOIN [SitesTourists] AS st
			ON s.[Id] = st.[SiteId]
		WHERE s.[Name] = @Site)
		
		IF(@numberOfVisitors IS NULL)
		BEGIN
			SET @numberOfVisitors = 0
		END
		RETURN @numberOfVisitors
	END
