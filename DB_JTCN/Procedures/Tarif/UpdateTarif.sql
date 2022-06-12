CREATE PROCEDURE [dbo].[UpdateTarif]
	@id INT,
	@prix FLOAT,
	@duree VARCHAR(25)
AS
BEGIN

	UPDATE Tarif 
	SET prix = @prix,
		duree = @duree
	WHERE idTarif = @id

END
