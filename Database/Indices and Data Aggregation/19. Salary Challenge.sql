SELECT TOP 10
	e.[FirstName],
	e.[LastName],
	e.[DepartmentID]
FROM [Employees] AS e
JOIN(
SELECT
	[DepartmentID],
	AVG(e.[Salary]) AS [AvgSalary]
FROM [Employees] AS e
GROUP BY e.[DepartmentID]) AS AvgTable
	ON e.[DepartmentID] = AvgTable.[DepartmentID]
WHERE e.[Salary] > AvgTable.[AvgSalary]