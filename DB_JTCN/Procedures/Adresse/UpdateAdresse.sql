CREATE PROCEDURE [dbo].[UpdateAdresse]
	@idAdresse INT,
	@rue VARCHAR(100),
	@numero VARCHAR(15),
	@cp INT,
	@ville VARCHAR(100)
AS
BEGIN

	UPDATE Adresse
	SET rue = @rue, 
		numero = @numero, 
		codePostal = @cp, 
		ville = @ville
	WHERE idAdresse = @idAdresse

END
