SELECT
	DISTINCT [FirstLetter]
FROM(
SELECT
	SUBSTRING(wd.[FirstName],1,1) AS [FirstLetter]
FROM [WizzardDeposits] AS wd
WHERE wd.[DepositGroup] = 'Troll Chest'
GROUP BY wd.[FirstName]) AS [Letter]
