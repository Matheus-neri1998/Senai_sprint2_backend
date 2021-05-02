using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source=MATHEUSNOTE\\SQLEXPRESS; initial catalog=InLock; integrated security=true";
        public UsuarioDomain BuscarPorEmailSenha(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection())
            {
                string QuerySelectAll = "SELECT IdUsuario, Email, Senha, IdTipoUsuario FROM Usuarios WHERE Email = @email AND Senha = @senha";

                using (SqlCommand cmd = new SqlCommand(QuerySelectAll, con))
                {
                    cmd.Parameters.AddWithValue("@email", Email);
                    cmd.Parameters.AddWithValue(Senha, Senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain UsuarioBuscado = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = Convert.ToString(rdr["Email"]),
                            Senha = Convert.ToString(rdr["Senha"]),
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"])

                        };


                        return UsuarioBuscado;


                    }

                    return null;
                }


            }
        }
    } // Fim de UsuarioRepository
}
