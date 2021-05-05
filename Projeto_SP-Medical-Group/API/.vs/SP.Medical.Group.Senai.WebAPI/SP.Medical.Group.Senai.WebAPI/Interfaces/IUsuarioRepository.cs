using SP.Medical.Group.Senai.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP.Medical.Group.Senai.WebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de UsuarioRepository
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de jogos</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Busca um usuário existente através do seu ID
        /// </summary>
        /// <param name="id">Id do usuário que será buscado</param>
        /// <returns>Objeto Usuario que será buscado</returns>
        Usuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="NovoUsuario">Objeto NovoUsuario com as novas informações que serão cadastradas</param>
        void Cadastrar(Usuario NovoUsuario);

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">Id do usuário que será atualizado</param>
        /// <param name="Usuario">Objeto Usuario com as novas informações</param>
        void Atualizar(int id, Usuario Usuario);

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="id">Id de um usuário existente que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Valida um usuário 
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Objeto Usuário que foi validado</returns>
        Usuario Login(string email, string senha);
    }
}
