using Senai_filmes_webApi.Domains;
using Senai_filmes_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_filmes_webApi.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos gêneros
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {

        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// Data Source = Nome do servidor
        /// initial catalog = Nome do banco de dados que está sendo utilizado
        /// user Id=sa; pwd=senai@132 = Faz a autenticação com o usuário do SQL Server passando o logon e a senha
        /// integrated security=true = Faz a autenticação com o usuário do sistema (Windows)
        /// </summary>

        //private string stringConection = "Data Source=MATHEUSNOTE\\SQLEXPRESS; initial catalog=Filmes; user Id=sa; pwd=senai@132";
        private string stringConection = "Data Source=MATHEUSNOTE\\SQLEXPRESS; initial catalog=Filmes; integrated security=true";

        /// <summary>
        /// Atualiza um genero passando o seu Id pelo corpo(body) da requisição
        /// </summary>
        /// <param name="genero">Objeto genero com as novas informações</param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(stringConection))
            {
                // Declara a query que será executada
                string QueryUpdateIdBody = "UPDATE Generos SET Nome = @Nome WHERE IdGenero = @ID";

                // Declara o SqlCommand "cmd" passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(QueryUpdateIdBody, con))
                {
                    // Passa os valores para os parâmetros
                    cmd.Parameters.AddWithValue("@ID", genero.IdGenero);
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    // Abre a conexão com o banco de dadoa
                    con.Open();

                    // Executa o comando 
                    cmd.ExecuteNonQuery();

                }
            }
        } // Fim de AtualizarIdCorpo

        /// <summary>
        /// Atualiza um genero passando o Id pelo recurso (Url)
        /// </summary>
        /// <param name="id">Id do genero que será atualizado</param>
        /// <param name="genero">Objeto genero com as novas informações</param>
        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            // Declara a SqlConnection "con" passando a string de conexão como parametro
            using (SqlConnection con = new SqlConnection(stringConection))
            {
                // Declara a query que será executada
                string QueryUpdateIdUrl = "UPDATE Generos SET Nome = @Nome WHERE IdGenero = @ID";

                // Declara o SqlCommand "cmd" passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(QueryUpdateIdUrl, con))
                {
                    // Passa os valores para os parâmetros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    // Abre a conexão com o banco de dadoa
                    con.Open();

                    // Executa o comando 
                    cmd.ExecuteNonQuery();

                }
            }
        } // Fim de AtualizarIdUrl 

        /// <summary>
        /// Busca um genero através do seu Id
        /// </summary>
        /// <param name="id">Id do genero que será buscado</param>
        /// <returns>Retorna um genero buscado ou null cao não seja encontrado</returns>
        public GeneroDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConection))
            {
                // Declara a query a ser executada
                string QuerySelectById = "SELECT IdGenero, Nome FROM Generos WHERE IdGenero = @ID";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara a SqlDataReader "rdr" para receber os valores do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand "cmd" passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(QuerySelectById, con))
                {
                    // Passa o valor para o parametro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query e armazena os dados na rdr
                    rdr = cmd.ExecuteReader();

                    // Verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        // Se sim, instancia um novo objeto GeneroBuscado do tipo GeneroDomain
                        GeneroDomain GeneroBuscado = new GeneroDomain
                        {
                            // Atribui a propriedade IdGenero o valor da coluna "IdGenero" da tabela do banco de dados
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            // Atribui a propriedade Nome o valor da coluna "Nome" da tabela do banco de dados
                            Nome = (rdr["Nome"]).ToString(),


                        };
                        // Retorna o GeneroBuscado com os dados obtidos
                        return GeneroBuscado;

                    } // fim do if

                    // Se não, retorna null
                    return null;
                }
            }
        } // Fim do método BuscarPorId

        /// <summary>
        /// Cadastra um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto chamado "novoGenero" com as informações que serão cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            // Declara a conexão "con" passando a string de conexão (stringConection) como parâmetro
            using (SqlConnection con = new SqlConnection(stringConection))
            {

                // INSERT INTO Generos (Nome) VALUES ('Ficcao Cientifica');
                // INSERT INTO Generos (Nome) VALUES ('Joana D'Arc');
                // string QueryInsert = "INSERT INTO Generos (Nome) VALUES ('" + novoGenero.Nome + "')"; // Concatenação sendo feita para definir o (VALUES) valor de um nome do gênero
                // WARNING: Não usar na forma concatenação, pois pode causar o efeito Joana D'Arc
                // Além de permitir o SQL Injection
                // Por exemplo: 
                // 'Nome' : "perdeu mané')DROP TABLE Filmes --"
                // Ao tentar cadastrar o comando acima, irá deletar a tabela Filmes do banco de dados

                // Declara a Query nomeada "QueryInsert" que será executada

                string QueryInsert = "INSERT INTO Generos (Nome) VALUES (@Nome)";

                // Declara o SqlCommand "cmd" passando a Query "QueryInsert" que será executada, e a conexão "con" passando parâmetros
                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {

                    // Passa o valor para o parâmetro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);


                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Execute a Query 
                    cmd.ExecuteNonQuery();
                }
            }
        } // Fim do método Cadastrar

        /// <summary>
        /// Deleta um gênero através do seu Id
        /// </summary>
        /// <param name="id">Id do gênero que será deletado</param>
        public void Deletar(int id)
        {
            // Declara o SqlConnection passando a string de conexão "stringConection" como parâmetro
            using (SqlConnection con = new SqlConnection(stringConection))
            {
                // Declara a query ser executada passando o parâmetro @ID
                string queryDelete = "DELETE FROM Generos WHERE IdGenero = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Define o valor recebido no método Deletar junto com o valor do parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        } // Fim do método Deletar

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros</returns>
        public List<GeneroDomain> ListarTodos()
        {
            // Cria uma lista "ListaGeneros" onde serão armazenados os dados
            List<GeneroDomain> ListaGeneros = new List<GeneroDomain>();

            // Declara a SqlConnection chamada "con" passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConection))
            {
                // Declara a instrução "QuerySelectALL" a ser executada
                string QuerySelectALL = "SELECT IdGenero, Nome FROM Generos";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o tipo SqlDataReader com a variável nomeada "rdr" para percorrer a tabela "Generos" do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand chamado "cmd" passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(QuerySelectALL, con))
                {
                    // Executa a query e armazena os dados no "rdr"
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no "rdr", o laço se repete
                    while (rdr.Read())
                    {
                        // Intancia o objeto chamado "genero" do tipo "GeneroDomain"
                        GeneroDomain genero = new GeneroDomain()
                        {
                            // Atribui à propriedade "IdGenero" o valor da primeira coluna da tabela do banco de dados
                            IdGenero = Convert.ToInt32(rdr[0]), // Posiçao 0 definida na string "QuerySelectALL"

                            // Atribui à propriedade "Nome" o valor da segunda coluna da tabela do banco de dados
                            Nome = rdr[1].ToString() // Posiçao 1 definida na string "QuerySelectALL"
                        };

                        // Adiciona o objeto "genero" criado à lista nomeada "ListaGeneros"
                        ListaGeneros.Add(genero);
                    }
                }
            }

            // Retorna a lista de gêneros
            return ListaGeneros;

        } // Fim do método Listar Todos
    }
} // Fim do namespace
