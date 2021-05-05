-- Projeto SP Medical Group - DQL/JOINS

USE Project_SP_Medical_Group

SELECT * FROM TiposUsuarios;
SELECT * FROM Usuarios;
SELECT * FROM Especialidades;
SELECT * FROM Situacoes;
SELECT * FROM Pacientes;
SELECT * FROM Clinicas;
SELECT * FROM Medicos;
SELECT * FROM Consultas;
GO

SELECT IdUsuario, TiposUsuarios.IdTipoUsuario, TipoUsuario, Email, Senha FROM Usuarios -- Selecionando as colunas da tabela "Usuario"
INNER JOIN TiposUsuarios -- Juntando as colunas da tabela "Usuario" com tabela "TiposUsuarios"
ON Usuarios.IdTipoUsuario = TiposUsuarios.IdTipoUsuario  
WHERE TipoUsuario = 'Paciente' 

SELECT NomeFantasia AS Clinica, Medicos.IdClinica, Especialidades.IdEspecialidade, NomeMedico, Crm, Cnpj, Endereco, HorarioAbertura, HorarioFechamento FROM Clinicas
INNER JOIN Medicos -- Juntando a tabela Medicos com a tabela Clinicas
ON Clinicas.IdClinica = Medicos.IdClinica
INNER JOIN Especialidades -- Juntando a tabela Especialidades com as tabelas Clinicas e Medicos
ON Medicos.IdEspecialidade = Especialidades.IdEspecialidade

SELECT IdPaciente, Usuarios.IdUsuario, Email, Senha, NomePaciente, Rg, Cpf, Pacientes.Endereco, DataNascimento, Telefone FROM Pacientes
INNER JOIN Usuarios -- Juntando a tabela Usuarios com a tabela Pacientes
ON Pacientes.IdUsuario = Usuarios.IdUsuario

SELECT IdConsulta, IdPaciente, Medicos.IdMedico, NomeMedico, IdSituacao, DataConsulta, Horario AS HorarioConsulta, Descricao FROM Consultas
INNER JOIN Medicos -- Juntando a tabela Medicos com a tabela Consultas
ON Consultas.IdMedico = Medicos.IdMedico




