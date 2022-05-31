CREATE PROCEDURE [dbo].[RegisterPersonne]
	@nom VARCHAR(50),
	@prenom VARCHAR(50),
	@email VARCHAR(150),
	@tel VARCHAR(15),
	@idAdresse INT
AS
BEGIN
	INSERT INTO Personne (nom, prenom, email, telephone, idAdresse)
	OUTPUT inserted.idPersonne
	VALUES (@nom, @prenom, @email, @tel, @idAdresse)
END
