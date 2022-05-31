CREATE PROCEDURE [dbo].[RegisterGestionnaire]
	@idMembre INT
AS
BEGIN
	INSERT INTO Gestionnaire (idMembre)
	OUTPUT inserted.idGestionnaire
	VALUES (@idMembre)
END
