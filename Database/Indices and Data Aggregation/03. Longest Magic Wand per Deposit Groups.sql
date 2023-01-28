SELECT
	wd.[DepositGroup],
	MAX(wd.[MagicWandSize])
FROM [WizzardDeposits] AS wd
GROUP BY wd.[DepositGroup]