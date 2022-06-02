CREATE VIEW [dbo].[V_CeinturesJiujitsu]
	AS 
	SELECT cm.id, cm.idMembre, c.couleur
	FROM Discipline as d 
		 JOIN Ceinture as c ON (d.idDiscipline = c.idDiscipline)
		 JOIN CeintureMembre as cm ON (c.idCeinture = cm.idCeinture)
	WHERE (d.idDiscipline = 1)
