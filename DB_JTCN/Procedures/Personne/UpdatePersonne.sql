CREATE PROCEDURE [dbo].[UpdatePersonne]
	@idPersonne INT,
	@nom VARCHAR(50),
	@prenom VARCHAR(50),
	@email VARCHAR(150),
	@tel VARCHAR(15),
	@idAdresse INT
AS
BEGIN

	UPDATE Personne
	SET nom = @nom,
		prenom = @prenom,
		email = @email,
		telephone = @tel,
		idAdresse = @idAdresse
	WHERE idPersonne = @idPersonne

END
