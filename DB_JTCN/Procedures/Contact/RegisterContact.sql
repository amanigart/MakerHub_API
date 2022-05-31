CREATE PROCEDURE [dbo].[RegisterContact]
	@idMembre INT,
	@idContact INT,
	@lienMembre VARCHAR(50)
AS
BEGIN
	INSERT INTO Contact (idMembre, idContact, lienAvecMembre)
	OUTPUT inserted.id
	VALUES (@idMembre, @idContact, @lienMembre)
END
