CREATE PROCEDURE [dbo].[RegisterAdresse]
	@rue VARCHAR(100),
	@numero VARCHAR(15),
	@cp INT,
	@ville VARCHAR(100)
AS
BEGIN

	INSERT INTO Adresse (rue, numero, codePostal, ville)
	OUTPUT inserted.idAdresse
	VALUES (@rue, @numero, @cp, @ville)

END
