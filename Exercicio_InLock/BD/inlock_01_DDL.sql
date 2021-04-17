-- Exercício InLock - DDL 

CREATE DATABASE InLock

USE InLock

CREATE TABLE Estudios
(
	IdEstudio		INT PRIMARY KEY IDENTITY
	,NomeEstudio	VARCHAR(150) NOT NULL
);

CREATE TABLE Jogos
(
	IdJogo				INT PRIMARY KEY IDENTITY
	,NomeJogo			VARCHAR(150) NOT NULL
	,Descricao			VARCHAR(200) NOT NULL
	,DataLancamento		VARCHAR(100) NOT NULL
	,Valor				VARCHAR (100) NOT NULL
	,IdEstudio          INT FOREIGN KEY REFERENCES Estudios (IdEstudio)
);	

CREATE TABLE TipoUsuario 
(
	IdTipoUsuario			INT PRIMARY KEY IDENTITY
	,Titulo					VARCHAR(100) NOT NULL
);

CREATE TABLE Usuario
(
	IdUsuario			INT PRIMARY KEY IDENTITY
	,Email				VARCHAR (200) NOT NULL
	,Senha				VARCHAR (200) NOT NULL
	,IdTipoUsuario		INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
);