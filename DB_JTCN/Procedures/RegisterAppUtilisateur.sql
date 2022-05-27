CREATE PROCEDURE [dbo].[RegisterAppUtilisateur]
	@login VARCHAR(100),
	@passwd VARCHAR(100)
AS 
BEGIN
	SET NOCOUNT ON

	DECLARE @tempIdTable TABLE (id INT)

	DECLARE @secretKey VARCHAR(200)
	SET @secretKey = [dbo].GetSecretKey()

	DECLARE @salt VARCHAR(100)
	SET @salt = CONCAT(NEWID(), NEWID(), NEWID())

	DECLARE @passwdHash VARBINARY(64)
	SET @passwdHash = HASHBYTES('SHA2_512', CONCAT(@salt, @secretKey, @passwd, @salt))

	INSERT INTO [dbo].AppUtilisateur ([login], passwd)
	OUTPUT inserted.idUtilisateur INTO @tempIdTable(id)
	VALUES (@login, @passwdHash)

	INSERT INTO [dbo].Salt (idUtilisateur, salt)
	VALUES ((SELECT id FROM @tempIdTable), @salt)
END
