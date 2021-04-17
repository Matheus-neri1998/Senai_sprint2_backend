USE InLock

SELECT * FROM Usuario

SELECT * FROM Estudios

SELECT * FROM Jogos

SELECT Jogos.NomeJogo, Estudios.NomeEstudio FROM Jogos
INNER JOIN Estudios
ON Estudios.IdEstudio = Jogos.IdEstudio

SELECT Estudios.NomeEstudio, Jogos.NomeJogo FROM Estudios
FULL OUTER JOIN Jogos
ON Jogos.IdEstudio = Estudios.IdEstudio 

SELECT Usuario.Email, Usuario.Senha FROM Usuario

SELECT Jogos.IdJogo FROM Jogos

SELECT Estudios.IdEstudio FROM Estudios
