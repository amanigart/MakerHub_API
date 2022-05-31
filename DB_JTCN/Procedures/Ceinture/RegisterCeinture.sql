CREATE PROCEDURE [dbo].[RegisterCeinture]
	@couleur VARCHAR(50),
	@nbPresences INT,
	@idDiscipline INT
AS
BEGIN

	INSERT INTO Ceinture (couleur, nbPresencesRequis, idDiscipline)
	OUTPUT inserted.idCeinture
	VALUES (@couleur, @nbPresences, @idDiscipline)

END
