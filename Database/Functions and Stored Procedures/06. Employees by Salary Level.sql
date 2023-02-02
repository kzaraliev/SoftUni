CREATE PROC usp_EmployeesBySalaryLevel @salaryLevel VARCHAR(10)
AS
	SELECT
		[FirstName],
		[LastName]
	FROM [Employees]
	WHERE @salaryLevel = dbo.ufn_GetSalaryLevel([Salary])