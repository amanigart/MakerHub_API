﻿CREATE TABLE [dbo].[AppUtilisateur]
(
	idUtilisateur INT NOT NULL PRIMARY KEY IDENTITY,
	[login] VARCHAR(100) NOT NULL,
	passwd VARBINARY(64) NOT NULL
)
