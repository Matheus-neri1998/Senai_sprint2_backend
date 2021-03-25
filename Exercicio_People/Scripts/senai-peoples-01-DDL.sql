-- Exercicio Peoples - Script DDL --

-- Criando o banco de dados Peoples

-- Peoples - Script DDL 

CREATE DATABASE Peoples

-- Usando banco de dados Peoples
USE Peoples

CREATE TABLE Funcionarios -- Criando a tabela Funcionários
(
     IdFuncionario INT PRIMARY KEY IDENTITY
	,Nome          VARCHAR (200) NOT NULL
	,Sobrenome     VARCHAR (200) NOT NULL
);


