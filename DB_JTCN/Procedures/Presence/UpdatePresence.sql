CREATE PROCEDURE [dbo].[UpdatePresence]
	@id INT,
	@idMembre INT,
	@idEntrainement INT
AS
BEGIN

	UPDATE Presence
	SET idMembre = @idMembre,
		idEntrainement = @idEntrainement
	WHERE idPresence = @id

END
