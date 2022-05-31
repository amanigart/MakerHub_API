CREATE PROCEDURE [dbo].[GetGestionnaireById]
	@idGestionnaire int
AS
BEGIN

	SELECT idGestionnaire FROM Gestionnaire WHERE idGestionnaire = @idGestionnaire

END