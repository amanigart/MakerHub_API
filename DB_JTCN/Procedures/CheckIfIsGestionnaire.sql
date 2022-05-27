CREATE PROCEDURE [dbo].[CheckIfIsGestionnaire]
	@id INT
AS
BEGIN

	IF NOT EXISTS (SELECT idGestionnaire FROM Gestionnaire WHERE idUtilisateur = @id)
		SELECT CAST(0 AS BIT)
	ELSE
		SELECT CAST(1 AS BIT)

END