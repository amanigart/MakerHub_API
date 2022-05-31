CREATE PROCEDURE [dbo].[RegisterPresence]
	@idMembre INT,
	@idEntrainement INT
AS
BEGIN

	INSERT INTO Presence (idMembre, idEntrainement)
	OUTPUT inserted.idPresence
	VALUES (@idMembre, @idEntrainement)

END
