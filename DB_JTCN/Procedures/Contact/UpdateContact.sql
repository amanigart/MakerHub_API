CREATE PROCEDURE [dbo].[UpdateContact]
	@id INT,
	@idMembre INT,
	@idContact INT,
	@lienMembre VARCHAR(50)
AS
BEGIN

	UPDATE Contact
	SET idMembre = @idMembre,
		idContact = @idContact,
		lienAvecMembre = @lienMembre
	WHERE id = @id

END
