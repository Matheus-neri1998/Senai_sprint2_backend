using SP.Medical.Group.Senai.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP.Medical.Group.Senai.WebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório MedicoRepository
    /// </summary>
    interface IMedicoRepository
    {
        List<Medico> Listar();

        Medico BuscarPorId(int id);

        void Cadastrar(Medico NovoMedico);

        void Atualizar(int id, Medico NovoMedico);

        void Deletar(int id);
    }
}
