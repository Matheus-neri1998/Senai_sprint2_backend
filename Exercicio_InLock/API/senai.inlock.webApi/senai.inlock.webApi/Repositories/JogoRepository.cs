using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string StringConnection = "Data Source=MATHEUSNOTE\\SQLEXPRESS; initial catalog=InLock; integrated security=true";
        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(StringConnection))
            {
                string InsertQuery = "INSERT INTO (Titulo) VALUES (@Titulo)";

                using (SqlCommand cmd = new SqlCommand(InsertQuery, con))
                {

                        cmd.Parameters.AddWithValue("Titulo", novoJogo.NomeJogo);

                        con.Open();

                        cmd.ExecuteNonQuery();

                }
                
            }
        } // Fim do método Cadastrar

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> ListaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(StringConnection))
            {
                string QuerySelectAll = "SELECT IdJogo, NomeJogo, Descricao, DataLancamento, Valor, IdEstudio FROM Jogos";

                con.Open();

                SqlDataReader Rdr;

                using (SqlCommand cmd = new SqlCommand(QuerySelectAll, con))
                {
                    Rdr = cmd.ExecuteReader();

                    while (Rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(Rdr[0]),

                            NomeJogo = Rdr[1].ToString(),

                            Descricao = Rdr[2].ToString(),

                            DataLancamento = Convert.ToDateTime(Rdr[3]),

                            Valor = Convert.ToDouble(Rdr[4]),


                        };

                        ListaJogos.Add(jogo);

                    }
                }
            }

            return (ListaJogos);
            
        } // Fim do método ListarTodos
    }
}
