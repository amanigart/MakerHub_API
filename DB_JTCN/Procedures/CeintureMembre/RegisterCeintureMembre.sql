CREATE PROCEDURE [dbo].[RegisterCeintureMembre]
	@idMembre INT,
	@idCeinture INT
AS
BEGIN

	INSERT INTO CeintureMembre (idMembre, idCeinture)
	OUTPUT inserted.id
	VALUES (@idMembre, @idCeinture)

END
