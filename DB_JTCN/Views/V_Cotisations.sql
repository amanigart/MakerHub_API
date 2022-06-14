CREATE VIEW [dbo].[V_Cotisations]
	AS 
	SELECT c.idCotisation, c.dateDebut, c.dateFin, c.estPaye, c.estArchive, c.idMembre, t.idTarif, t.prix, t.duree, p.nom, p.prenom
	FROM Cotisation c
	JOIN Tarif t ON (t.idTarif = c.idTarif)
	JOIN Membre m ON (m.idMembre = c.idMembre)
	JOIN Personne p ON (p.idPersonne = m.idPersonne)
