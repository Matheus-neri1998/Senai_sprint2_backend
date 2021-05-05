using SP.Medical.Group.Senai.WebAPI.Context;
using SP.Medical.Group.Senai.WebAPI.Domains;
using SP.Medical.Group.Senai.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP.Medical.Group.Senai.WebAPI.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos Usuários
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        SPMedicalGroupContext context = new SPMedicalGroupContext();

        public void Atualizar(int id, Usuario Usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario NovoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Listar()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">email do usuário</param>
        /// <param name="senha">senha do usuário</param>
        /// <returns>Um objeto Usuario que foi buscado</returns>
        public Usuario Login(string email, string senha)
        {
            // Retorna o usuário encontrado através do email e da senha
            return context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
