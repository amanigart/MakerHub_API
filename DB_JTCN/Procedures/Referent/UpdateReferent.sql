CREATE PROCEDURE [dbo].[UpdateReferent]
	@id INT,
	@idMembre INT,
	@idReferent INT,
	@lienMembre VARCHAR(50)
AS
BEGIN

	UPDATE Referent
	SET idMembre = @idMembre,
		idReferent = @idReferent,
		lienAvecMembre = @lienMembre
	WHERE id = @id

END
