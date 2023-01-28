SELECT
 	[DepartmentID],
	MAX([Salary]) AS [ThirdHighestSalary]
FROM
(
	SELECT 
		[DepartmentID],
		[Salary],
		DENSE_RANK() OVER (PARTITION BY [DepartmentID] ORDER BY [Salary] DESC) AS Rank
	FROM [Employees]
) AS t
WHERE [Rank] = 3
GROUP BY [DepartmentID]