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
    /// Classe responsável pelo repositório de Especialidade
    /// </summary>
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        SPMedicalGroupContext ctx = new SPMedicalGroupContext();

        /// <summary>
        /// Atualiza uma especialidade existente
        /// </summary>
        /// <param name="id">Id da especialidade que será atualizado</param>
        /// <param name="NovaEspecialidade">Objeto "NovaEspecialidade" com as novas informações</param>
        public void Atualizar(int id, Especialidade NovaEspecialidade)
        {
            Especialidade NovaEspecialidadeBuscada = ctx.Especialidades.Find(id);

            // Verifica se o TipoEspecialidade foi informado
            if (NovaEspecialidadeBuscada.TipoEspecialidade != null)
            {
                // Atribui os novos valores aos campos existentes
                NovaEspecialidadeBuscada.TipoEspecialidade = NovaEspecialidadeBuscada.TipoEspecialidade;
            }

            // Atualiza a especialidade que foi buscada
            ctx.Especialidades.Update(NovaEspecialidadeBuscada);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma especialidade através do Id
        /// </summary>
        /// <param name="id">Id da especialidade que será buscada</param>
        /// <returns>Uma especialidade buscada</returns>
        public Especialidade BuscarPorId(int id)
        {
            return ctx.Especialidades.FirstOrDefault(e => e.IdEspecialidade == id);
        }

        /// <summary>
        /// Cadastra uma nova especialidade
        /// </summary>
        /// <param name="especialidade">Objeto "especialidade" com as novas informações</param>
        public void Cadastrar(Especialidade especialidade)
        {
            // Adiciona uma nova presença
            ctx.Especialidades.Add(especialidade);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma especialidade
        /// </summary>
        /// <param name="id">Id da especialidade que será deletado</param>
        public void Deletar(int id)
        {
            // Busca uma especialidade através do seu Id
            Especialidade EspecialidadeBuscada = ctx.Especialidades.Find(id);

            // Remove a especialidade que foi buscada
            ctx.Especialidades.Remove(EspecialidadeBuscada);

            // Salva as informações que serão gravadas no banco
            ctx.SaveChanges();      
        }

        /// <summary>
        /// Lista todas as especialdades
        /// </summary>
        /// <returns>Lista de especialidades</returns>
        public List<Especialidade> Listar()
        {
            // Retorna uma lista com as informações de especialidades
            return ctx.Especialidades.ToList();
        }
    }
}
