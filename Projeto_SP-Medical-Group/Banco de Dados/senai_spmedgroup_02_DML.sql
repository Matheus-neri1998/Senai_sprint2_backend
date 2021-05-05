-- Projeto SP Medical Group - DML

USE Project_SP_Medical_Group;

INSERT INTO TiposUsuarios (TipoUsuario) -- Tabela TiposUsuarios
VALUES					  ('Administrador')
						 ,('Medico')
						 ,('Paciente');

INSERT INTO Usuarios   (IdTipoUsuario, Email, Senha) -- Tabela Usuarios
VALUES				   (3, 'ligia@gmail.com', 'ligia123')
					  ,(3, 'alexandre@gmail.com', 'xandao123')
					  ,(3, 'fernando@gmail.com', 'nando123')
					  ,(3, 'henrique@gmail.com', 'riqui123')
					  ,(3, 'joao@hotmail.com', 'joazinho123')
					  ,(3, 'bruno@gmail.com', 'bruno123')
					  ,(3, 'mariana@outlook.com', 'mari123')
					  ,(2, 'ricardo.lemos@spmedicalgroup.com.br', 'ricalemos123')
					  ,(2, 'roberto.possarle@spmedicalgroup.com.br', 'possarle123')
					  ,(2, 'helena.souza@spmedicalgroup.com.br', 'helena123')
					  ,(1, 'adm@adm.com', 'adm123');

INSERT INTO Especialidades (TipoEspecialidade) -- Tabela Especialidades
VALUES                     ('Acupuntura')
						  ,('Anestesiologia')
						  ,('Angiologia')
						  ,('Cardiologia')
						  ,('Cirurgia Cardiovascular')
						  ,('Cirurgia da Mão')
						  ,('Cirurgia do Aparelho Digestivo')
						  ,('Cirurgia Geral')
						  ,('Cirurgia Pediátrica')
						  ,('Cirurgia Plástica')
						  ,('Cirurgia Torácica')
						  ,('Cirurgia Vascular')
						  ,('Dermatologia')
						  ,('Radioterapia')
						  ,('Urologia')
						  ,('Pediatria')
						  ,('Psiquiatria');

INSERT INTO Situacoes (Situacao) -- Tabela Situacao
VALUES                ('Agendada')
					 ,('Cancelada')
					 ,('Realizada');

INSERT INTO Pacientes (IdUsuario, NomePaciente, Rg, Cpf, Endereco, DataNascimento, Telefone) -- Tabela Pacientes
VALUES                (1, 'Ligia', '435225435', '94839859000', 'Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000', '13/10/1983', '1134567654')
					 ,(2, 'Alexandre', '326543457', '73556944057', 'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200', '23/07/2001', '11987656543')
					 ,(3, 'Fernando', '546365253', '16839338002', 'Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200', '10/10/1978', '11972084453')
					 ,(4, 'Henrique', '543663625', '14332654765', 'R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030', '13/10/1985', '1134566543')
					 ,(5, 'João', '3325444441', '91305348010', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380', '27/08/1975', '1176566377')
					 ,(6, 'Bruno', '545662667', '79799299004', 'Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001', '21/03/1972', '11954368769')
					 ,(7, 'Mariana', '545662668', '13771913039', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140', '05/03/2018', '0');

INSERT INTO Clinicas (NomeFantasia, Cnpj, RazaoSocial, Endereco, HorarioAbertura, HorarioFechamento) -- Tabela Clinicas
VALUES               ('ClinicaPossarle', '86400902000130', 'SP Medical Group', 'Al. Barão de Limeira, 532, São Paulo, SP', '6:00', '20:00');

INSERT INTO Medicos (IdUsuario, IdClinica, IdEspecialidade, NomeMedico, Crm) -- Tabela Medicos
VALUES              (1, 1, 2, 'Ricardo Lemos', '54356-SP')
				   ,(2, 1, 17, 'Roberto Possarle', '53452-SP')
				   ,(3, 1, 16, 'Helena Strada', '65463-SP');

INSERT INTO Consultas (IdMedico, IdPaciente, IdSituacao, DataConsulta, Horario, Descricao) -- Tabela Consultas
VALUES                (3, 7, 1, '20/01/2020', '15:00', 'Paciente com anemia')
					 ,(2, 2, 2, '06/01/2020', '10:00', 'Paciente com severas crises de ansiedade')
					 ,(2, 3, 1, '02/07/2020', ' 11:00', 'Paciente que sofre com constantes surtos')
					 ,(2, 2, 1, '06/02/2018', '10:00', 'Paciente com TDI')
					 ,(1, 4, 2, '07/02/2019', '11:00', 'Paciente inseguro para cirurgia')
					 ,(3, 7, 3, '08/03/2020', '15:00', 'Paciente que sofre com disturbios alimentares')
					 ,(1, 4, 3, '09/03/2020', '11:00', 'Paciente que se recusou tomar anestesia');