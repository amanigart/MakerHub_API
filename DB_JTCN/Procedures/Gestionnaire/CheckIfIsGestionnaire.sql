CREATE PROCEDURE [dbo].[CheckIfIsGestionnaire]
	@id INT
AS
BEGIN

	-- récupérer idMembre correspondant à utilisateur
	DECLARE @idMembre INT
	SET @idMembre = (SELECT idMembre FROM Membre WHERE idUtilisateur = @id)

	-- vérifier si gestionnaire avec cet idMembre existe
	IF NOT EXISTS (SELECT idGestionnaire FROM Gestionnaire WHERE idMembre = @idMembre)
		SELECT CAST(0 AS BIT)
	ELSE
		SELECT CAST(1 AS BIT)

END