using SP.Medical.Group.Senai.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP.Medical.Group.Senai.WebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório ConsultaRepository
    /// </summary>
    interface IConsultaRepository
    {
        List<Consulta> Listar();

        Consulta BuscarPorId(int id);

        void Cadastrar(Consulta NovaConsulta);

        void Atualizar(int id, Consulta ConsultaAtualizada);
        void AtualizarStatus(int id, string status);

        void Deletar(int id);

        List<Consulta> ListarMinhas(int IdUsuario);

        void Prontuario(int id, Consulta NovoProntuario);
    }
}
