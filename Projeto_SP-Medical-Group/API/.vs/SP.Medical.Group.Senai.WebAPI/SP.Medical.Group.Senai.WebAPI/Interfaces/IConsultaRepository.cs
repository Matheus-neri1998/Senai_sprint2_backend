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

        void Atualizar(int id);

        void Deletar(int id);
    }
}
