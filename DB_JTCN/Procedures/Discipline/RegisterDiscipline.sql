CREATE PROCEDURE [dbo].[RegisterDiscipline]
	@nom VARCHAR(50)
AS
BEGIN

	INSERT INTO Discipline (nom)
	OUTPUT inserted.idDiscipline
	VALUES (@nom)

END
