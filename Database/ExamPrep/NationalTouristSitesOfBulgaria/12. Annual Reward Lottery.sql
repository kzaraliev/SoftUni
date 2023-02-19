CREATE PROC usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS
BEGIN
	SELECT
		t.[Name],
		CASE
			WHEN COUNT(s.[Id]) >= 100 THEN 'Gold badge'
			WHEN COUNT(s.[Id]) >= 50 THEN 'Silver badge'
			WHEN COUNT(s.[Id]) >= 25 THEN 'Bronze badge'
		END AS [Reward]
	FROM [Tourists] AS t
	JOIN [SitesTourists] AS st
		ON t.[Id] = st.[TouristId]
	JOIN [Sites] AS s
		ON st.[SiteId] = s.[Id]
	WHERE t.[Name] = @TouristName
	GROUP BY t.[Name]
END