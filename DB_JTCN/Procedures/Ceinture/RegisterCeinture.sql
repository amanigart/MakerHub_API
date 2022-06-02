CREATE PROCEDURE [dbo].[RegisterCeinture]
	@couleur VARCHAR(50),
	@illustration VARCHAR(200),
	@nbPresences INT,
	@idDiscipline INT
AS
BEGIN

	INSERT INTO Ceinture (couleur, illustration, nbPresencesRequis, idDiscipline)
	OUTPUT inserted.idCeinture
	VALUES (@couleur, @illustration, @nbPresences, @idDiscipline)

END
