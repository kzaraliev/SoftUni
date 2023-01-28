SELECT
	[DepositGroup],
	[MagicWandCreator],
	MIN([DepositCharge]) AS [MinDepositCharge]
FROM [WizzardDeposits]
GROUP BY [MagicWandCreator], [DepositGroup]
ORDER BY [MagicWandCreator], [DepositGroup]