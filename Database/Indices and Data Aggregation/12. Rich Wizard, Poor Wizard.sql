SELECT
	SUM(wd1.[DepositAmount] - wd2.[DepositAmount]) AS [SumDifference]
FROM [WizzardDeposits] AS wd1
LEFT JOIN [WizzardDeposits] AS wd2
	ON wd1.[Id] = wd2.[Id] - 1