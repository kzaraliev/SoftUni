CREATE FUNCTION ufn_IsWordComprised
(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @counter INT = 1
	WHILE (@counter <= LEN(@word))
	BEGIN		
		IF @setOfLetters NOT LIKE '%' + SUBSTRING(@word, @counter, 1) + '%' RETURN 0
		SET @counter += 1
	END
	RETURN 1
END