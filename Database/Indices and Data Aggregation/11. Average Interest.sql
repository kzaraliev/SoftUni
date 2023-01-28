SELECT
	wd.[DepositGroup],
	wd.[IsDepositExpired],
	AVG(wd.[DepositInterest])
FROM [WizzardDeposits] AS wd
WHERE wd.[DepositStartDate] > '1985'
GROUP BY wd.[DepositGroup], [IsDepositExpired]
ORDER BY [DepositGroup] DESC,
		 [IsDepositExpired] ASC