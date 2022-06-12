CREATE PROCEDURE [dbo].[RegisterCeintureMembre]
	@idMembre INT,
	@idCeinture INT,
	@dateObtention DATE
AS
BEGIN

	INSERT INTO CeintureMembre (idMembre, idCeinture, dateObtention)
	OUTPUT inserted.id
	VALUES (@idMembre, @idCeinture, @dateObtention)

END
