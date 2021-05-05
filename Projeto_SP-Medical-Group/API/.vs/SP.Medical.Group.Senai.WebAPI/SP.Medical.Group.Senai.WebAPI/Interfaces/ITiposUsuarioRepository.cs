using SP.Medical.Group.Senai.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP.Medical.Group.Senai.WebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de TiposUsuarioRepository
    /// </summary>
    interface ITiposUsuarioRepository
    {
        /// <summary>
        /// Listar todos os tipos de usuários
        /// </summary>
        /// <returns>Uma lista de tipos de usuários</returns>
        List<TiposUsuario> Listar();

        /// <summary>
        /// Método que será utilizado para buscar um usuário através do seu ID
        /// </summary>
        /// <param name="id">Id do usuário que será buscado</param>
        /// <returns>Objeto TiposUsuario que será buscado</returns>
        TiposUsuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="TipoUsuario">Objeto "NovoUsuario" com as novas informações que serão cadastradas</param>
        void Cadastrar(TiposUsuario TipoUsuario);

        /// <summary>
        /// Atualiza um tipo de usuário existente 
        /// </summary>
        /// <param name="id">id do tipo de usuário que será atualizado</param>
        /// <param name="NovoTipousuario">Objeto Tipousuário com as novas informações</param>
        void Atualizar(int id, TiposUsuario NovoTipousuario);

        /// <summary>
        /// Deleta um tipo de usuário
        /// </summary>
        /// <param name="id">Id do tipo de usuário que será deletado</param>
        void Deletar(int id);
    }
}
