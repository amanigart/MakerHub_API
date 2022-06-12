CREATE VIEW [dbo].[V_Ceintures]
	AS 
	SELECT cm.id, cm.idMembre, cm.dateObtention, d.nom as discipline, c.couleur
	FROM Discipline as d 
    JOIN Ceinture as c ON (d.idDiscipline = c.idDiscipline)
	JOIN CeintureMembre as cm ON (c.idCeinture = cm.idCeinture)
