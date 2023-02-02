CREATE FUNCTION ufn_CalculateFutureValue (@I DECIMAL(18,4), @R FLOAT, @T INT)
RETURNS DECIMAL(18,4)
AS
	BEGIN
		RETURN @I * POWER((1+@R), @T)
	END