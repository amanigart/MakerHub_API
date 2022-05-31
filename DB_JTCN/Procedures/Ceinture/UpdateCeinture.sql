CREATE PROCEDURE [dbo].[UpdateCeinture]
	@idCeinture INT,
	@couleur VARCHAR(50),
	@nbPresences INT,
	@idDiscipline INT
AS
BEGIN

	UPDATE Ceinture
	SET couleur = @couleur,
		nbPresencesRequis = @nbPresences,
		idDiscipline = @idDiscipline
	WHERE idCeinture = @idCeinture

END
