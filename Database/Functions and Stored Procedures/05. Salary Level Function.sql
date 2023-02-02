CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10) AS
BEGIN
	DECLARE @level VARCHAR(50) = 'Average';
	IF(@salary < 30000)
	BEGIN
		SET @level = 'Low'
	END;

	ELSE IF(@salary > 50000)
	BEGIN
		SET @level = 'High'
	END;
	RETURN @level;
END;

SELECT
	[Salary],
	dbo.[ufn_GetSalaryLevel](Salary) AS [Salary Level]
FROM [Employees]