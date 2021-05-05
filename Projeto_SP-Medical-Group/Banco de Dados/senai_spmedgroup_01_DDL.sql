-- Projeto SP Medical Group - DDL 

CREATE DATABASE Project_SP_Medical_Group -- Criando o Banco de Dados à partir da linguagem DDL 

USE Project_SP_Medical_Group

CREATE TABLE TiposUsuarios -- Tabela TiposUsuarios
(
	IdTipoUsuario		INT PRIMARY KEY IDENTITY
	,TipoUsuario		VARCHAR (100) NOT NULL
);


CREATE TABLE Usuarios -- Tabela Usuarios
(
	IdUsuario		INT PRIMARY KEY IDENTITY
	,IdTipoUsuario   INT FOREIGN KEY REFERENCES TiposUsuarios (IdTipoUsuario) 
	,Email           VARCHAR (200)  NOT NULL
	,Senha           VARCHAR (200) NOT NULL
);


CREATE TABLE Especialidades  -- Tabela Especialidades
(
	IdEspecialidade      INT PRIMARY KEY IDENTITY
	,TipoEspecialidade	 VARCHAR (100) UNIQUE NOT NULL
);


CREATE TABLE Situacoes  -- Tabela Situacoes
(
	IdSituacao     INT PRIMARY KEY IDENTITY
	,Situacao       VARCHAR(100) NOT NULL
);


CREATE TABLE Pacientes  -- Tabela Pacientes
(
	IdPaciente			INT PRIMARY KEY IDENTITY
	,IdUsuario			INT FOREIGN KEY REFERENCES Usuarios (IdUsuario)
	,NomePaciente		VARCHAR (100) NOT NULL
	,Rg					CHAR (10)  NOT NULL
	,Cpf				CHAR (14)  NOT NULL
	,Endereco			VARCHAR (100) NOT NULL
	,DataNascimento     DATE NOT NULL
	,Telefone           CHAR (11) NOT NULL
);


CREATE TABLE Clinicas -- Tabela Clinicas
(
	IdClinica			INT PRIMARY KEY IDENTITY
	,NomeFantasia		VARCHAR (100) NOT NULL
	,Cnpj				CHAR (14) NOT NULL
	,RazaoSocial		VARCHAR (100) NOT NULL
	,Endereco			VARCHAR (100) NOT NULL
	,HorarioAbertura	TIME NOT NULL
	,HorarioFechamento	TIME NOT NULL 
);


CREATE TABLE Medicos  -- Tabela Medicos
(
	IdMedico				INT PRIMARY KEY IDENTITY
	,IdUsuario				INT FOREIGN KEY REFERENCES Usuarios (IdUsuario)
	,IdClinica				INT FOREIGN KEY REFERENCES Clinicas (IdClinica)
	,IdEspecialidade		INT FOREIGN KEY REFERENCES Especialidades (IdEspecialidade)
	,NomeMedico             VARCHAR (100) NOT NULL
	,Crm					VARCHAR (100) NOT NULL
);


CREATE TABLE Consultas  -- Tabela Consultas
(
	 IdConsulta         INT PRIMARY KEY IDENTITY  
	 ,IdMedico          INT FOREIGN KEY REFERENCES Medicos (IdMedico)
	 ,IdPaciente        INT FOREIGN KEY REFERENCES Pacientes (IdPaciente)
	 ,IdSituacao        INT FOREIGN KEY REFERENCES Situacoes (IdSituacao)
	 ,DataConsulta      DATE NOT NULL
	 ,Horario           TIME NOT NULL
	 ,Descricao         VARCHAR (200) NOT NULL
);


