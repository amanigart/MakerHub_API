﻿CREATE TABLE [dbo].[Adresse]
(
	idAdresse INT NOT NULL PRIMARY KEY IDENTITY,
	rue VARCHAR(100) NOT NULL,
	numero VARCHAR(15) NOT NULL,
	codePostal INT NOT NULL,
	ville VARCHAR(100) NOT NULL
)
