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
    /// Classe responsável pelo repositório de Filmes
    /// </summary>
    public class FilmeRepository : IFilmeRepository // Herança sendo feita pra herdar da interface IFilmeRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// Data Source = Nome do servidor
        /// Initial Catalog = Nome do Banco de dados
        /// Integrated Security = Faz a autenticação com o usuário do sistema (Windows)
        /// </summary>
        private string StringConnection = "Data Source=MATHEUSNOTE\\SQLEXPRESS; Initial Catalog=Filmes; Integrated Security=true";
        // Atribui o nome do servidor, nome do banco, tipo de autenticação, e os dados do usuário (logon e senha) do banco de dados

        /// <summary>
        /// Atualiza um genero passando o seu Id pelo corpo(body) da requisição
        /// </summary>
        /// <param name="genero">Objeto genero com as novas informações</param>
        public void AtualizarIdCorpo(FilmeDomain movie)
        {
            using (SqlConnection con = new SqlConnection(StringConnection))
            {
                // Declara a query que será executada
                string QueryUpdateIdBody = "UPDATE Filmes SET Titulo = @Titulo WHERE IdFilme = @ID";

                // Declara o SqlCommand "cmd" passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(QueryUpdateIdBody, con))
                {
                    // Passa os valores para os parâmetros
                    cmd.Parameters.AddWithValue("@ID", movie.IdFilme);
                    cmd.Parameters.AddWithValue("@Titulo", movie.Titulo);

                    // Abre a conexão com o banco de dadoa
                    con.Open();

                    // Executa o comando 
                    cmd.ExecuteNonQuery();

                }
            }
        } // Fim de AtualizarIdCorpo


        /// <summary>
        /// Atualiza um filme (movie) passando o Id pelo recurso (Url)
        /// </summary>
        /// <param name="id">Id do filme que será atualizado</param>
        /// <param name="movie">Objeto movie com as novas informações</param>
        public void AtualizarIdUrl(int id, FilmeDomain movie)
            {
                // Declara a SqlConnection "con" passando a string de conexão como parametro
                using (SqlConnection con = new SqlConnection(StringConnection))
                {
                    // Declara a query que será executada
                    string QueryUpdateIdUrl = "UPDATE Filmes SET Titulo = @Titulo WHERE IdFilme = @ID";

                    // Declara o SqlCommand "cmd" passando a query que será executada e a conexão como parâmetros
                    using (SqlCommand cmd = new SqlCommand(QueryUpdateIdUrl, con))
                    {
                        // Passa os valores para os parâmetros
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@Nome", movie.Titulo);

                        // Abre a conexão com o banco de dadoa
                        con.Open();

                        // Executa o comando 
                        cmd.ExecuteNonQuery();

                    }
                }
            } // Fim de AtualizarIdUrl 


        public FilmeDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConnection))
            {
                // Declara a query a ser executada
                string QuerySelectById = "SELECT IdFilme, Titulo FROM Filmes WHERE IdFilme = @ID";

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
                        FilmeDomain FilmeBuscado = new FilmeDomain
                        {
                            // Atribui a propriedade IdFilme o valor da coluna "IdFilme" da tabela do banco de dados
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),

                            // Atribui a propriedade Titulo o valor da coluna "Titulo" da tabela do banco de dados
                            Titulo = (rdr["Titulo"]).ToString(),

                            // Atribui a propriedade IdGenero o valor da coluna "IdGenero" da tabela do banco de dados
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),


                        };
                        // Retorna o FilmeBuscado com os dados obtidos
                        return FilmeBuscado;

                    } // fim do if

                    // Se não, retorna null
                    return null;
                }
            }
        }

        public void Cadastrar(FilmeDomain NovoFilme)
        {
            using (SqlConnection con = new SqlConnection(StringConnection))
            {
                string InsertQuery = "INSERT INTO (Titulo) VALUES (@Titulo)";

                using (SqlCommand cmd = new SqlCommand(InsertQuery, con))
                {
                    cmd.Parameters.AddWithValue("Titulo", NovoFilme.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        } // Fim do método cadastrar

        public void DeletarFilme(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConnection))
            {
                string QueryDelete = "DELETE FROM Filmes WHERE IdFilme = @ID";

                using (SqlCommand cmd = new SqlCommand(QueryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", QueryDelete);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        } // Fim do método Deletar

        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns>Uma lista de filmes</returns>
        public List<FilmeDomain> ListarTodos()
        {
            // Cria uma lista chamada "ListaFilmes" onde serão armazenados os dados
            List<FilmeDomain> ListaFilmes = new List<FilmeDomain>();

            // Declara a SqlConnection "con" passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConnection))
            {
                // Declara a instrução "QuerySelectALL" a ser executada
                string QuerySelectALL = "SELECT IdFilme, Titulo, IdGenero FROM Filmes";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader nomeado "Rdr" para percorrer a tabela Filmes do banco de dados "Filmes"
                SqlDataReader Rdr;

                // Declara o SqlCommand "cmd" passando a query "QuerySelectALL" que será executada e a conexão "con" como parâmetros
                using (SqlCommand cmd = new SqlCommand(QuerySelectALL, con))
                {
                    // Executa a query e armazena os dados no Rdr
                   Rdr = cmd.ExecuteReader();


                    // Enquanto houver registros para serem lidos no Rdr, o laço se repete
                    while (Rdr.Read())
                    {
                        // Instancia objeto nomeado "filme" do tipo FilmeDomain 
                        FilmeDomain filme = new FilmeDomain()
                        { 
                            // Atribui a propriedade "IdFilme" o valor da primeira coluna da tabela "Filmes" do banco de dados
                            IdFilme = Convert.ToInt32(Rdr[0]),

                            // Atribui a propriedade "Titulo" o valor da segundo coluna da tabela "Filmes" do banco de dados
                            Titulo = Rdr[1].ToString(),

                            // Atribui a propriedade "IdGenero" o valor da terceira coluna da tabela "Filmes" do banco de dados
                            IdGenero = Convert.ToInt32(Rdr[2]),
                        };

                        // Adiciona o objeto "filme" na lista "ListaFilmes"
                        ListaFilmes.Add(filme);
                    }
                }
            }

            // Retorna a lista de filmes (ListaFilmes), ou seja, as 3 colunas definidas no banco de dados 
            return (ListaFilmes);


        } // Fim do método ListarTodos
    }
}
