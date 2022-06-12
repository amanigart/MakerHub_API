CREATE PROCEDURE [dbo].[RegisterTarif]
	@prix FLOAT,
	@duree VARCHAR(25)
AS
BEGIN

	INSERT INTO Tarif (prix, duree)
	OUTPUT inserted.idTarif
	VALUES (@prix, @duree)

END
