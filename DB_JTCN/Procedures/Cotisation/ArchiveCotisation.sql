CREATE PROCEDURE [dbo].[ArchiveCotisation]
	@id INT
AS
BEGIN

	UPDATE Cotisation
	SET estArchive = 1
	WHERE idCotisation = @id

END
