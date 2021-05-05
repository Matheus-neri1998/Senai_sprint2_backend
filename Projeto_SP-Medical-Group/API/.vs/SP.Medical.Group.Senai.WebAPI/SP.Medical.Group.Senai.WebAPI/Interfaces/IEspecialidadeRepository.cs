using SP.Medical.Group.Senai.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP.Medical.Group.Senai.WebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo responsável EspecialidadeRepository
    /// </summary>
    interface IEspecialidadeRepository
    {
        List<Especialidade> Listar();

        Especialidade BuscarPorId(int id);

        void Cadastrar(Especialidade especialidade);

        void Atualizar(int id, Especialidade NovaEspecialidade);

        void Deletar(int id);
    }
}
