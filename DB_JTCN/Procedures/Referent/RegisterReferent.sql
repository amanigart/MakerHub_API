CREATE PROCEDURE [dbo].[RegisterReferent]
	@idMembre INT,
	@idReferent INT,
	@lienMembre VARCHAR(50)
AS
BEGIN
	INSERT INTO Referent (idMembre, idReferent, lienAvecMembre)
	OUTPUT inserted.id
	VALUES (@idMembre, @idReferent, @lienMembre)
END
