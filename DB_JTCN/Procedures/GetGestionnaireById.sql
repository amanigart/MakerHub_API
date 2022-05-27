CREATE PROCEDURE [dbo].[GetGestionnaireById]
	@id int
AS
BEGIN
	--IF NOT EXISTS (SELECT idGestionnaire FROM Gestionnaire WHERE idGestionnaire = @id)
	--	THROW 51002, 'Gestionnaire inexistant', 1;

	SELECT idGestionnaire FROM Gestionnaire WHERE idGestionnaire = @id
END