-- Exerc�cio InLock - DML 

USE InLock

INSERT INTO Estudios (NomeEstudio)
VALUES               ('Blizzard')
					,('Rockstar Studios')
					,('Square Enix');

INSERT INTO TipoUsuario (Titulo)
VALUES					('Administrador')
					   ,('Cliente');


INSERT INTO Usuario (Email, Senha, IdTipoUsuario)
VALUES				('admin@admin.com', 'admin', 1)
				   ,('cliente@cliente.com', 'cliente', 2)

INSERT INTO Jogos (NomeJogo, Descricao, DataLancamento, Valor, IdEstudio)
VALUES            ('Diablo 3', '� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�', '15/05/2012', 'R$ 99,00', 1)
				 ,('Red Dead Redemption II', 'jogo eletr�nico de a��o-aventura western', '26/10/2018', 'R$ 120,00', 2);


				 