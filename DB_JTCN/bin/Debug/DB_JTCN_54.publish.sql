﻿/*
Script de déploiement pour DB_MakerHub

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DB_MakerHub"
:setvar DefaultFilePrefix "DB_MakerHub"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Détectez le mode SQLCMD et désactivez l'exécution du script si le mode SQLCMD n'est pas pris en charge.
Pour réactiver le script une fois le mode SQLCMD activé, exécutez ce qui suit :
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Le mode SQLCMD doit être activé de manière à pouvoir exécuter ce script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Création de la base de données $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Création de Table [dbo].[AppUtilisateur]...';


GO
CREATE TABLE [dbo].[AppUtilisateur] (
    [idUtilisateur] INT            IDENTITY (1, 1) NOT NULL,
    [login]         VARCHAR (100)  NOT NULL,
    [passwd]        VARBINARY (64) NOT NULL,
    PRIMARY KEY CLUSTERED ([idUtilisateur] ASC)
);


GO
PRINT N'Création de Table [dbo].[Gestionnaire]...';


GO
CREATE TABLE [dbo].[Gestionnaire] (
    [idGestionnaire] INT           IDENTITY (1, 1) NOT NULL,
    [prenom]         VARCHAR (50)  NOT NULL,
    [nom]            VARCHAR (50)  NOT NULL,
    [email]          VARCHAR (100) NOT NULL,
    [telephone]      VARCHAR (15)  NOT NULL,
    [idUtilisateur]  INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([idGestionnaire] ASC)
);


GO
PRINT N'Création de Table [dbo].[Salt]...';


GO
CREATE TABLE [dbo].[Salt] (
    [idUtilisateur] INT           NOT NULL,
    [salt]          VARCHAR (100) NOT NULL,
    CONSTRAINT [pk_salt] PRIMARY KEY CLUSTERED ([idUtilisateur] ASC, [salt] ASC)
);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_id_utilisateur]...';


GO
ALTER TABLE [dbo].[Gestionnaire]
    ADD CONSTRAINT [FK_id_utilisateur] FOREIGN KEY ([idUtilisateur]) REFERENCES [dbo].[AppUtilisateur] ([idUtilisateur]);


GO
PRINT N'Création de Clé étrangère [dbo].[fk_salt_idUser]...';


GO
ALTER TABLE [dbo].[Salt]
    ADD CONSTRAINT [fk_salt_idUser] FOREIGN KEY ([idUtilisateur]) REFERENCES [dbo].[AppUtilisateur] ([idUtilisateur]);


GO
PRINT N'Création de Fonction [dbo].[GetSecretKey]...';


GO
CREATE FUNCTION [dbo].[GetSecretKey]
()
RETURNS VARCHAR(200)
AS
BEGIN
	RETURN '1 H4v3 N0 1d34 Wh4t 1 4m D01ng'
END
GO
PRINT N'Création de Procédure [dbo].[CheckIfUserIsAdmin]...';


GO
CREATE PROCEDURE [dbo].[CheckIfUserIsAdmin]
	@id int
AS
BEGIN
	IF NOT EXISTS (SELECT idGestionnaire FROM Gestionnaire WHERE idUtilisateur = @id)
		RETURN 0;

	RETURN 1;
END
GO
PRINT N'Création de Procédure [dbo].[GetGestionnaireById]...';


GO
CREATE PROCEDURE [dbo].[GetGestionnaireById]
	@id int
AS
BEGIN
	--IF NOT EXISTS (SELECT idGestionnaire FROM Gestionnaire WHERE idGestionnaire = @id)
	--	THROW 51002, 'Gestionnaire inexistant', 1;

	SELECT idGestionnaire FROM Gestionnaire WHERE idGestionnaire = @id
END
GO
PRINT N'Création de Procédure [dbo].[Login]...';


GO
CREATE PROCEDURE [dbo].[Login]
	@login VARCHAR(100),
	@passwd VARCHAR(200) 
AS
BEGIN
	-- Throw exception custom si login n'existe pas dans table AppUtilisateur
	IF NOT EXISTS (SELECT [login] FROM AppUtilisateur WHERE [login] = @login)
		THROW 51000, 'Login incorrect.', 1

	DECLARE @secretKey VARCHAR(200)
	SET @secretKey = [dbo].GetSecretKey()
	
	DECLARE @salt VARCHAR(100)
	SET @salt = (SELECT salt FROM dbo.Salt 
				 WHERE idUtilisateur = (SELECT idUtilisateur FROM AppUtilisateur
										 WHERE [login] = @login))

	DECLARE @passwdHash VARBINARY(64)
	SET @passwdHash = HASHBYTES('SHA2_512', CONCAT(@salt, @secretKey, @passwd, @salt))

	-- Throw exception custom si login existe mais que mot de passe incorrect
	IF NOT EXISTS (SELECT [login] FROM AppUtilisateur WHERE [login] = @login AND passwd = @passwdHash)
		THROW 51001, 'Mot de passe incrorrect.', 1

	-- Sortir utilisateur si login + passwd corrects
	SELECT idUtilisateur, [login]
	FROM AppUtilisateur 
	WHERE [login] = @login AND passwd = @passwdHash
END
GO
PRINT N'Création de Procédure [dbo].[RegisterAppUtilisateur]...';


GO
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
GO
/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

EXEC RegisterAppUtilisateur 'admin', 'admin';
EXEC RegisterAppUtilisateur 'demo', 'demo'; 

INSERT INTO Gestionnaire (prenom, nom, email, telephone, idUtilisateur)
VALUES ('Kristopher', 'Baugniet', 'kb@mail.com', '0472154863', 1);
GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Mise à jour terminée.';


GO
