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
    /// Classe responsável pelo repositório dos tipos de usuários
    /// </summary>
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        SPMedicalGroupContext context = new SPMedicalGroupContext();

        /// <summary>
        /// Atualiza um tipo de usuário existente 
        /// </summary>
        /// <param name="id">Id do tipo de usuário que será atualizado</param>
        /// <param name="NovoTipousuario">Objeto "NovoTipousuario" com as novas informações</param>
        public void Atualizar(int id, TiposUsuario NovoTipousuario)
        {
            // Busca um tipo de usuário através do Id
            TiposUsuario TipoUsuarioBuscado = context.TiposUsuarios.Find(id);

            // Verifica se o título do tipo de usuário foi informado
            if (NovoTipousuario.TipoUsuario != null)
            {
                // Atribui os novos valores aos campos existentes 
                TipoUsuarioBuscado.TipoUsuario = NovoTipousuario.TipoUsuario;
            }

            // Atualiza o tipo de usuário que foi buscado
            context.TiposUsuarios.Update(TipoUsuarioBuscado);

            // Salva as informações para serem gravadas no banco
            context.SaveChanges();

        } // Fim do método Atualizar

        /// <summary>
        /// Busca um tipo de usuário através do seu Id
        /// </summary>
        /// <param name="id">Id do tipo de usuário que será buscado</param>
        /// <returns>Um tipo de usuário buscado</returns>
        public TiposUsuario BuscarPorId(int id)
        {
            // Retorna o primeiro tipo de usuário encontrado para o ID informado
            return context.TiposUsuarios.FirstOrDefault(tu => tu.IdTipoUsuario == id);
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="TipoUsuario">Objeto "TipoUsuario" que será cadastrado</param>
        public void Cadastrar(TiposUsuario TipoUsuario)
        {
            // Adiciona "TipoUsuario"
            context.TiposUsuarios.Add(TipoUsuario);

            // Salva as informações para serem gravadas no banco
            context.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de usuário existente 
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será deletado</param>
        public void Deletar(int id)
        {
            // Busca um tipo de usuário através do seu Id
            TiposUsuario TipoUsuarioBuscado = context.TiposUsuarios.Find(id);

            // Remove o tipo de usuário que foi buscado
            context.TiposUsuarios.Remove(TipoUsuarioBuscado);

            // Salva as alterações 
            context.SaveChanges();
        }

        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        /// <returns>Uma lista dos tipos de usuários</returns>
        public List<TiposUsuario> Listar()
        {
            // Retorna uma lista com todas as informações dos tipos de usuários
            return context.TiposUsuarios.ToList();
        }
    }
}
