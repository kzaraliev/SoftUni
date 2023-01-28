SELECT
	a.[AgeGroup],
	COUNT(a.[AgeGroup]) AS [WizzardCount]
FROM(
SELECT
	CASE
		WHEN [Age] <= 10 THEN '[0-10]'
		WHEN [Age] > 10 AND [Age] <= 20 THEN '[11-20]'
		WHEN [Age] > 20 AND [Age] <= 30 THEN '[21-30]'
		WHEN [Age] > 30 AND [Age] <= 40 THEN '[31-40]'
		WHEN [Age] > 40 AND [Age] <= 50 THEN '[41-50]'
		WHEN [Age] > 50 AND [Age] <= 60 THEN '[51-60]'
		ELSE '[61+]'
	END AS [AgeGroup]
FROM [WizzardDeposits]) AS a
GROUP BY [AgeGroup]

