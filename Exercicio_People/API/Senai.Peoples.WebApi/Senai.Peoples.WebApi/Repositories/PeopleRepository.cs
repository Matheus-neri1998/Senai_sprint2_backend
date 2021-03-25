using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos funcionários (People)
    /// </summary>
    public class PeopleRepository : IPeopleRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// Data Source = Nome do servidor
        /// initial catalog = Nome do banco de dados
        /// integrated security=true = Faz a autenticação com o usuário do sistema (Windows) 
        /// </summary>
        private string stringconexao = "Data Source=MATHEUSNOTE\\SQLEXPRESS; initial catalog=Peoples; integrated security=true";

        /// <summary>
        /// Atualiza o nome e sobrenome de um funcionário passando o Id pelo recurso (Url)
        /// </summary>
        /// <param name="id">Id do nome e sobrenome de um funcionário que será atualizado</param>
        /// <param name="people">Objeto people com as novas informações</param>
        public void AtualizarIdUrl(int id, PeopleDomain people)
        {
            // Declara a SqlConnection "con" passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringconexao))
            {
                // Declara a query a ser executada 
                string QueryUpdateIdUrl = "UPDATE Funcionarios SET Nome, Sobrenome = @Nome, @Sobrenome WHERE IdFuncionario = @ID";

                // Declara o SqlCommand "cmd" passando a query que será executada e conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(QueryUpdateIdUrl, con))
                {
                    // Passa os valores para os parametros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", people.nome);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
               
            }
        } // Fim de AtualizarIdUrl
         
        public PeopleDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringconexao))
            {
                string QueryGetById = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios WHERE IdFuncionario = @ID";

                // Abre a conexão com banco de dados 
                con.Open();

                // Declara o SqlDataReader rdr para receber os valores do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand "cmd" passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(QueryGetById, con))
                {
                    // Passa o valor para o parametro @ID
                    cmd.Parameters.AddWithValue("ID", id);

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        // Se sim, instancia um novo objeto PeopleBuscado do tipo PeopleDomain
                        PeopleDomain PeopleBuscado = new PeopleDomain
                        {
                            // Atribui a propriedade "IdFuncionario" o valor da coluna "IdFuncionario" na tabela do banco de dados
                            IdFuncionario = Convert.ToInt32(rdr[0]),

                            // Atribui a propriedade "nome" o valor da segunda coluna "Nome" na tabela do banco de dados 
                            nome = rdr[1].ToString(),

                            // Atribui a propriedade "sobrenome" o valor da terceira coluna "Sobrenome" na tabela do banco de dados 
                            sobrenome = rdr[2].ToString(),


                        };

                        // Retorna um PeopleBuscado com os dados obtidos
                        return PeopleBuscado;
                    }

                    // Se não, retornar null
                    return null;
                }
            }
        } // Fim de BuscarPorId

       /// <summary>
       /// Deleta um nome e sobrenome através do seu id
       /// </summary>
       /// <param name="id">id do nome e sobrenome que será deletado</param>
        public void Deletar(int id)
        {
            // Declara o SqlConnection "con" passando a string de conexão "stringconexao" como parâmetro
            using (SqlConnection con = new SqlConnection(stringconexao))
            {
                // Declara a query a ser executada passando o parâmetro @ID
                string QueryDelete = "DELETE FROM Funcionarios WHERE IdFuncionario = @ID";

                // Declara o SqlCommand passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(QueryDelete, con))
                {
                    // Define o valor do id recebido no método como o valor do parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        } // Fim de Deletar

        /// <summary>
        /// Método Inserir que insere um novo funcionário
        /// </summary>
        /// <param name="newPeople">Objeto "newPeople" com as informações que serão inseridas</param>
        public void Inserir(PeopleDomain newPeople)
        {
            // Declara a SqlConnection(conexão) "con" passando a string de conexão como parâmetros 
            using (SqlConnection con = new SqlConnection(stringconexao))
            {
                // Declara a query que será executada
                string QueryInsert = "INSERT INTO Funcionarios(Nome, Sobrenome) VALUES (@Nome, @Sobrenome)";

                // Declara o SqlCommand "cmd" passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {

                    // Passa o valor para parâmetro @Nome e @Sobrenome 
                    cmd.Parameters.AddWithValue("@Nome", newPeople.nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", newPeople.sobrenome);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        } // Fim de Inserir

        /// <summary>
        /// Lista todos os funcionários (People)
        /// </summary>
        /// <returns>Uma lista de funcionários</returns>
        public List<PeopleDomain> Listar()
        {
            // Cria uma lista chamada "peopleList" onde serão armazenados os dados
            List<PeopleDomain> peopleList = new List<PeopleDomain>();

            // Declara a SqlConnection "con" passando a string de conexão "stringconexao" como parâmetro
            using (SqlConnection con = new SqlConnection(stringconexao))
            {
                // Declara a query a ser executada colocando as colunas da tabela Funcionarios
                string QuerySelectALL = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara a SqlDataReader "rdr" para percorrer a tabela do banco de dados (Funcionarios)
                SqlDataReader rdr;

                // Declara o SqlCommand "cmd" passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(QuerySelectALL, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto people do tipo PeopleDomain
                        PeopleDomain people = new PeopleDomain()
                        {
                            // Atribui à propriedade IdFuncionario o valor da primeira coluna da tabela do banco de dados
                            IdFuncionario = Convert.ToInt32(rdr[0]),

                            // Atribui à propriedade nome o valor da segunda coluna da tabela do banco de dados
                            nome = rdr[1].ToString(),

                            // Atribui à propriedade sobrenome o valor da terceira coluna da tabela do banco de dados
                            sobrenome = rdr[2].ToString()
                        };

                        // Adiciona o objeto "people" criado na lista "peopleList"
                        peopleList.Add(people);
                    }
                }
            }

            //Retorna a lista de funcionários (People)
            return peopleList;

        } // Fim do método Listar
    }
}
