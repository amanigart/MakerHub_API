CREATE PROCEDURE [dbo].[ActivateMembre]
	@idMembre INT
AS
BEGIN

	UPDATE Membre
	SET estActif = 1
	WHERE idMembre = @idMembre

END
