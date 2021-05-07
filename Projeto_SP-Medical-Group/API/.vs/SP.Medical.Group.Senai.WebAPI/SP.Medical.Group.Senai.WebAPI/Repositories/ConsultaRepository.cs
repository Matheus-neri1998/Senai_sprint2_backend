using Microsoft.EntityFrameworkCore;
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
    /// Classe responsável pelo repositório de Consulta
    /// </summary>
    public class ConsultaRepository : IConsultaRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        SPMedicalGroupContext ctx = new SPMedicalGroupContext();

        public void Atualizar(int id, Consulta ConsultaAtualizada)
        {
            Consulta ConsultaBuscada = ctx.Consultas.Find(id);

            if (ConsultaAtualizada.IdMedico != null)
            {
                ConsultaBuscada.IdMedico = ConsultaAtualizada.IdMedico;
            }

            if (ConsultaAtualizada.IdPaciente != null)
            {
                ConsultaBuscada.IdPaciente = ConsultaAtualizada.IdPaciente;
            }

            if (ConsultaAtualizada.IdSituacao != null)
            {
                ConsultaBuscada.IdSituacao = ConsultaAtualizada.IdSituacao;
            }

            if (ConsultaAtualizada.DataConsulta > DateTime.Now)
            {
                ConsultaBuscada.DataConsulta = ConsultaAtualizada.DataConsulta;
            }

            if (ConsultaAtualizada.Horario != null)
            {
                ConsultaBuscada.Horario = ConsultaAtualizada.Horario;
            }

            if (ConsultaAtualizada.Descricao != null)
            {
                ConsultaBuscada.Descricao = ConsultaAtualizada.Descricao;
            }
        }

        public void AtualizarStatus(int id, string permissao)
        {
            // Busca a primeira situação para o Id informado e armazena no objeto "situacaoBuscada"
            Consulta consultaBuscada = ctx.Consultas

                .Include(c => c.IdMedicoNavigation)

                .Include(c => c.IdPacienteNavigation)

                .Include(c => c.IdSituacaoNavigation)

                .FirstOrDefault(c => c.IdConsulta == id);

                switch (permissao)
                {
                    case "1":
                        consultaBuscada.IdSituacao = 1; // Agendada
                        break;

                    case "0":
                        consultaBuscada.IdSituacao = 0; // Cancelada
                        break;

                    case "2":
                        consultaBuscada.IdSituacao = 2; // Realizada
                        break;

                    default:
                        consultaBuscada.IdSituacao = consultaBuscada.IdSituacao;
                        break;

                } // Fim de Switch Case

            ctx.Consultas.Update(consultaBuscada);

            ctx.SaveChanges();
            
        }

        public Consulta BuscarPorId(int id)
        {
            return ctx.Consultas.FirstOrDefault(c => c.IdConsulta == id);
        }

        public void Cadastrar(Consulta NovaConsulta)
        {
            ctx.Consultas.Add(NovaConsulta);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Consulta ConsultaBuscada = ctx.Consultas.Find(id);

            ctx.Consultas.Remove(ConsultaBuscada);

            ctx.SaveChanges();
        }

        public List<Consulta> Listar()
        {
            return ctx.Consultas.ToList();
        }

        public List<Consulta> ListarMinhas(int IdUsuario)
        {
            return ctx.Consultas

            .Include(c => c.IdConsultaNavigation)

            .Include(c => c.IdMedicoNavigation)

            .Include(c => c.IdPacienteNavigation)

            .Include(c => c.IdSituacaoNavigation)

            .Where(c => c.IdSituacao == IdUsuario)
            .ToList();

        }

        public void Prontuario(int id, Consulta NovoProntuario)
        {
            Consulta ConsultaBuscada = ctx.Consultas.Find(id);

            if (NovoProntuario.Descricao != null)
            {
                ConsultaBuscada.Descricao = NovoProntuario.Descricao;
            }

            ctx.Consultas.Update(ConsultaBuscada);

            ctx.SaveChanges();
        }
    }
}
